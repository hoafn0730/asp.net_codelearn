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
    public class CourseController : ControllerBase
    {
        private ICourseBusiness _courseBusiness;
        public CourseController(ICourseBusiness courseBusiness)
        {
            _courseBusiness = courseBusiness;
        }



        [HttpGet("get-by-id")]
        public CourseModel GetDataById( string id ) => _courseBusiness.GetDataById(id);

        [HttpPost("create-course")]
        public CourseModel CreateItem([FromBody] CourseModel model)
        {
            _courseBusiness.Create(model);
            return model;
        }


    }
}
