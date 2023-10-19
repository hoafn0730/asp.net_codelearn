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
    public class ParticipationRepository : IParticipationRepository
    {
        private IDatabaseHelper _db;

        public ParticipationRepository(IDatabaseHelper db)
        {
            _db = db;
        }

        public ParticipationModel GetDataById(string id)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "sp_get_Participation_by_id", 
                    "@id", 
                    id);
                if (!string.IsNullOrEmpty(msgError)) 
                    throw new Exception(msgError);
                return data.ConvertTo<ParticipationModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Create(ParticipationModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_create_Participation",
                "@CourseId", model.CourseId,
                "@UserId", model.UserId
                );


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

        public bool Update(ParticipationModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_update_Participation",
                    "@ParticipationId", model.ParticipationId,
                "@CourseId", model.CourseId,
                "@UserId", model.UserId
                );


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
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_Participation",
                "@ParticipationId", id);
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
