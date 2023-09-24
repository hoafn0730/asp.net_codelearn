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
        public Account GetDataById(int id)
        {
            return _res.GetDataById(id);
        }

        public bool Create(Account model)
        {
            return _res.Create(model);
        }

        public bool Update(Account model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
    }
}
