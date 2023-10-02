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
    public class CategoryController : ControllerBase
    {
        private ICategoryBusiness _cBusiness;
        public CategoryController(ICategoryBusiness cBusiness)
        {
            _cBusiness = cBusiness;
        }

        [AllowAnonymous]
        [HttpGet("get-all")]
        public IActionResult GetDataById()
        {
            var dt = _cBusiness.GetAll().Select(x => new { x.categoryId,  x.name, x.description });
            return Ok(dt);
        }

        [AllowAnonymous]
        [HttpPost("create-category")]
        public CategoryModel CreateItem([FromBody] CategoryModel model)
        {
            _cBusiness.Create(model);
            return model;
        }
        [AllowAnonymous]

        [HttpDelete("delete-category")]
        public IActionResult DeleteItem(string id)
        {
            _cBusiness.Delete(id);
            return Ok(new { message = "Xoas thanh cong!" });
        }

    }
}
