using Dapper;
using POS.WebAPI.Entity;
using POS.WebAPI.Infraestructure;
using System.Collections.Generic;
using System.Data;

namespace POS.WebAPI.Data.Dapper
{
    public class CustomerRepository
    {
        private IConnectionFactory _connectionFactory;

        public CustomerRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        public IEnumerable<Customer> GetCustomer(Customer customer)
        {
            var procedure = "dbo.Proc_GetCustomer";
            IEnumerable<Customer> response;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                response = connection.Query<Customer>(
                                                      procedure,
                                                      param: new
                                                      {                                                        
                                                          p_created_user = customer.CreatedUser
                                                      }
                                                      ,
                                                      commandType: CommandType.StoredProcedure
                                                   );
            }
            return response;
        }
    }
}
