using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INotificationBusiness
    {
        NotificationModel GetDataById(string id);

        bool Delete(string id);

        public List<NotificationModel> GetNotification(
            int pageIndex,
            int pageSize,
            out long total
        );


    }
}
