using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Models
{
    
    public class GetPropertyIntPropertyModel
    {
        public int IntPropertyId { get; set; } 
        
        public int MaxValue { get; set; } 
        
        public int MinValue { get; set; } 
        
        public int PropertyId { get; set; } 
    }
}