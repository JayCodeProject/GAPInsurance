using Dapper;
using POS.WebAPI.Entity;
using POS.WebAPI.Infraestructure;
using System.Collections.Generic;
using System.Data;

namespace POS.WebAPI.Data.Dapper
{
    public class InsuranceRepository
    {
        private IConnectionFactory _ConnectionFactory;

        public InsuranceRepository(IConnectionFactory connectionFactory)
        {
            _ConnectionFactory = connectionFactory;
        }

        public IEnumerable<Insurance> GetInsurance(Insurance ins)
        {
            var procedure = "dbo.Proc_GetInsurance";
            IEnumerable<Insurance> insuranceList = null;

            using (IDbConnection connection = _ConnectionFactory.GetConnection)
            {
                insuranceList = connection.Query<Insurance>(
                                                      procedure,
                                                      param: new
                                                      {
                                                          p_created_user = ins.CreatedUser
                                                      }
                                                      ,
                                                      commandType: CommandType.StoredProcedure
                                                   );
            }

            return insuranceList;
        }

        public ResponseMessage CreateInsurance(Insurance ins)
        {
            var procedure = "dbo.Proc_CreateInsurance";
            ResponseMessage response = null;

            using (IDbConnection connection = _ConnectionFactory.GetConnection)
            {
                response = connection.QuerySingle<ResponseMessage>(
                                                      procedure,
                                                      param: new
                                                      {
                                                          p_cat_ins_risk = ins.RiskLevelId,
                                                          p_cat_ins_coverage = ins.CoverageId,
                                                          p_name = ins.Name,
                                                          p_detail = ins.Detail,
                                                          p_valid_date = ins.ValidDate,
                                                          p_price = ins.Price,
                                                          p_cov_period = ins.CovPeriod,
                                                          p_created_user = ins.CreatedUser
                                                      }
                                                      ,
                                                      commandType: CommandType.StoredProcedure
                                                   );
            }

            return response;
        }

        public ResponseMessage UpdateInsurance(Insurance ins)
        {
            var procedure = "dbo.Proc_UpdateInsurance";
            ResponseMessage response = null;

            using (IDbConnection connection = _ConnectionFactory.GetConnection)
            {
                response = connection.QuerySingle<ResponseMessage>(
                                                      procedure,
                                                      param: new
                                                      {
                                                          p_ins_id = ins.Id,
                                                          p_cat_ins_risk = ins.RiskLevelId,
                                                          p_cat_ins_coverage = ins.CoverageId,
                                                          p_name = ins.Name,
                                                          p_detail = ins.Detail,
                                                          p_valid_date = ins.ValidDate,
                                                          p_price = ins.Price,
                                                          p_cov_period = ins.CovPeriod,
                                                          p_created_user = ins.CreatedUser
                                                      }
                                                      ,
                                                      commandType: CommandType.StoredProcedure
                                                   );
            }

            return response;
        }

        public ResponseMessage DeleteInsurance(Insurance ins)
        {
            var procedure = "dbo.Proc_DeleteInsurance";
            ResponseMessage response = null;

            using (IDbConnection connection = _ConnectionFactory.GetConnection)
            {
                response = connection.QuerySingle<ResponseMessage>(
                                                      procedure,
                                                      param: new
                                                      {
                                                          p_ins_id = ins.Id,
                                                          p_created_user = ins.CreatedUser
                                                      }
                                                      ,
                                                      commandType: CommandType.StoredProcedure
                                                   );
            }

            return response;
        }

        public ResponseMessage AssociateInsurance(InsuranceSale ins)
        {
            var procedure = "dbo.Proc_AssociateInsurance";
            ResponseMessage response = null;

            using (IDbConnection connection = _ConnectionFactory.GetConnection)
            {
                response = connection.QuerySingle<ResponseMessage>(
                                                      procedure,
                                                      param: new
                                                      {
                                                          p_customer_id = ins.CustomerId,
                                                          p_insurance_id = ins.InsuranceId,
                                                          p_coverage = ins.Coverage,
                                                          p_created_user = ins.CreatedUser
                                                      }
                                                      ,
                                                      commandType: CommandType.StoredProcedure
                                                   );
            }

            return response;
        }

        public IEnumerable<CustomerInsurance> GetCustomerInsurance(Insurance ins)
        {
            var procedure = "dbo.Proc_GetCustomerInsurance";
            IEnumerable<CustomerInsurance> insuranceList = null;

            using (IDbConnection connection = _ConnectionFactory.GetConnection)
            {
                insuranceList = connection.Query<CustomerInsurance>(
                                                      procedure,
                                                      param: new
                                                      {
                                                          p_ins_id = ins.Id,
                                                          p_created_user = ins.CreatedUser
                                                      }
                                                      ,
                                                      commandType: CommandType.StoredProcedure
                                                   );
            }

            return insuranceList;
        }

        public ResponseMessage DeleteCustomerInsurance(CustomerInsurance ins)
        {
            var procedure = "dbo.Proc_DeleteCustomerInsurance";
            ResponseMessage response = null;

            using (IDbConnection connection = _ConnectionFactory.GetConnection)
            {
                response = connection.QuerySingle<ResponseMessage>(
                                                      procedure,
                                                      param: new
                                                      {
                                                          p_customer_ins_id = ins.Id,
                                                          p_created_user = ins.CreatedUser
                                                      }
                                                      ,
                                                      commandType: CommandType.StoredProcedure
                                                   );
            }

            return response;
        }
    }

}
