using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Models
{
    
    public class CreateApplicationInputModel
    {
        public string Name { get; set; } 
        
        public string Icon { get; set; } 
        
        public string Description { get; set; } 
    }
}