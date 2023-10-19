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
    public class CommentController : ControllerBase
    {
        private ICommentBusiness _cBusiness;
        public CommentController(ICommentBusiness cBusiness)
        {
            _cBusiness = cBusiness;
        }




        [HttpPost("create-comment")]
        public CommentModel CreateItem([FromBody] CommentModel model)
        {
            _cBusiness.Create(model);
            return model;
        }


        [HttpPatch("update-comment")]
        public CommentModel UpdateItem([FromBody] CommentModel model)
        {
            _cBusiness.Update(model);
            return model;
        }


        [HttpDelete("delete-comment")]
        public IActionResult DeleteItem(string id)
        {
            _cBusiness.Delete(id);
            return Ok(new { message = "Xóa thành công" });
        }

        

    }
}
