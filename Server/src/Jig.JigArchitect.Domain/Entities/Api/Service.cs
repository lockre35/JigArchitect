// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class Service
	{
		public int ServiceId { get; set; }
		public string Name { get; set; }
		public string PluralName { get; set; }
		public int ApplicationId { get; set; }
		public virtual ICollection<EndPoint> EndPoints { get; set; }
		public virtual Application Application { get; set; }
		
	}
	
	
}