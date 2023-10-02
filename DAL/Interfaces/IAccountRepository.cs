using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAccountRepository
    {

        AccountModel Login(string username, string password);
        List<AccountModel> GetAll();
        AccountModel GetDataById(string id);
        bool Create(AccountModel model, string name);
        bool Update(AccountModel model);
        bool Delete(string id);

    }
}
