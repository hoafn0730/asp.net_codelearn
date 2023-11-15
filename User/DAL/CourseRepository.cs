using DAL.Interfaces;
using DataModel;
using DataAccessLayer;
using Models;

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

        public List<CourseModel> GetDataByUserId(string id)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "sp_get_course_by_userid",
                    "@UserId",
                    id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<CourseModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseModel> Search (
            int pageIndex,
            int pageSize,
            out long total,
            string name
        )
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_course",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@Name", name
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<CourseModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HomeModel GetHome()
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "sp_get_course_user");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<HomeModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
