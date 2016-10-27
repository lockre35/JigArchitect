using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Models
{
    
    public class CreateDataSourceRelationModel
    {
        public int DataSourceRelationId { get; set; } 
        
        public bool UseChildEntity { get; set; } 
        
        public int? RecursiveRelationDataSourceRelationId { get; set; } 
        
        public int? EntityRelationRelationshipId { get; set; } 
    }
}