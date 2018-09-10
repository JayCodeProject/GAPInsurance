using POS.WebAPI.Entity;
using POS.WebAPI.Infraestructure;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace POS.WebAPI.Data.Dapper
{
    public class MenuRepository
    {
        private IConnectionFactory _connectionFactory;

        public MenuRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<MenuItem> GetMenuItem(UserAccount user)
        {
            var procedure = "dbo.Proc_GetMenuItem";
            IEnumerable<MenuItem> menuItemList = null;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                menuItemList = connection.Query<MenuItem>(
                                                                  procedure,
                                                                  param: new
                                                                  {
                                                                      p_user_id = user.Id,
                                                                      p_created_user = user.CreatedUser
                                                                  },
                                                                   commandType: CommandType.StoredProcedure
                                                                  );
            }

            return menuItemList;
        }

    }
}
