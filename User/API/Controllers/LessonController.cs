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
    public class LessonController : ControllerBase
    {
        private ILessonBusiness _lBusiness;
        public LessonController(ILessonBusiness lBusiness)
        {
            _lBusiness = lBusiness;
        }

        [HttpGet("get-by-id")]
        public IActionResult GetDataById(string id)
        {
            var dt = _lBusiness.GetDataById(id);
            return Ok(dt);
        }




    }
}
