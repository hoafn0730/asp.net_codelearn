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
    public class NotificationBusiness : INotificationBusiness
    {
        private INotificationRepository _res;
        public NotificationBusiness(INotificationRepository res)
        {
            _res = res;
        }

        public NotificationModel GetDataById(string id)
        {
            return _res.GetDataById(id);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }


    }
}
