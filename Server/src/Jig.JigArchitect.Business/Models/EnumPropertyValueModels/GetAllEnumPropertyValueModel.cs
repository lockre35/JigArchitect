using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Models
{
    
    public class GetAllEnumPropertyValueModel
    {
        public int EnumPropertyValueId { get; set; } 
        
        public string Name { get; set; } 
        
        public int EnumPropertyId { get; set; } 
    }
}