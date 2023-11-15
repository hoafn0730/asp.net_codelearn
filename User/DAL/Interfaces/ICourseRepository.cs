using DataModel;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICourseRepository
    {
        CourseModel GetDataById(string id);

        List<CourseModel> Search(
            int pageIndex,
            int pageSize,
            out long total,
            string name
        );

        List<CourseModel> GetDataByUserId(string id);

        public HomeModel GetHome();

    }
}
