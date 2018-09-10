using POS.WebAPI.Business;
using POS.WebAPI.Entity;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS.WebAPI.Controllers
{
    public class InsuranceController : ApiController
    {
        IInsuranceService _InsuranceService;

        public InsuranceController() { }

        public InsuranceController(IInsuranceService insuranceService)
        {
            _InsuranceService = insuranceService;
        }


        [SwaggerOperation("Get")]
        [HttpPost]
        [Route("api/v1/insurance/get")]
        public IHttpActionResult GetInsurance(Insurance ins)
        {
            var resp = _InsuranceService.GetInsurance(ins);

            if (resp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resp);
            }
        }

        [SwaggerOperation("Create")]
        [HttpPost]
        [Route("api/v1/insurance/create")]
        public IHttpActionResult CreateInsurance(Insurance ins)
        {
            var resp = _InsuranceService.CreateInsurance(ins);

            if (resp == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(resp);
            }
        }

        [SwaggerOperation("Update")]
        [HttpPost]
        [Route("api/v1/insurance/update")]
        public IHttpActionResult UpdateInsurance(Insurance ins)
        {
            var resp = _InsuranceService.UpdateInsurance(ins);

            if (resp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resp);
            }
        }

        [SwaggerOperation("Update")]
        [HttpPost]
        [Route("api/v1/insurance/delete")]
        public IHttpActionResult DeleteInsurance(Insurance ins)
        {
            var resp = _InsuranceService.DeleteInsurance(ins);

            if (resp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resp);
            }
        }


        [SwaggerOperation("Create")]
        [HttpPost]
        [Route("api/v1/insurance/associate")]
        public IHttpActionResult AssociateInsurance(InsuranceSale ins)
        {
            var resp = _InsuranceService.AssociateInsurance(ins);

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
        [Route("api/v1/insurance/customer/get")]
        public IHttpActionResult GetCustomerInsurance(Insurance ins)
        {
            var resp = _InsuranceService.GetCustomerInsurance(ins);

            if (resp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resp);
            }
        }

        [SwaggerOperation("Delete")]
        [HttpPost]
        [Route("api/v1/insurance/customer/delete")]
        public IHttpActionResult DeleteCustomerInsurance(CustomerInsurance ins)
        {
            var resp = _InsuranceService.DeleteCustomerInsurance(ins);

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
