// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class EndPointModel
	{
		public int EndPointModelId { get; set; }
		public string Name { get; set; }
		public int? EntityId { get; set; }
		public virtual EndPoint EndPoint { get; set; }
		public virtual ICollection<EndPointModelProperty> EndPointModelProperties { get; set; }
		public virtual Entity Entity { get; set; }
		
	}
	
	
}