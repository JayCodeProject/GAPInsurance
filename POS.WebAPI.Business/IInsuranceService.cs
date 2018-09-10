using POS.WebAPI.Entity;
using System.Collections.Generic;

namespace POS.WebAPI.Business
{
    public interface IInsuranceService
    {
        IEnumerable<Insurance> GetInsurance(Insurance ins);
        ResponseMessage CreateInsurance(Insurance ins);
        ResponseMessage UpdateInsurance(Insurance ins);
        ResponseMessage DeleteInsurance(Insurance ins);
        ResponseMessage AssociateInsurance(InsuranceSale ins);
        IEnumerable<CustomerInsurance> GetCustomerInsurance(Insurance ins);
        ResponseMessage DeleteCustomerInsurance(CustomerInsurance ins);
    }
}
