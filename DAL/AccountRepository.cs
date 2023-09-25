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
    public class AccountRepository : IAccountRepository
    {
        private IDatabaseHelper _db;

        public AccountRepository(IDatabaseHelper db)
        {
            _db = db;
        }




        public List< AccountModel > GetAll()
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteQuery( "sp_get_account");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<AccountModel>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public AccountModel GetDataByAccount(string username, string password)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "sp_get_account_by_username",
                    "@username", username,
                    "@password", password);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<AccountModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AccountModel GetDataById(string id)
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
                return data.ConvertTo<AccountModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public bool Create(AccountModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_account_create",
                "@userName", model.username,
                "@password", model.password,
                "@phoneNumber", model.phoneNumber,
                "@email", model.email,
                "@typeId", model.typeId);
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

        public bool Update(AccountModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_account_update",
                "@id", model.accountId,
                "@userName", model.username,
                "@password", model.password,
                "@phoneNumber", model.phoneNumber,
                "@email", model.email,
                "@typeId", model.typeId);
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
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_account_delete",
                "@id", id);
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
