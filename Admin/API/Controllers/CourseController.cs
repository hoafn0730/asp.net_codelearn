using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());

                string name = "";
                if (formData.Keys.Contains("name") && !string.IsNullOrEmpty(Convert.ToString(formData["name"])))
                { name = Convert.ToString(formData["name"]); }

                DateTime? fr_RegistrationDate = null;
                if (formData.Keys.Contains("fr_RegistrationDate") && formData["fr_RegistrationDate"] != null && 
                    formData["fr_RegistrationDate"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["fr_NgayTao"].ToString());
                    fr_RegistrationDate = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                }

                DateTime? to_RegistrationDate = null;
                if (formData.Keys.Contains("to_RegistrationDate") && formData["to_RegistrationDate"] != null && 
                    formData["to_RegistrationDate"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["to_RegistrationDate"].ToString());
                    to_RegistrationDate = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
                }

                long total = 0;
                var data = _courseBusiness.Search(page, pageSize, out total, name, fr_RegistrationDate, to_RegistrationDate);

                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("statistic-revenue")]
        [HttpPost]
        public IActionResult StatisticRevenue([FromBody] Dictionary<string, object> formData)
        {
            try
            {
 
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                
                string month = "";
                string year = "";
                long total = 0;
                long revenue = 0;

                if (formData.Keys.Contains("month") && !string.IsNullOrEmpty(Convert.ToString(formData["month"])))
                { month = Convert.ToString(formData["month"]); }

                if (formData.Keys.Contains("year") && !string.IsNullOrEmpty(Convert.ToString(formData["year"])))
                { year = Convert.ToString(formData["year"]); }
                


                var data = _courseBusiness.StatisticRevenue(page,  pageSize,out total,out revenue,  month,  year);

                return Ok(
                    new
                    {
                        TotalItems = total,
                        Revenue = revenue,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
