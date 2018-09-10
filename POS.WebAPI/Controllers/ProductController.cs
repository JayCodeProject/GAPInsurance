using POS.WebAPI.Entity;
using POS.WebAPI.Business;
using Swashbuckle.Swagger.Annotations;
using System.Web.Http;

namespace POS.WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        IProductService _ProductService;

        public ProductController(IProductService productService)
        {
            _ProductService = productService;
        }

        [SwaggerOperation("Post")]
        [HttpPost]
        [Route("api/v1/product/create")]
        public IHttpActionResult CreateProductItem(Product item)
        {
            var resp = _ProductService.CreateProductItem(item);

            if (resp == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(resp);
            }
        }

        [SwaggerOperation("Get")]
        [HttpPost]
        [Route("api/v1/product/get/company")]
        public IHttpActionResult GetProductItemByCompany(Company company)
        {
            var resp = _ProductService.GetProductItemByCompany(company);

            if (resp == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(resp);
            }
        }

        [SwaggerOperation("Post")]
        [HttpPost]
        [Route("api/v1/product/delete")]
        public IHttpActionResult DeleteProductById(Product product)
        {
            var resp = _ProductService.DeleteItemById(product);

            if (resp == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(resp);
            }
        }

        [SwaggerOperation("Post")]
        [HttpPost]
        [Route("api/v1/product/update")]
        public IHttpActionResult UpdateItemById(Product product)
        {
            var resp = _ProductService.UpdateItemById(product);

            if (resp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resp);
            }
        }
    }
}
