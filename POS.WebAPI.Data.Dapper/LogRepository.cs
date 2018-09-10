using POS.WebAPI.Entity;
using POS.WebAPI.Infraestructure;
using Dapper;
using System.Data;

namespace POS.WebAPI.Data.Dapper
{
    public class LogRepository
    {
        private IConnectionFactory _connectionFactory;

        public LogRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void SaveLog(ProcessEvent process)
        {
            var procedure = "dblog.Proc_LogProcEvent";

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                connection.QuerySingleOrDefault(
                                                  procedure,
                                                  param: new
                                                  {
                                                      p_company = process.company,
                                                      p_proc_name = process.procName,
                                                      p_params = process.parameters,
                                                      p_result = process.result,
                                                      p_error_msg = process.errorMsg,
                                                      p_begin_time = process.beginTime,
                                                      p_end_time = process.endTime,
                                                      p_created_user = process.createdUser
                                                  },
                                                    commandType: CommandType.StoredProcedure
                                                  );
            }
        }


        public void SaveLoginLog(LoginEvent login)
        {
            var procedure = "dblog.Proc_LogLoginEvent";

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                connection.QuerySingleOrDefault(
                                                  procedure,
                                                  param: new
                                                  {
                                                      p_username = login.username,
                                                      p_cat_login_method = login.loginMethod,
                                                      p_browser = login.browser,
                                                      p_ip = login.ipAddress,
                                                      p_longitude = login.longitude,
                                                      p_latitude = login.longitude,                                                      
                                                      p_created_user = login.createdUser,
                                                      p_company = login.company
                                                  },
                                                    commandType: CommandType.StoredProcedure
                                                  );
            }
        }
    }

}
