// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class Entity
	{
		public int EntityId { get; set; }
		[Required]
		public string Name { get; set; }
		public string PluralName { get; set; }
		public int SchemaId { get; set; }
		public virtual ICollection<Property> Properties { get; set; }
		public virtual ICollection<Relationship> ParentRelationships { get; set; }
		public virtual ICollection<Relationship> ChildrenRelationships { get; set; }
		public virtual ICollection<EndPointProperty> EndPointProperties { get; set; }
		public virtual Schema Schema { get; set; }
		
	}
	
	
}