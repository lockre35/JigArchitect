// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class EnumPropertyValue
	{
		public int EnumPropertyValueId { get; set; }
		[Required]
		public string Name { get; set; }
		public int EnumPropertyId { get; set; }
		public virtual EnumProperty EnumProperty { get; set; }
		
	}
	
	
}