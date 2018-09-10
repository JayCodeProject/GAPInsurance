using POS.WebAPI.Business;
using POS.WebAPI.Entity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace POS.WebAPI.Providers
{
    public class OAuthServerProvider : OAuthAuthorizationServerProvider
    {
        IUserManagementService _UserManagerService;

        public OAuthServerProvider(IUserManagementService UserManagerService)
        {
            _UserManagerService = UserManagerService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                IFormCollection parameters = await context.Request.ReadFormAsync();
                var loginMethod = int.Parse(parameters.Get("loginMethod").ToString()) <= 0 ? 1 : int.Parse(parameters.Get("loginMethod").ToString());
                var createdUser = parameters.Get("createdUser").ToString().Equals(string.Empty) ? "" : parameters.Get("createdUser").ToString();
                var longitude = parameters.Get("longitude").ToString().Equals(string.Empty) ? "" : parameters.Get("longitude").ToString();
                var latitude = parameters.Get("latitude").ToString().Equals(string.Empty) ? "" : parameters.Get("latitude").ToString();
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                UserAccount user = new UserAccount
                {
                    Username = context.UserName,
                    Password = context.Password,
                    LoginMethod = loginMethod,
                    CreatedUser = createdUser,
                    Longitude = longitude,
                    Latitude = latitude
                };

                var loggedUser = _UserManagerService.AuthenticateUser(user);

                if (context.UserName == loggedUser.Username)
                {
                    switch (loggedUser.RoleId)
                    {
                        case 1:
                            identity.AddClaim(new Claim(ClaimTypes.Role, UserRole.Administrator));
                            break;
                        case 2:
                            identity.AddClaim(new Claim(ClaimTypes.Role, UserRole.Supervisor));
                            break;
                        case 3:
                            identity.AddClaim(new Claim(ClaimTypes.Role, UserRole.ClientApplication));
                            break;
                        case 4:
                            identity.AddClaim(new Claim(ClaimTypes.Role, UserRole.EndUser));
                            break;
                    }

                    identity.AddClaim(new Claim(ClaimTypes.Name, loggedUser.Id.ToString()));

                    var props = new AuthenticationProperties(new Dictionary<string, string>
                               {
                                  {"userId", loggedUser.Id.ToString()},
                                  {"roleId", loggedUser.RoleId.ToString()},
                                  {"status", loggedUser.Status},
                                  {"fullName", loggedUser.FullName},
                                  {"tmpPassword", loggedUser.TmpPassword.ToString()},
                                  {"companyId", loggedUser.CompanyId.ToString()},
                                  {"companyQty", loggedUser.CompanyQty.ToString()},
                                  {"companyName", loggedUser.CompanyName},
                                  {"companyHeadquarter", loggedUser.CompanyHeadquarter.ToString()}
                               });

                    var ticket = new AuthenticationTicket(identity, props);

                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
    }
}