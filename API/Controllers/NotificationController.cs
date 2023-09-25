using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotificationBusiness _nBusiness;
        public NotificationController(INotificationBusiness nBusiness)
        {
            _nBusiness = nBusiness;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public NotificationModel GetDataById( string id )
        {
            var dt = _nBusiness.GetDataById(id);
            return dt;
        }

    }
}
