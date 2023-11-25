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
    public class CommentBusiness : ICommentBusiness
    { 
        private ICommentRepository _res;
        public CommentBusiness(ICommentRepository res)
        {
            _res = res;
        }


        public List<CommentModel> GetDataById(string id) => _res.GetDataById(id);
        public bool Create(CommentModel model) =>  _res.Create(model);

        public bool Update(CommentModel model) =>  _res.Update(model);

        public bool Delete(string id) => _res.Delete(id);




    }
}
