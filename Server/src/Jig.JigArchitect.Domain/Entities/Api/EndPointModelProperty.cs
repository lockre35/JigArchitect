// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class EndPointModelProperty
	{
		public int EndPointModelPropertyId { get; set; }
		public int EndPointModelId { get; set; }
		public int EndPointPropertyId { get; set; }
		public virtual EndPointModel EndPointModel { get; set; }
		public virtual EndPointProperty EndPointProperty { get; set; }
		
	}
	
	
}