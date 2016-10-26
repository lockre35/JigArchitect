// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class DataSource
	{
		public int DataSourceId { get; set; }
		public int? EntityPropertyPropertyId { get; set; }
		public int? DataSourceRelationId { get; set; }
		public virtual Property EntityProperty { get; set; }
		public virtual DataSourceRelation DataSourceRelation { get; set; }
		
	}
	
	
}