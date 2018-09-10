using POS.WebAPI.Business;
using POS.WebAPI.Entity;
using Swashbuckle.Swagger.Annotations;
using System.Security.Claims;
using System.Web.Http;

namespace POS.WebAPI.Controllers
{
    public class NotificationController : ApiController
    {
        INotificationService _NotificationService;

        public NotificationController()
        {

        }

        public NotificationController(INotificationService NotificationService)
        {
            _NotificationService = NotificationService;
        }

        [Authorize]
        [SwaggerOperation("Get")]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/v1/notification")]
        public IHttpActionResult GetUserDetailById(UserAccount user)
        {
            var currentUserId = ClaimsPrincipal.Current.Identity.Name;
            user.Id = int.Parse(currentUserId);

            var notificationList = _NotificationService.GetNotificationByUse(user);

            if (notificationList == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(notificationList);
            }
        }
    }
}
