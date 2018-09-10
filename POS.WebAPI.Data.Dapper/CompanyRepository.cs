using POS.WebAPI.Entity;
using POS.WebAPI.Infraestructure;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace POS.WebAPI.Data.Dapper
{
    public class CompanyRepository
    {
        private IConnectionFactory _connectionFactory;

        public CompanyRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int CreateCompany(Company company)
        {
            var procedure = "dbcomp.Proc_CreateCompany";
            var companyId = 0;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                companyId = connection.QuerySingle<int>(
                                                          procedure,
                                                          param: new
                                                          {
                                                              p_company_name = company.Name,
                                                              p_detail = company.Detail,
                                                              p_cat_company = company.SubProductId,
                                                              p_company_size = company.Size,
                                                              p_logo = company.Logo,
                                                              p_founded_date = company.FoundedDate,
                                                              p_parking = company.Parking,
                                                              p_smoke = company.Smoke,
                                                              p_wifi = company.Wifi,
                                                              p_website = company.Website,
                                                              p_facebook = company.Facebook,
                                                              p_instagram = company.Instagram,
                                                              p_twitter = company.Twitter,
                                                              p_email = company.Email,
                                                              p_phone = company.PhoneNumber,
                                                              p_ext = company.Ext,
                                                              p_country_code = company.CountryCode,
                                                              p_state = company.State,
                                                              p_city = company.City,
                                                              p_address1 = company.Address1,
                                                              p_address2 = company.Address2,
                                                              p_created_user = company.CreatedUser
                                                          },
                                                           commandType: CommandType.StoredProcedure
                                                          );
            }

            return companyId;
        }

        public Company GetCompanyDetailById(Company company)
        {
            var procedure = "dbcomp.Proc_GetCompanyDetailById";
            Company companyDetail = null;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                companyDetail = connection.QuerySingle<Company>(
                                                                  procedure,
                                                                  param: new
                                                                  {
                                                                      p_company_id = company.Id,
                                                                      p_created_user = company.CreatedUser
                                                                  },
                                                                   commandType: CommandType.StoredProcedure
                                                                  );
            }

            return companyDetail;
        }

        public IEnumerable<SubProductCatalog> GetCompanySubProductCatalog(Company company)
        {
            var procedure = "dbcomp.Proc_GetCompanySubProductCatalog";
            IEnumerable<SubProductCatalog> subProductCatalogoList = null;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                subProductCatalogoList = connection.Query<SubProductCatalog>(
                                                                  procedure,
                                                                  param: new
                                                                  {
                                                                      p_company_id = company.Id,
                                                                      p_created_user = company.CreatedUser
                                                                  },
                                                                   commandType: CommandType.StoredProcedure
                                                                  );
            }

            return subProductCatalogoList;
        }

        public ResponseMessage UpdateCompany(Company company)
        {
            var procedure = "dbcomp.Proc_UpdateCompany";
            ResponseMessage response = null;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                response = connection.QuerySingle<ResponseMessage>(
                                                                    procedure,
                                                                    param: new
                                                                    {
                                                                        p_company_id = company.Id,
                                                                        p_name = company.Name,
                                                                        p_detail = company.Detail,
                                                                        p_phone = company.PhoneNumber,
                                                                        p_email = company.Email,
                                                                        p_website = company.Website,
                                                                        p_state_id = company.StateId,
                                                                        p_city_id = company.CityId,
                                                                        p_address1 = company.Address1,
                                                                        p_address2 = company.Address2,
                                                                        p_created_user = company.CreatedUser
                                                                    },
                                                                       commandType: CommandType.StoredProcedure
                                                                  );
            }

            return response;
        }

        public IEnumerable<HeadquarterStation> GetHeadquarterStation(HeadquarterStation headquarter)
        {
            var procedure = "dbcomp.Proc_GetHeadquarterStation";
            IEnumerable<HeadquarterStation> stationList = null;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                stationList = connection.Query<HeadquarterStation>(
                                                                  procedure,
                                                                  param: new
                                                                  {
                                                                      p_headquarter_id = headquarter.HeadquarterId,
                                                                      p_created_user = headquarter.CreatedUser
                                                                  },
                                                                   commandType: CommandType.StoredProcedure
                                                                  );
            }

            return stationList;
        }

        public bool UpdateStationStatus(HeadquarterStation station)
        {
            var procedure = "dbcomp.Proc_UpdateStationStatus";
            bool response = false;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                response = connection.QuerySingle<bool>(
                                                          procedure,
                                                          param: new
                                                          {
                                                              p_id = station.Id,
                                                              p_status = station.Busy,
                                                              p_created_user = station.CreatedUser
                                                          },
                                                           commandType: CommandType.StoredProcedure
                                                        );
            }

            return response;
        }

        public ResponseMessage UpdateAnnouncementStatus(Company company)
        {
            var procedure = "dbcomp.Proc_UpdateAnnouncementStatus";
            ResponseMessage response = null;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                response = connection.QuerySingle<ResponseMessage>(
                                                                    procedure,
                                                                    param: new
                                                                    {
                                                                        p_company_id = company.Id,
                                                                        p_created_user = company.CreatedUser
                                                                    },
                                                                       commandType: CommandType.StoredProcedure
                                                                  );
            }

            return response;
        }

    }
}
