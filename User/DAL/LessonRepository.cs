using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LessonRepository : ILessonRepository
    {
        private IDatabaseHelper _db;

        public LessonRepository(IDatabaseHelper db)
        {
            _db = db;
        }


        public LessonModel GetDataById(string id)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "sp_get_Lesson_by_id",
                    "@id",
                    id);
                if (!string.IsNullOrEmpty(msgError)) 
                    throw new Exception(msgError);
                return data.ConvertTo<LessonModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
