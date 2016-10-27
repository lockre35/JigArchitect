// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class EnumProperty
	{
		public int EnumPropertyId { get; set; }
		[Required]
		public string Name { get; set; }
		public int PropertyId { get; set; }
		public virtual ICollection<EnumPropertyValue> EnumPropertyValues { get; set; }
		public virtual Property Property { get; set; }
		
	}
	
	
}