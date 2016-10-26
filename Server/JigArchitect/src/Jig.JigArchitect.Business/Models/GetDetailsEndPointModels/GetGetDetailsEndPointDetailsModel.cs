using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Models
{
    
    public class GetGetDetailsEndPointDetailsModel
    {
        public int GetDetailsEndPointId { get; set; } 
        
        public int EndPointId { get; set; } 
    }
}