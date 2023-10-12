using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class NotificationModel
    {
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
