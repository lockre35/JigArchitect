// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class EndPoint
	{
		public int EndPointId { get; set; }
		public string Name { get; set; }
		public string Route { get; set; }
		public bool CustomEndPoint { get; set; }
		public virtual EndPointType EndPointType { get; set; }
		public int? RootEntityEntityId { get; set; }
		public int EndPointModelId { get; set; }
		public int? RootEndPointToRootEntityDataSourceId { get; set; }
		public virtual GetAllEndPoint GetAllEndPoint { get; set; }
		public virtual DeleteEndPoint DeleteEndPoint { get; set; }
		public virtual PostEndPoint PostEndPoint { get; set; }
		public virtual PutEndPoint PutEndPoint { get; set; }
		public virtual GetDetailsEndPoint GetDetailsEndPoint { get; set; }
		public virtual ICollection<EndPointParameter> EndPointParameters { get; set; }
		public virtual Entity RootEntity { get; set; }
		public virtual EndPointModel EndPointModel { get; set; }
		public virtual DataSource RootEndPointToRootEntity { get; set; }
		
	}
	
	
	public enum EndPointType
	{
		GetDetailsEndPoint,
		PutEndPoint,
		PostEndPoint,
		GetAllEndPoint,
		DeleteEndPoint
	}
}