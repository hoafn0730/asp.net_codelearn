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
        public CourseModel GetDataById(string id) => _courseBusiness.GetDataById(id);


        [HttpPost("create-course")]
        public CourseModel CreateItem([FromBody] CourseModel model)
        {
            _courseBusiness.Create(model);
            return model;
        }


        [HttpPatch("update-course")]
        public CourseModel UpdateItem([FromBody] CourseModel model)
        {
            _courseBusiness.Update(model);
            return model;
        }


        [HttpDelete("delete-course")]
        public IActionResult DeleteItem(string id)
        {
            _courseBusiness.Delete(id);
            return Ok(new { message = "Xóa thành công" });
        }

        

    }
}
