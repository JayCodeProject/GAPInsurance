using POS.WebAPI.Entity;
using POS.WebAPI.Infraestructure;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace POS.WebAPI.Data.Dapper
{
    public class UserManagementRepository
    {
        private IConnectionFactory _ConnectionFactory;

        public UserManagementRepository(ConnectionFactory connectionFactory)
        {
            _ConnectionFactory = connectionFactory;
        }

        public int CreateUserAccount(UserAccount user)
        {
            var procedure = "dbuser.Proc_CreateUser";
            var userId = 0;

            using (IDbConnection connection = _ConnectionFactory.GetConnection)
            {
                userId = connection.QuerySingle<int>(
                                                          procedure,
                                                          param: new
                                                          {
                                                              p_cat_user_role = user.RoleId,
                                                              p_cat_gender = user.GenderId,
                                                              p_cat_profession = user.ProfessionId,
                                                              p_first_name = user.FirstName,
                                                              p_last_name = user.LastName,
                                                              p_second_last_name = user.SecondLastName,
                                                              p_date_of_birth = user.DateOfBirth,
                                                              p_email = user.Email,
                                                              p_identification = user.Identification,
                                                              p_passwd = user.Password,
                                                              p_phone = user.CellPhoneNumber,
                                                              p_ext = user.Ext,
                                                              p_country_code = user.CountryCode,
                                                              p_state = user.StateId,
                                                              p_city = user.CityId,
                                                              p_address1 = user.Address1,
                                                              p_address2 = user.Address2,
                                                              p_created_user = user.CreatedUser,
                                                              p_company_id = user.CompanyId
                                                          },
                                                           commandType: CommandType.StoredProcedure
                                                          );
            }

            return userId;
        }

        public UserAccount GetUserDetailById(UserAccount user)
        {
            var procedure = "dbuser.Proc_GetUserDetailById";
            UserAccount userDetail = null;

            using (IDbConnection connection = _ConnectionFactory.GetConnection)
            {
                userDetail = connection.QuerySingle<UserAccount>(
                                                                  procedure,
                                                                  param: new
                                                                  {
                                                                      p_user_id = user.Id,
                                                                      p_created_user = user.CreatedUser
                                                                  },
                                                                   commandType: CommandType.StoredProcedure
                                                                  );
            }

            return userDetail;
        }

        public UserAccount AuthenticateUser(UserAccount user)
        {
            var procedure = "dbuser.Proc_AuthenticateUser";
            UserAccount loggedUser = null;

            using (IDbConnection connection = _ConnectionFactory.GetConnection)
            {
                loggedUser = connection.QuerySingle<UserAccount>(
                                                                  procedure,
                                                                  param: new
                                                                  {
                                                                      p_username = user.Username,
                                                                      p_password = user.Password,
                                                                      p_created_user = user.CreatedUser,
                                                                      p_login_method = user.LoginMethod,
                                                                      p_agent_browser = user.AgentBrowser,
                                                                      p_longitude = user.Longitude,
                                                                      p_latitude = user.Latitude
                                                                  },
                                                                   commandType: CommandType.StoredProcedure
                                                                  );
            }

            return loggedUser;
        }

        public bool UpdateUserDetail(UserAccount user)
        {
            var procedure = "dbuser.Proc_UpdateUserDetail";
            bool updated = false;

            using (IDbConnection connection = _ConnectionFactory.GetConnection)
            {
                updated = connection.QuerySingle<bool>(
                                                        procedure,
                                                        param: new
                                                        {
                                                            p_userId = user.Id,
                                                            p_email = user.Email,
                                                            p_cellphone = user.CellPhoneNumber,
                                                            p_created_user = user.CreatedUser
                                                        },
                                                         commandType: CommandType.StoredProcedure
                                                       );
            }

            return updated;
        }

        public bool UpdateUserPassword(UserAccount user)
        {
            var procedure = "dbuser.Proc_UpdateUserPassword";
            bool updated = false;

            using (IDbConnection connection = _ConnectionFactory.GetConnection)
            {
                updated = connection.QuerySingle<bool>(
                                                        procedure,
                                                        param: new
                                                        {
                                                            p_userId = user.Id,
                                                            p_password = user.Password,
                                                            p_new_password = user.NewPassword,
                                                            p_created_user = user.CreatedUser,
                                                            p_option = user.Option
                                                        },
                                                        commandType: CommandType.StoredProcedure
                                                       );
            }

            return updated;
        }

        public IEnumerable<Company> GetCompanyByUser(UserAccount user)
        {
            var procedure = "dbuser.Proc_GetCompanyByUser";
            IEnumerable<Company> companyList;

            using (IDbConnection connection = _ConnectionFactory.GetConnection)
            {
                companyList = connection.Query<Company>(
                                                      procedure,
                                                      param: new
                                                      {
                                                          p_user_id = user.Id,
                                                          p_created_user = user.CreatedUser
                                                      },
                                                      commandType: CommandType.StoredProcedure
                                                     );
            }

            return companyList;
        }
    }
}
