using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class UserModel
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string? avatar { get; set; }
        public string? banner { get; set; }
        public string? bio { get; set; }
    }
}
