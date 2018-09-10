using POS.WebAPI.Business;
using POS.WebAPI.Entity;
using Swashbuckle.Swagger.Annotations;
using System.Web.Http;

namespace POS.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {

        ICustomerService _CustomerService;

        public CustomerController() { }

        public CustomerController(ICustomerService customerService)
        {
            _CustomerService = customerService;
        }

        [SwaggerOperation("Get")]
        [HttpPost]
        [Route("api/v1/customer/get")]
        public IHttpActionResult GetCustomer(Customer customer)
        {
            var response = _CustomerService.GetCustomer(customer);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
