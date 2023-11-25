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
        public async Task<IActionResult> Login([FromBody] AuthenticateModel model)
        {
            var user = _accBusiness.Login(model.Username, model.Password);
            if (user == null) return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { accountId = user.AccountId, userName = user.UserName, roleId = user.TypeId,  Email = user.Email, token = user.token });
        }


        [HttpGet("get-by-id")]
        public async Task<AccountModel> GetDataById( string id )
        {
            var dt = _accBusiness.GetDataById(id);
            return dt;
        }


        [AllowAnonymous]
        [HttpPost("create-account")]
        public async Task<AccountModel> CreateItem([FromBody] AccountModel model, string name)
        {
            _accBusiness.Create(model, name);
            return model;
        }

        [HttpPut("update-account")]
        public async Task<AccountModel> UpdateItem([FromBody] AccountModel model)
        {
            _accBusiness.Update(model);
            return model;
        }


        [HttpDelete("delete-account")]
        public async Task<IActionResult> DeleteItem(string id)
        {
            _accBusiness.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }

    }
}
