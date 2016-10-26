// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class Relationship
	{
		public int RelationshipId { get; set; }
		public virtual RelationshipType RelationshipType { get; set; }
		public int ParentEntityEntityId { get; set; }
		public int ChildEntityEntityId { get; set; }
		public virtual Entity ParentEntity { get; set; }
		public virtual Entity ChildEntity { get; set; }
		
	}
	
	
	public enum RelationshipType
	{
		OneToOne,
		OneToMany
	}
}