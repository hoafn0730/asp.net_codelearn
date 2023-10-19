using DAL.Interfaces;
using DataModel;
using DataAccessLayer;


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



    }
}
