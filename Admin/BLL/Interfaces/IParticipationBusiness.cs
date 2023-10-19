using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IParticipationBusiness
    {
        ParticipationModel GetDataById(string id);
        bool Create(ParticipationModel model);
        bool Update(ParticipationModel model);
        bool Delate(string id);
    }
}
