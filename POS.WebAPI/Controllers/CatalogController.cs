using POS.WebAPI.Business;
using POS.WebAPI.Entity;
using Swashbuckle.Swagger.Annotations;
using System.Web.Http;

namespace POS.WebAPI.Controllers
{
    public class CatalogController : ApiController
    {
        ICatalogService _CatalogService;

        public CatalogController() { }

        public CatalogController(ICatalogService catalogService)
        {
            _CatalogService = catalogService;
        }


        [SwaggerOperation("Get")]
        [HttpPost]
        [Route("api/v1/catalog/risklevel")]
        public IHttpActionResult GetRiskLevelCatalog(RiskLevelCatalog risk)
        {
            var resp = _CatalogService.GetRiskLevelCatalog(risk);

            if (resp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resp);
            }
        }

        [SwaggerOperation("Get")]
        [HttpPost]
        [Route("api/v1/catalog/coverage")]
        public IHttpActionResult GetRiskLevelCatalog(CoverageCatalog coverage)
        {
            var resp = _CatalogService.GetCoverageCatalog(coverage);

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
