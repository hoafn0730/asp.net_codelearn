using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HomeModel
    {
        public List<CourseModel> list_json_PopularCourses { get; set; }
        public List<CourseModel> list_json_FreeCourses { get; set; }
        public List<CourseModel> list_json_ProCourses { get; set; }
        public List<CourseModel> list_json_NewCourses { get; set; }

        public string Category { get; set; }
        public List<CourseModel> list_json_Courses { get; set; }

    }
}
