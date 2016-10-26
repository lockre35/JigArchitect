// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class EndPointCollectionProperty
	{
		public int EndPointCollectionPropertyId { get; set; }
		public int? PropertiesEndPointPropertyId { get; set; }
		public int EndPointPropertyId { get; set; }
		public virtual EndPointProperty Properties { get; set; }
		public virtual EndPointProperty EndPointProperty { get; set; }
		
	}
	
	
}