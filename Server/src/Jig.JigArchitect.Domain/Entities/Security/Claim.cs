using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jig.JigArchitect.Domain.Entities
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<LoginClaim> LoginClaims { get; set; }
    }
}
