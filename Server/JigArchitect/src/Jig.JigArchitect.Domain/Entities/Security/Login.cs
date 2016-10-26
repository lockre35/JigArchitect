using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jig.JigArchitect.Domain.Entities
{
    public class Login
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<LoginClaim> LoginClaims { get; set; }
    }
}
