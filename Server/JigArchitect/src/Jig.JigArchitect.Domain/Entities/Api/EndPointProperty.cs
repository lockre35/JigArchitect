// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class EndPointProperty
	{
		public int EndPointPropertyId { get; set; }
		public string Name { get; set; }
		public virtual EndPointPropertyType EndPointPropertyType { get; set; }
		public int EntityId { get; set; }
		public int? DataSourceId { get; set; }
		public virtual ICollection<EndPointModelProperty> EndPointModelProperties { get; set; }
		public virtual ICollection<EndPointCollectionProperty> EndPointCollectionProperties { get; set; }
		public virtual ICollection<EndPointDefaultProperty> EndPointDefaultProperties { get; set; }
		public virtual Entity Entity { get; set; }
		public virtual DataSource DataSource { get; set; }
		
	}
	
	
	public enum EndPointPropertyType
	{
		ModelProperty,
		CollectionProperty,
		DefaultProperty
	}
}