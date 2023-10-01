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
    public class CategoryController : ControllerBase
    {
        private ICategoryBusiness _cBusiness;
        public CategoryController(ICategoryBusiness cBusiness)
        {
            _cBusiness = cBusiness;
        }

        [AllowAnonymous]
        [Route("get-all")]
        [HttpGet]
        public IActionResult GetDataById()
        {
            var dt = _cBusiness.GetAll().Select(x => new { x.categoryId,  x.name, x.description });
            return Ok(dt);
        }

    }
}
