using System;
using POS.WebAPI.Entity;
using POS.WebAPI.Data.Dapper;
using POS.WebAPI.Extender;
using System.Collections.Generic;

namespace POS.WebAPI.Business
{
    public class UserManagementService : IUserManagementService
    {
        private UserManagementRepository _UserManagementRepository;
        private LogRepository _LogRepository;

        public UserManagementService(UserManagementRepository UserManagementRepository, LogRepository LogRepository)
        {
            _UserManagementRepository = UserManagementRepository;
            _LogRepository = LogRepository;
        }

        public int CreateUserAccount(UserAccount user)
        {
            var resp = 0;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();
            user.Password = Utility.Cryptography.CryptoServiceProvider.Encrypt(user.Password, "");

            var jsonParameters = new
            {
                p_cat_user_role = user.Role,
                p_cat_gender = user.GenderId,
                p_cat_profession = user.ProfessionId,
                p_first_name = user.FirstName,
                p_last_name = user.LastName,
                p_second_last_name = user.SecondLastName,
                p_date_of_birth = user.DateOfBirth,
                p_email = user.Email,
                p_identification = user.Identification,
                p_passwd = user.Password,
                p_phone = user.CellPhoneNumber,
                p_ext = user.Ext,
                p_country_code = user.CountryCode,
                p_state = user.StateId,
                p_city = user.CityId,
                p_address1 = user.Address1,
                p_address2 = user.Address2,
                p_created_user = user.CreatedUser
            };

            try
            {
                process.company = user.CompanyName;
                process.procName = "Proc_CreateUser";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = user.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                resp = _UserManagementRepository.CreateUserAccount(user);

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

        public UserAccount GetUserDetailById(UserAccount user)
        {
            UserAccount userDetail = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_user_id = user.Id,
                p_created_user = user.CreatedUser
            };

            try
            {
                process.company = user.CompanyName;
                process.procName = "Proc_GetUserDetailById";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = user.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                userDetail = _UserManagementRepository.GetUserDetailById(user);

                process.result = userDetail.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return userDetail;
        }

        public UserAccount AuthenticateUser(UserAccount user)
        {
            UserAccount loggedUser = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();
            var loginProcess = new LoginEvent();

            user.Password = Utility.Cryptography.CryptoServiceProvider.Encrypt(user.Password, "");

            var jsonParameters = new
            {
                p_username = user.Username,
                p_created_user = user.CreatedUser
            };

            try
            {
                process.company = user.CompanyName;
                process.procName = "Proc_AuthenticateUser";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = user.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                loginProcess.browser = user.AgentBrowser;
                loginProcess.company = user.CompanyName;
                loginProcess.createdUser = user.CreatedUser;
                loginProcess.latitude = user.Latitude;
                loginProcess.longitude = user.Longitude;
                loginProcess.username = user.Username;
                loginProcess.loginMethod = user.LoginMethod;

                loggedUser = _UserManagementRepository.AuthenticateUser(user);

                process.result = loggedUser.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
                _LogRepository.SaveLoginLog(loginProcess);
            }

            return loggedUser;
        }

        public bool UpdateUserDetail(UserAccount user)
        {
            bool updated = false;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_userId = user.Id,
                p_email = user.Email,
                p_phone = user.CellPhoneNumber,
                p_created_user = user.CreatedUser
            };

            try
            {
                process.company = user.CompanyName;
                process.procName = "Proc_UpdateUserDetail";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = user.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                updated = _UserManagementRepository.UpdateUserDetail(user);

                process.result = updated.ToString().SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return updated;
        }

        public bool UpdateUserPassword(UserAccount user)
        {
            bool updated = false;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();
            user.Password = Utility.Cryptography.CryptoServiceProvider.Encrypt(user.Password, "");
            user.NewPassword = Utility.Cryptography.CryptoServiceProvider.Encrypt(user.NewPassword, "");

            var jsonParameters = new
            {
                p_userId = user.Id,
                p_password = user.Password,
                p_created_user = user.CreatedUser,
                p_option = user.Option
            };

            try
            {
                process.company = user.CompanyName;
                process.procName = "Proc_UpdateUserPassword";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = user.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                updated = _UserManagementRepository.UpdateUserPassword(user);

                process.result = updated.ToString().SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return updated;
        }                

        public IEnumerable<Company> GetCompanyByUser(UserAccount user)
        {
            IEnumerable<Company> companyList = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_user_id = user.Id,
                p_created_user = user.CreatedUser
            };

            try
            {
                process.company = user.CompanyName;
                process.procName = "Proc_GetCompanyByUser";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = user.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                companyList = _UserManagementRepository.GetCompanyByUser(user);

                process.result = companyList.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return companyList;
        }
    }
}
