using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AccountModel
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TypeId { get; set; }
        public string? token { get; set; }
    }

}
