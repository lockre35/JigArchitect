using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Models
{
    
    public class CreateEnumPropertyInputModel
    {
        public string Name { get; set; } 
        
        public int PropertyId { get; set; } 
        
        public CreateEnumPropertyPropertyInputModel Property { get; set; } 
    }
}