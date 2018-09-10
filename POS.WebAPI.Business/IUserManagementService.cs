using POS.WebAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS.WebAPI.Business
{
    public interface IUserManagementService
    {
        int CreateUserAccount(UserAccount user);
        UserAccount GetUserDetailById(UserAccount user);
        UserAccount AuthenticateUser(UserAccount user);
        bool UpdateUserDetail(UserAccount user);
        bool UpdateUserPassword(UserAccount user);   
        IEnumerable<Company> GetCompanyByUser(UserAccount user);
    }
}
