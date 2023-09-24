using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAccountRepository
    {

        Account GetDataById( int id );

        bool Create(Account model);

        bool Update(Account model);

        bool Delete(string id);

    }
}
