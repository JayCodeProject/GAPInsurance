using POS.WebAPI.Business;
using POS.WebAPI.Entity;
using Swashbuckle.Swagger.Annotations;
using System.Security.Claims;
using System.Web.Http;

namespace POS.WebAPI.Controllers
{
    public class MenuController : ApiController
    {
        IMenuService _MenuService;

        public MenuController()
        {

        }

        public MenuController(IMenuService MenuService)
        {
            _MenuService = MenuService;
        }

        [Authorize]
        [SwaggerOperation("Get")]
        [HttpPost]
        [Route("api/v1/menu")]
        public IHttpActionResult GetMenuItem(UserAccount user)
        {
            var currentUserId = ClaimsPrincipal.Current.Identity.Name;
            user.Id = int.Parse(currentUserId);

            var menuItemList = _MenuService.GetMenuItem(user);

            if (menuItemList == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(menuItemList);
            }
        }
    }
}
