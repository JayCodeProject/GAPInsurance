using POS.WebAPI.Business;
using POS.WebAPI.Entity;
using Swashbuckle.Swagger.Annotations;
using System.Web.Http;

namespace POS.WebAPI.Controllers
{
    public class CompanyController : ApiController
    {
        ICompanyService _CompanyService;

        public CompanyController()
        {

        }

        public CompanyController(ICompanyService companyService)
        {
            _CompanyService = companyService;
        }

        [SwaggerOperation("Create")]
        [HttpPost]
        [Route("api/v1/company/create")]
        public IHttpActionResult CreateUserAccount(Company company)
        {
            var resp = _CompanyService.CreateCompany(company);

            if (resp == 0)
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
        [Route("api/v1/company/get")]
        public IHttpActionResult GetCompanyDetailById(Company company)
        {
            var resp = _CompanyService.GetCompanyDetailById(company);

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
        [Route("api/v1/company/subproductcatalog")]
        public IHttpActionResult GetSubProductCatalog(Company company)
        {
            var resp = _CompanyService.GetSubProductCatalog(company);

            if (resp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resp);
            }
        }

        [SwaggerOperation("Put")]
        [HttpPut]
        [Route("api/v1/company/update")]
        public IHttpActionResult UpdateCompany(Company company)
        {
            var resp = _CompanyService.UpdateCompany(company);

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
        [Route("api/v1/company/headquarterstation")]
        public IHttpActionResult GetSubProductCatalog(HeadquarterStation headquarter)
        {
            var resp = _CompanyService.GetHeadquarterStation(headquarter);

            if (resp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resp);
            }
        }

        [SwaggerOperation("Put")]
        [HttpPut]
        [Route("api/v1/company/station/status/update")]
        public IHttpActionResult UpdateStationStatus(HeadquarterStation station)
        {
            var resp = _CompanyService.UpdateStationStatus(station);

            if (resp == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok(resp);
            }
        }


        [SwaggerOperation("Put")]
        [HttpPut]
        [Route("api/v1/company/announcement/status/update")]
        public IHttpActionResult UpdateAnnouncementStatus(Company company)
        {
            var resp = _CompanyService.UpdateAnnouncementStatus(company);

            if (resp == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(resp);
            }
        }

    }
}
