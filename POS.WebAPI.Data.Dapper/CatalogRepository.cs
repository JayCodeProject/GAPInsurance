using POS.WebAPI.Infraestructure;
using Dapper;
using POS.WebAPI.Entity;
using System.Collections.Generic;
using System.Data;

namespace POS.WebAPI.Data.Dapper
{
    public class CatalogRepository
    {
        private IConnectionFactory _connectionFactory;

        public CatalogRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<RiskLevelCatalog> GetRiskLevelCatalog(RiskLevelCatalog risk)
        {
            var procedure = "dbo.Proc_GetRiskCatalog";
            IEnumerable<RiskLevelCatalog> RiskLevelList = null;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                RiskLevelList = connection.Query<RiskLevelCatalog>(
                                                      procedure,
                                                      param: new
                                                      {
                                                          p_created_user = risk.CreatedUser
                                                      }
                                                      ,
                                                      commandType: CommandType.StoredProcedure
                                                   );
            }

            return RiskLevelList;
        }

        public IEnumerable<CoverageCatalog> GetCoverageCatalog(CoverageCatalog cov)
        {
            var procedure = "dbo.Proc_GetCoverageCatalog";
            IEnumerable<CoverageCatalog> coverageList = null;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                coverageList = connection.Query<CoverageCatalog>(
                                                      procedure,
                                                      param: new
                                                      {
                                                          p_created_user = cov.CreatedUser
                                                      }
                                                      ,
                                                      commandType: CommandType.StoredProcedure
                                                   );
            }

            return coverageList;
        }
    }
}
