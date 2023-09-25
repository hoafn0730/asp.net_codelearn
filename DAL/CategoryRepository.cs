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
    public class CategoryRepository : ICategoryRepository
    {
        private IDatabaseHelper _db;

        public CategoryRepository(IDatabaseHelper db)
        {
            _db = db;
        }



        public List<CategoryModel> GetAll()
        {

            try
            {
                var data = _db.ExecuteQuery( "sp_get_all_categories" );

                return data.ConvertTo<CategoryModel>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
