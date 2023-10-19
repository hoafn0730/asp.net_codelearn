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
    public class ParticipationController : ControllerBase
    {
        private IParticipationBusiness _pBusiness;
        public ParticipationController(IParticipationBusiness pBusiness)
        {
            _pBusiness = pBusiness;
        }

        [HttpGet("get-by-id")]
        public IActionResult GetDataById(string id)
        {
            var dt = _pBusiness.GetDataById(id);
            return Ok(dt);
        }

        [HttpPost("create-participation")]
        public ParticipationModel CreateItem([FromBody] ParticipationModel model)
        {
            _pBusiness.Create(model);
            return model;
        }

        [HttpPut("update-participation")]
        public ParticipationModel UpdateItem([FromBody] ParticipationModel model)
        {
            _pBusiness.Update(model);
            return model;
        }

        [HttpDelete("delete-participation")]
        public IActionResult DeleteItem(string id)
        {
            _pBusiness.Delate(id);
            return Ok(new {message = "Xoa thanh cong!"});
        }

    }
}
