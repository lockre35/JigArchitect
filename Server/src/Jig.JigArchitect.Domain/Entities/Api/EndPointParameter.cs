// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class EndPointParameter
	{
		public int EndPointParameterId { get; set; }
		public string DataType { get; set; }
		public string EndPointParameterName { get; set; }
		public int ParametersEndPointId { get; set; }
		public int? DataSourceId { get; set; }
		public virtual EndPoint Parameters { get; set; }
		public virtual DataSource DataSource { get; set; }
		
	}
	
	
}