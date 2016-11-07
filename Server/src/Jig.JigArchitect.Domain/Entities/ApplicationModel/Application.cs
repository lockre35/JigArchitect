// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class Application
	{
		public int ApplicationId { get; set; }
		[Required]
		public string Name { get; set; }
		public string Icon { get; set; }
		public string Description { get; set; }
		public virtual ICollection<Schema> Schemas { get; set; }
		public virtual ICollection<Service> Services { get; set; }
		
	}
	
	
}