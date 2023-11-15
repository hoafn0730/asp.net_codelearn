using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CourseBusiness : ICourseBusiness
    {
        private ICourseRepository _res;
        public CourseBusiness(ICourseRepository res)
        {
            _res = res;
        }

        public CourseModel GetDataById(string id) => _res.GetDataById(id);
        public List<CourseModel> GetDataByUserId(string id) => _res.GetDataByUserId(id);

        public List<CourseModel> Search(
            int pageIndex,
            int pageSize,
            out long total,
            string name
        ) => _res.Search(pageIndex, pageSize, out total, name);


        public HomeModel GetHome() => _res.GetHome();

    }
}
