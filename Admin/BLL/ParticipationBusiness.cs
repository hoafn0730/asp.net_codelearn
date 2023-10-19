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
    public class ParticipationBusiness : IParticipationBusiness
    {
        private IParticipationRepository _res;
        public ParticipationBusiness(IParticipationRepository res)
        {
            _res = res;
        }


        public ParticipationModel GetDataById(string id)
        {
            return _res.GetDataById(id);
        }

        public bool Create(ParticipationModel model) => _res.Create(model);
        public bool Update(ParticipationModel model) => _res.Update(model);
        public bool Delate(string id) => _res.Delete(id);



    }
}
