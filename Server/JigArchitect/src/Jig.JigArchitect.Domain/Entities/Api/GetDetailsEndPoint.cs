// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class GetDetailsEndPoint
	{
		public int GetDetailsEndPointId { get; set; }
		public int EndPointId { get; set; }
		public virtual EndPoint EndPoint { get; set; }
		
	}
	
	
}