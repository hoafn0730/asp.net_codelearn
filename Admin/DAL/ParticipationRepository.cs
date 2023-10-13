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




    }
}
