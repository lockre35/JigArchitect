// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class Schema
	{
		[Required]
		public string Name { get; set; }
		public int SchemaId { get; set; }
		public virtual ICollection<Entity> Entities { get; set; }
		
	}
	
	
}