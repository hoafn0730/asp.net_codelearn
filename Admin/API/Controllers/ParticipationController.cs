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

    }
}
