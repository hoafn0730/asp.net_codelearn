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
    public class UserRepository : IUserRepository
    {
        private IDatabaseHelper _db;

        public UserRepository(IDatabaseHelper db)
        {
            _db = db;
        }

        public UserModel GetDataById(string id)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "sp_get_user_by_id", 
                    "@id", 
                    id);
                if (!string.IsNullOrEmpty(msgError)) 
                    throw new Exception(msgError);
                return data.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(UserModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_user_update",
                "@id", model.userId,
                "@name", model.name,
                "@avatar", model.avatar,
                "@banner", model.banner,
                "@bio", model.bio);

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

        public List<UserModel> Search(int pageIndex, int pageSize, out long total, string name)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_user",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@name", name);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<UserModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
