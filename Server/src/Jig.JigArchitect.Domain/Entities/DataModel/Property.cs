// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class Property
	{
		public int PropertyId { get; set; }
		[Required]
		public string Name { get; set; }
		public virtual PropertyType PropertyType { get; set; }
		public int EntityId { get; set; }
		public virtual IntProperty IntProperty { get; set; }
		public virtual EnumProperty EnumProperty { get; set; }
		public virtual Entity Entity { get; set; }
		
	}
	
	
	public enum PropertyType
	{
		EnumType,
		String
	}
}