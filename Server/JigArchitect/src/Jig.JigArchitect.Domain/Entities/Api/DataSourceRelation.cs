// Auto generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jig.JigArchitect.Domain.Entities 
{
	
	public class DataSourceRelation
	{
		public int DataSourceRelationId { get; set; }
		public bool UseChildEntity { get; set; }
		public int? RecursiveRelationDataSourceRelationId { get; set; }
		public int? EntityRelationRelationshipId { get; set; }
		public virtual DataSourceRelation RecursiveRelation { get; set; }
		public virtual Relationship EntityRelation { get; set; }
		
	}
	
	
}