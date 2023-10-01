using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoryBusiness
    {
        List<CategoryModel> GetAll();

        bool Create(CategoryModel model);

        bool Delete(string id);

    }
}
