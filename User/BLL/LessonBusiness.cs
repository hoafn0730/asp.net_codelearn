using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LessonBusiness : ILessonBusiness
    {
        private ILessonRepository _res;
        public LessonBusiness(ILessonRepository res)
        {
            _res = res;
        }


        public LessonModel GetDataById(string id)
        {
            return _res.GetDataById(id);
        }



    }
}
