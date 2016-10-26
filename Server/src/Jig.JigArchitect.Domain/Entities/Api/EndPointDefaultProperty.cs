// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class EndPointDefaultProperty
	{
		public int EndPointDefaultPropertyId { get; set; }
		public string DataType { get; set; }
		public int EndPointPropertyId { get; set; }
		public virtual EndPointProperty EndPointProperty { get; set; }
		
	}
	
	
}