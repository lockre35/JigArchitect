using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Models
{
    
    public class EntityModel
    {
        public string Name { get; set; } 
        
        public int EntityId { get; set; } 
        
        public string SchemaName { get; set; } 
        
        public List<SchemaEntityModel> SchemaEntities { get; set; } 
    }
}