using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jig.JigArchitect.Domain.Entities
{
    public class LoginClaim
    {   
        public int LoginClaimId { get; set; }
        public int LoginId { get; set; }
        public Login Login { get; set; }

        public int ClaimId { get; set; }
        public Claim Claim { get; set; }
    }
}
