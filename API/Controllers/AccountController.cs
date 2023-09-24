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

        [Route("get-by-id")]
        [HttpGet]
        public Account GetDataById( int id )
        {
            var dt = _accBusiness.GetDataById(id);
            return dt;
        }

        [Route("create-account")]
        [HttpPost]
        public Account CreateItem([FromBody] Account model)
        {
            _accBusiness.Create(model);
            return model;
        }

        [Route("update-account")]
        [HttpPost]
        public Account UpdateItem([FromBody] Account model)
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
