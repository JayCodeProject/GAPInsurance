using POS.WebAPI.Entity;
using System.Collections.Generic;

namespace POS.WebAPI.Business
{
    public interface ICompanyService
    {
        int CreateCompany(Company company);
        Company GetCompanyDetailById(Company company);
        IEnumerable<SubProductCatalog> GetSubProductCatalog(Company company);
        ResponseMessage UpdateCompany(Company company);
        IEnumerable<HeadquarterStation> GetHeadquarterStation(HeadquarterStation headquarter);
        bool UpdateStationStatus(HeadquarterStation station);
        ResponseMessage UpdateAnnouncementStatus(Company company);
    }
}
