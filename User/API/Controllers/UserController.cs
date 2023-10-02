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

        [AllowAnonymous]
        [HttpPut("update-user")]
        public UserModel UpdateItem([FromBody] UserModel model)
        {
            _uBusiness.Update(model);
            return model;
        }


    }
}
