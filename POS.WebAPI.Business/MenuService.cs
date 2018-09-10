using System;
using System.Collections.Generic;
using POS.WebAPI.Entity;
using POS.WebAPI.Data.Dapper;
using POS.WebAPI.Extender;

namespace POS.WebAPI.Business
{
    public class MenuService : IMenuService
    {
        private MenuRepository _MenuRepository;
        private LogRepository _LogRepository;

        public MenuService(MenuRepository MenuRepository, LogRepository LogRepository)
        {
            _MenuRepository = MenuRepository;
            _LogRepository = LogRepository;
        }

        public IEnumerable<MenuItem> GetMenuItem(UserAccount user)
        {
            IEnumerable<MenuItem> menuItemList = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_user_id = user.Id,
                p_created_user = user.CreatedUser,
                p_company_id = user.CompanyId
            };


            try
            {
                process.company = user.CompanyName;
                process.procName = "Proc_GetMenuItem";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = user.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                menuItemList = _MenuRepository.GetMenuItem(user);

                process.result = menuItemList.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return menuItemList;
        }
    }
}
