using API.Hubs;
using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotificationBusiness _nBusiness;
        private readonly IHubContext<SignalrHub> _hubContext;
        public NotificationController(INotificationBusiness nBusiness, IHubContext<SignalrHub> hubContext)
        {
            _nBusiness = nBusiness;
            _hubContext = hubContext;
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<ActionResult<List<NotificationModel>>> GetAll()
        {
            var dt = _nBusiness.GetAll();
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", dt);
            return Ok(dt);
        }



        [Route("get-by-id/{id}")]
        [HttpGet]
        public async Task<NotificationModel> GetDataById( string id )
        {
            var dt = _nBusiness.GetDataById(id);
           // await _hubContext.Clients.All.SendAsync("ReceiveDataById", dt);
            return dt;
        }


        [HttpDelete("delete-notify")]
        public async Task<IActionResult> Delete(string id)
        {
            _nBusiness.Delete(id);
            var dt = _nBusiness.GetAll();
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", dt);
            return Ok(new { message = "xoas thanh cong" });
        }


        [Route("get-notyfication")]
        [HttpPost]
        public async  Task<IActionResult> GetNotification([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());

                long total = 0;
                var data = _nBusiness.GetNotification(page, pageSize, out total);

                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
