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
    }
}
