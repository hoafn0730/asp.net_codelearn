using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AccountModel
    {
        public int accountId { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? phoneNumber { get; set; }
        public string? email { get; set; }
        public string? typeId { get; set; }
    }
}
