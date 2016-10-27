using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Models
{
    
    public class EditEndPointDefaultPropertyInputModel
    {
        public string DataType { get; set; } 
        
        public int EndPointPropertyId { get; set; } 
    }
}