using System;
using System.Collections.Generic;

namespace Application_outlet.Business.Models
{
    public class UserLogin
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
