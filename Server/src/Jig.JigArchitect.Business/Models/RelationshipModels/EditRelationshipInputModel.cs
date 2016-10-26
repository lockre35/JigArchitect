using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Models
{
    
    public class EditRelationshipInputModel
    {
        public RelationshipType RelationshipType { get; set; } 
        
        public int ParentEntityEntityId { get; set; } 
        
        public int ChildEntityEntityId { get; set; } 
    }
}