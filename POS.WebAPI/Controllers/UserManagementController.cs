using POS.WebAPI.Business;
using POS.WebAPI.Entity;
using Swashbuckle.Swagger.Annotations;
using System.Security.Claims;
using System.Web.Http;

namespace POS.WebAPI.Controllers
{
    public class UserManagementController : ApiController
    {
        IUserManagementService _UserManagementService;

        public UserManagementController()
        {

        }

        public UserManagementController(IUserManagementService UserManagementService)
        {
            _UserManagementService = UserManagementService;
        }

        [SwaggerOperation("Create")]       
        [HttpPost]
        [Route("api/v1/usermanagement/create")]
        public IHttpActionResult CreateUserAccount(UserAccount user)
        {
            var resp = _UserManagementService.CreateUserAccount(user);

            if (resp == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(resp);
            }
        }

        [Authorize]
        [SwaggerOperation("Get")]
        [HttpPost]
        [Route("api/v1/usermanagement/user")]
        public IHttpActionResult GetUserDetailById(UserAccount user)
        {
            var currentUserId = ClaimsPrincipal.Current.Identity.Name;
            user.Id = int.Parse(currentUserId);

            var userDetail = _UserManagementService.GetUserDetailById(user);

            if (userDetail == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(userDetail);
            }
        }

        [SwaggerOperation("Get")]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/v1/usermanagement/authenticate")]
        public IHttpActionResult AuthenticateUser(UserAccount user)
        {
            var loggedUser = _UserManagementService.AuthenticateUser(user);

            if (loggedUser == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(loggedUser);
            }
        }

        [Authorize]
        [SwaggerOperation("Update")]
        [HttpPost]
        [Route("api/v1/usermanagement/update")]
        public IHttpActionResult UpdateUserDetail(UserAccount user)
        {
            var updated = _UserManagementService.UpdateUserDetail(user);

            return Ok(updated);
        }

        [Authorize]
        [SwaggerOperation("Update")]
        [HttpPost]
        [Route("api/v1/usermanagement/update/password")]
        public IHttpActionResult UpdateUserPassword(UserAccount user)
        {
            var updated = _UserManagementService.UpdateUserPassword(user);

            return Ok(updated);
        }


        [Authorize]
        [SwaggerOperation("Get")]   
        [HttpPost]
        [Route("api/v1/usermanagement/usercompany")]
        public IHttpActionResult GetCompanyByUser(UserAccount user)
        {
            var currentUserId = ClaimsPrincipal.Current.Identity.Name;
            user.Id = int.Parse(currentUserId);

            var companyList = _UserManagementService.GetCompanyByUser(user);

            if (companyList == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(companyList);
            }
        }
    }
}
