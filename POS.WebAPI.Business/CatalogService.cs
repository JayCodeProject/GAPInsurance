using System;
using System.Collections.Generic;
using POS.WebAPI.Data.Dapper;
using POS.WebAPI.Entity;
using POS.WebAPI.Extender;

namespace POS.WebAPI.Business
{
    public class CatalogService : ICatalogService
    {
        private CatalogRepository _CatalogRepository;
        private LogRepository _LogRepository;

        public CatalogService(CatalogRepository catalogRepository, LogRepository logRepository)
        {
            _CatalogRepository = catalogRepository;
            _LogRepository = logRepository;
        }


        public IEnumerable<RiskLevelCatalog> GetRiskLevelCatalog(RiskLevelCatalog risk)
        {
            IEnumerable<RiskLevelCatalog> riskLevelList = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {

            };


            try
            {
                process.company = "";
                process.procName = "Proc_GetPaymentCatalog";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = risk.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                riskLevelList = _CatalogRepository.GetRiskLevelCatalog(risk);

                process.result = riskLevelList.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return riskLevelList;
        }

        public IEnumerable<CoverageCatalog> GetCoverageCatalog(CoverageCatalog cov)
        {
            IEnumerable<CoverageCatalog> coverageList = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {

            };


            try
            {
                process.company = "";
                process.procName = "Proc_GetCoverageCatalog";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = cov.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                coverageList = _CatalogRepository.GetCoverageCatalog(cov);

                process.result = coverageList.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return coverageList;
        }
    }
}
