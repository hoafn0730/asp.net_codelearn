using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountBusiness _accBusiness;
        public AccountController(IAccountBusiness accBusiness)
        {
            _accBusiness = accBusiness;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _accBusiness.Login(model.username, model.password);
            if (user == null) return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = user.username, Email = user.email, token = user.token });
        }


        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _accBusiness.GetAll().Select(x => new { x.accountId, x.password ,x.username });
            return Ok(dt);
        }


        [HttpGet("get-by-id")]
        public AccountModel GetDataById( string id )
        {
            var dt = _accBusiness.GetDataById(id);
            return dt;
        }


        [AllowAnonymous]
        [HttpPost("create-account")]
        public AccountModel CreateItem([FromBody] AccountModel model)
        {
            _accBusiness.Create(model);
            return model;
        }

        [HttpPut("update-account")]
        public AccountModel UpdateItem([FromBody] AccountModel model)
        {
            _accBusiness.Update(model);
            return model;
        }


        [HttpDelete("delete-account")]
        public IActionResult DeleteItem(string id)
        {
            _accBusiness.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }

    }
}
