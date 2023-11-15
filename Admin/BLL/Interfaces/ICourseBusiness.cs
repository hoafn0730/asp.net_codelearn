using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICourseBusiness
    {
        CourseModel GetDataById(string id);

        bool Create(CourseModel model);
        bool Update(CourseModel model);
        bool Delete(string id);

        List<CourseModel> GetCourse(
           int pageIndex,
           int pageSize,
           out long total,
           string name);

        List<CourseStatiѕticModel> Search(
            int pageIndex,
            int pageSize,
            out long total,
            string name,
            DateTime? fr_RegistrationDate,
            DateTime? to_RegistrationDate);

        List<CourseStatiѕticModel> StatisticRevenue(
            int pageIndex,
            int pageSize,
            out long total,
            out long revenue,
            string month,
            string year);
    }
}
