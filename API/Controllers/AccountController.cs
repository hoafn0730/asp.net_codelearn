using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountBusiness _accBusiness;
        public AccountController(IAccountBusiness accBusiness)
        {
            _accBusiness = accBusiness;
        }

        [Route("get-all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var dt = _accBusiness.GetAll().Select(x => new { x.accountId, x.username, x.password });
            return Ok(dt);
        }

        [Route("get-by-id")]
        [HttpGet]
        public AccountModel GetDataById( string id )
        {
            var dt = _accBusiness.GetDataById(id);
            return dt;
        }

        [Route("get-by-username")]
        [HttpGet]
        public AccountModel GetDataByAccount(string username, string password)
        {
            var dt = _accBusiness.GetDataByAccount(username, password);
            return dt;
        }

        [Route("create-account")]
        [HttpPost]
        public AccountModel CreateItem([FromBody] AccountModel model)
        {
            _accBusiness.Create(model);
            return model;
        }

        [Route("update-account")]
        [HttpPost]
        public AccountModel UpdateItem([FromBody] AccountModel model)
        {
            _accBusiness.Update(model);
            return model;
        }

        [Route("delete-account")]
        [HttpPost]
        public IActionResult DeleteItem(string id)
        {
            _accBusiness.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }

    }
}
