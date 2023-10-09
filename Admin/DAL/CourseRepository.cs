using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CourseRepository : ICourseRepository
    {
        private IDatabaseHelper _db;

        public CourseRepository(IDatabaseHelper db)
        {
            _db = db;
        }


        public CourseModel GetDataById(string id)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError, 
                    "sp_get_account_by_id", 
                    "@id", 
                    id);
                if (!string.IsNullOrEmpty(msgError)) 
                    throw new Exception(msgError);
                return data.ConvertTo<CourseModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
