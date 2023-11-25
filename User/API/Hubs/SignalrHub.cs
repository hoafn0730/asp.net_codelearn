using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;

namespace API.Hubs
{
    [EnableCors("AllowSpecificOrigin")]
    public class SignalrHub : Hub
    {
        private INotificationRepository _res;
        public SignalrHub(INotificationRepository res)
        {
            _res = res;
        }

        public async Task<List< NotificationModel >> GetAll()
        {
            var result = _res.GetAll();

            await Clients.All.SendAsync("ReceiveNotification", result);

            return result;
        }
    }
}
