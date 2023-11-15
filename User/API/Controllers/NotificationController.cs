using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
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

        [HttpDelete("delete-notify")]
        public IActionResult Delete(string id)
        {
            var dt = _nBusiness.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }


        [Route("get-notyfication")]
        [HttpPost]
        public IActionResult GetNotification([FromBody] Dictionary<string, object> formData)
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
