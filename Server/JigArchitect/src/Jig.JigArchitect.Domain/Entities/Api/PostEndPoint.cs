// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class PostEndPoint
	{
		public int PostEndPointId { get; set; }
		public int EndPointId { get; set; }
		public int? InputModelEndPointModelId { get; set; }
		public virtual EndPoint EndPoint { get; set; }
		public virtual EndPointModel InputModel { get; set; }
		
	}
	
	
}