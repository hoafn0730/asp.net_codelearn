using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NotificationRepository : INotificationRepository
    {
        private IDatabaseHelper _db;

        public NotificationRepository(IDatabaseHelper db)
        {
            _db = db;
        }



        public NotificationModel GetDataById(string id)
        {

            try
            {
                var data = _db.ExecuteQuery(
                    "sp_get_notification_by_id @id", new object[] { id });

                return data.ConvertTo<NotificationModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
