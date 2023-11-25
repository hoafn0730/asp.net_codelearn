using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INotificationRepository
    {

        List<NotificationModel> GetAll();
        NotificationModel GetDataById(string id);
        bool Delete(string id);

        List<NotificationModel> GetNotification(
            int pageIndex,
            int pageSize,
            out long total
        );


    }
}
