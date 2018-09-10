using System;
using POS.WebAPI.Entity;
using POS.WebAPI.Data.Dapper;
using POS.WebAPI.Extender;
using System.Collections.Generic;

namespace POS.WebAPI.Business
{
    public class CustomerService : ICustomerService
    {
        private CustomerRepository _CustomerRepository;
        private LogRepository _LogRepository;

        public CustomerService(CustomerRepository customerRepository, LogRepository logRepository)
        {
            _CustomerRepository = customerRepository;
            _LogRepository = logRepository;
        }

        public IEnumerable<Customer> GetCustomer(Customer customer)
        {
            IEnumerable<Customer> response = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {            
                p_created_user = customer.CreatedUser
            };

            try
            {
                process.company = "";
                process.procName = "Proc_GetCustomer";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = customer.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                response = _CustomerRepository.GetCustomer(customer);

                process.result = response.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return response;
        }
    }
}
