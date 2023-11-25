using DataModel;

namespace API.Hubs.Interfaces
{
    public interface ISignalrHub
    {
        Task<List<NotificationModel>> GetAll();
    }
}
