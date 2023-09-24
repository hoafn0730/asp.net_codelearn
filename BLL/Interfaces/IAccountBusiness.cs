using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountBusiness
    {
        Account GetDataById(int id);

        bool Create(Account model);

        bool Update(Account model);

        bool Delete(string id);
    }
}
