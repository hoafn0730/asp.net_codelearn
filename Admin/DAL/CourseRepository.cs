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
                    "sp_get_course_by_id",
                    "@CourseId",
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

        public bool Create(CourseModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_courses",
                "@name", model.NameCourse,
                "@description", model.Description,
                "@level", model.Level,
                "@price", model.Price,
                "@slug", model.Slug,
                "@categoryId", model.CategoryId,
                "@teacherId", model.TeacherId,
                "@list_json_Lessons", model.list_json_Lessons != null ? MessageConvert.SerializeObject(model.list_json_Lessons) : null);

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(CourseModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_course",
                "@CourseId", model.CourseId,
                "@NameCourse", model.NameCourse,
                "@Description", model.Description,
                "@Image", model.Image,
                "@Level", model.Level,
                "@Price", model.Price,
                "@Slug", model.Slug,
                "@list_json_Lessons", model.list_json_Lessons != null ? MessageConvert.SerializeObject(model.list_json_Lessons) : null);

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_course",
                "@CourseId", id);
                ;
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CourseStatiѕticModel> Search(
            int pageIndex,
            int pageSize,
            out long total,
            string name,
            DateTime? fr_RegistrationDate,
            DateTime? to_RegistrationDate)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_statiѕtic_course",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@Name", name,
                    "@fr_RegistrationDate", fr_RegistrationDate,
                    "@to_RegistrationDate", to_RegistrationDate
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<CourseStatiѕticModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseStatiѕticModel> StatisticRevenue(
            int pageIndex,
            int pageSize,
            out long total,
            out long revenue,
            string month,
            string year )
        {
            string msgError = "";
            total = 0;
            revenue = 0;

            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_statistic_revenue",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@month", month,
                    "@year", year
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                if (dt.Rows.Count > 0) revenue = (long)dt.Rows[0]["Revenue"];

                return dt.ConvertTo<CourseStatiѕticModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
