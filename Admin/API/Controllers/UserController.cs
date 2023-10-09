using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBusiness _uBusiness;
        public UserController(IUserBusiness cBusiness)
        {
            _uBusiness = cBusiness;
        }

        [HttpGet("get-by-id")]
        public IActionResult GetDataById(string id)
        {
            var dt = _uBusiness.GetDataById(id);
            return Ok(dt);
        }


        [HttpPut("update-user")]
        public UserModel UpdateItem([FromBody] UserModel model)
        {
            _uBusiness.Update(model);
            return model;
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string name = "";
                if (formData.Keys.Contains("Name") && !string.IsNullOrEmpty(Convert.ToString(formData["Name"]))) { name = Convert.ToString(formData["Name"]); }
               
                long total = 0;
                var data = _uBusiness.Search(page, pageSize, out total, name);
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
