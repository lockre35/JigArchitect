// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class IntProperty
	{
		public int IntPropertyId { get; set; }
		public int MaxValue { get; set; }
		public int MinValue { get; set; }
		public int PropertyId { get; set; }
		public virtual Property Property { get; set; }
		
	}
	
	
}