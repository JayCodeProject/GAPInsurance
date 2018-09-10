using POS.WebAPI.Entity;
using System.Collections.Generic;

namespace POS.WebAPI.Business
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomer(Customer customer);
    }
}
