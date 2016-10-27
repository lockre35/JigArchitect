using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Models
{
    
    public class GetAllEndPointModelModel
    {
        public int EndPointModelId { get; set; } 
        
        public string Name { get; set; } 
        
        public int? EntityId { get; set; } 
    }
}