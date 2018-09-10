using POS.WebAPI.Entity;
using System.Collections.Generic;

namespace POS.WebAPI.Business
{
    public interface ICatalogService
    {

        IEnumerable<RiskLevelCatalog> GetRiskLevelCatalog(RiskLevelCatalog risk);
        IEnumerable<CoverageCatalog> GetCoverageCatalog(CoverageCatalog cov);
    }
}
