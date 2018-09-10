using System;
using POS.WebAPI.Entity;
using POS.WebAPI.Data.Dapper;
using POS.WebAPI.Extender;
using System.Collections.Generic;

namespace POS.WebAPI.Business
{
    public class CompanyService : ICompanyService
    {
        private CompanyRepository _CompanyRepository;
        private LogRepository _LogRepository;

        public CompanyService(CompanyRepository CompanyRepository, LogRepository LogRepository)
        {
            _CompanyRepository = CompanyRepository;
            _LogRepository = LogRepository;
        }

        public int CreateCompany(Company company)
        {
            var resp = 0;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
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
                p_state = company.State,
                p_city = company.City,
                p_address1 = company.Address1,
                p_address2 = company.Address2,
                p_created_user = company.CreatedUser
            };

            try
            {
                process.procName = "Proc_CreateCompany";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = company.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                resp = _CompanyRepository.CreateCompany(company);

                process.result = resp.ToString();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return resp;
        }

        public Company GetCompanyDetailById(Company company)
        {
            Company companyDetail = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_company_id = company.Id,
                p_created_user = company.CreatedUser
            };

            try
            {
                process.company = company.Name;
                process.procName = "Proc_GetCompanyDetailById";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = company.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                companyDetail = _CompanyRepository.GetCompanyDetailById(company);

                process.result = companyDetail.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return companyDetail;
        }

        public IEnumerable<SubProductCatalog> GetSubProductCatalog(Company company)
        {
            IEnumerable<SubProductCatalog> subProductCatalogList = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_company_id = company.Id,
                p_created_user = company.CreatedUser
            };

            try
            {
                process.company = company.Name;
                process.procName = "Proc_GetCompanySubproductCatalog";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = company.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                subProductCatalogList = _CompanyRepository.GetCompanySubProductCatalog(company);

                process.result = subProductCatalogList.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return subProductCatalogList;
        }

        public ResponseMessage UpdateCompany(Company company)
        {
            ResponseMessage response = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_company_id = company.Id,
                p_name = company.Name,
                p_detail = company.Detail,
                p_phone = company.PhoneNumber,
                p_email = company.Email,
                p_website = company.Website,
                p_state_id = company.StateId,
                p_city_id = company.CityId,
                p_address = company.Address1,
                p_created_user = company.CreatedUser
            };

            try
            {
                process.company = company.Name;
                process.procName = "Proc_UpdateCompany";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = company.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                response = _CompanyRepository.UpdateCompany(company);

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

        public IEnumerable<HeadquarterStation> GetHeadquarterStation(HeadquarterStation headquarter)
        {
            IEnumerable<HeadquarterStation> stationList = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_headquarter_id = headquarter.Id,
                p_created_user = headquarter.CreatedUser
            };

            try
            {
                process.company = "";
                process.procName = "Proc_GetHeadquarterStation";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = headquarter.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                stationList = _CompanyRepository.GetHeadquarterStation(headquarter);

                process.result = stationList.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return stationList;
        }

        public bool UpdateStationStatus(HeadquarterStation station)
        {
            bool response = false;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_id = station.Id,
                p_satus = station.Busy,
                p_created_user = station.CreatedUser
            };

            try
            {
                process.company = "";
                process.procName = "Proc_UpdateStationStatus";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = station.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                response = _CompanyRepository.UpdateStationStatus(station);

                process.result = response.ToString().SerializeObject();
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
               

        public ResponseMessage UpdateAnnouncementStatus(Company company)
        {
            ResponseMessage response = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_company_id = company.Id,
                p_created_user = company.CreatedUser
            };

            try
            {
                process.company = company.Name;
                process.procName = "Proc_UpdateAnnouncementStatus";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = company.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                response = _CompanyRepository.UpdateAnnouncementStatus(company);

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

