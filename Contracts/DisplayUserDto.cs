using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Contracts
{
    public class DisplayUserDto //created this to hide the password in the get and get all methods
    {
        public int Id { get; set; }
        public string UserRole { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }
    }
}
