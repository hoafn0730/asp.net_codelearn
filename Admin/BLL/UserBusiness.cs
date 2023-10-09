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
    public class UserBusiness : IUserBusiness
    {
        private IUserRepository _res;
        public UserBusiness(IUserRepository res)
        {
            _res = res;
        }


        public UserModel GetDataById(string id)
        {
            return _res.GetDataById(id);
        }


        public bool Update(UserModel model)
        {
            return _res.Update(model);
        }

        public List<UserModel> Search(int pageIndex, int pageSize, out long total, string name)
        {
            return _res.Search(pageIndex, pageSize, out total, name);
        }

    }
}
