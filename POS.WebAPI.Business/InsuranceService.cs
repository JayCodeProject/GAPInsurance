using System;
using System.Collections.Generic;
using POS.WebAPI.Data.Dapper;
using POS.WebAPI.Entity;
using POS.WebAPI.Extender;

namespace POS.WebAPI.Business
{
    public class InsuranceService : IInsuranceService
    {
        private InsuranceRepository _InsuranceRepository;
        private LogRepository _LogRepository;

        public InsuranceService(InsuranceRepository insuranceRepository, LogRepository logRepository)
        {
            _InsuranceRepository = insuranceRepository;
            _LogRepository = logRepository;
        }


        public IEnumerable<Insurance> GetInsurance(Insurance ins)
        {
            IEnumerable<Insurance> insuranceList = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_created_user = ins.CreatedUser
            };


            try
            {
                process.company = "";
                process.procName = "Proc_GetInsurance";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = ins.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                insuranceList = _InsuranceRepository.GetInsurance(ins);

                process.result = insuranceList.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return insuranceList;
        }

        public ResponseMessage CreateInsurance(Insurance ins)
        {
            ResponseMessage response = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_cat_ins_risk = ins.RiskLevelId,
                p_cat_ins_coverage = ins.CoverageId,
                p_name = ins.Name,
                p_detail = ins.Detail,
                p_valid_date = ins.ValidDate,
                p_price = ins.Price,
                p_cov_period = ins.CovPeriod,
                p_created_user = ins.CreatedUser
            };


            try
            {
                process.company = "";
                process.procName = "Proc_CreateInsurance";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = ins.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                response = _InsuranceRepository.CreateInsurance(ins);

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

        public ResponseMessage UpdateInsurance(Insurance ins)
        {
            ResponseMessage response = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
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
            };


            try
            {
                process.company = "";
                process.procName = "Proc_UpdateInsurance";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = ins.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                response = _InsuranceRepository.UpdateInsurance(ins);

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

        public ResponseMessage DeleteInsurance(Insurance ins)
        {
            ResponseMessage response = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_ins_id = ins.Id,
                p_created_user = ins.CreatedUser
            };


            try
            {
                process.company = "";
                process.procName = "Proc_DeleteInsurance";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = ins.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                response = _InsuranceRepository.DeleteInsurance(ins);

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

        public ResponseMessage AssociateInsurance(InsuranceSale ins)
        {
            ResponseMessage response = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_customer_id = ins.CustomerId,
                p_nsurance_id = ins.InsuranceId,
                p_coverage = ins.Coverage,
                p_created_user = ins.CreatedUser
            };


            try
            {
                process.company = "";
                process.procName = "Proc_AssociateInsurance";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = ins.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                response = _InsuranceRepository.AssociateInsurance(ins);

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

        public IEnumerable<CustomerInsurance> GetCustomerInsurance(Insurance ins)
        {
            IEnumerable<CustomerInsurance> insuranceList = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_ins_id = ins.Id,
                p_created_user = ins.CreatedUser
            };


            try
            {
                process.company = "";
                process.procName = "Proc_GetCustomerInsurance";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = ins.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                insuranceList = _InsuranceRepository.GetCustomerInsurance(ins);

                process.result = insuranceList.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return insuranceList;
        }

        public ResponseMessage DeleteCustomerInsurance(CustomerInsurance ins)
        {
            ResponseMessage response = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_customer_ins_id = ins.Id,
                p_created_user = ins.CreatedUser
            };


            try
            {
                process.company = "";
                process.procName = "Proc_DeleteCustomerInsurance";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = ins.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                response = _InsuranceRepository.DeleteCustomerInsurance(ins);

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
