using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ICourseBusiness _courseBusiness;
        public HomeController(ICourseBusiness courseBusiness)
        {
            _courseBusiness = courseBusiness;
        }


        [HttpGet("get-home")]
        public HomeModel GetHome() => _courseBusiness.GetHome();

    }
}
