using BLL;
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
    public class CommentController : ControllerBase
    {
        private ICommentBusiness _cBusiness;
        public CommentController(ICommentBusiness cBusiness)
        {
            _cBusiness = cBusiness;
        }


        [AllowAnonymous]
        [HttpGet("get-by-id")]
        public async Task< List<CommentModel> > GetDataById(string id) => _cBusiness.GetDataById(id);


        [HttpPost("create-comment")]
        public async Task< CommentModel > CreateItem([FromBody] CommentModel model)
        {
            _cBusiness.Create(model);
            return model;
        }


        [HttpPatch("update-comment")]
        public async Task<CommentModel> UpdateItem([FromBody] CommentModel model)
        {
            _cBusiness.Update(model);
            return model;
        }


        [HttpDelete("delete-comment")]
        public async Task< IActionResult > DeleteItem(string id)
        {
            _cBusiness.Delete(id);
            return Ok(new { message = "Xóa thành công" });
        }

        

    }
}
