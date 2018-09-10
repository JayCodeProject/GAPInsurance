using POS.WebAPI.Entity;
using System.Collections.Generic;

namespace POS.WebAPI.Business
{
    public interface IMenuService
    {
        IEnumerable<MenuItem> GetMenuItem(UserAccount user);
    }
}
