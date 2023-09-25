using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountBusiness : IAccountBusiness
    {
        private IAccountRepository _res;
        public AccountBusiness(IAccountRepository res)
        {
            _res = res;
        }
        public List<AccountModel> GetAll()
        {
            return _res.GetAll();
        }

        public AccountModel GetDataByAccount(string username, string password)
        {
            return _res.GetDataByAccount(username, password);
        }

        public AccountModel GetDataById(string id)
        {
            return _res.GetDataById(id);
        }

        public bool Create(AccountModel model)
        {
            return _res.Create(model);
        }

        public bool Update(AccountModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
    }
}
