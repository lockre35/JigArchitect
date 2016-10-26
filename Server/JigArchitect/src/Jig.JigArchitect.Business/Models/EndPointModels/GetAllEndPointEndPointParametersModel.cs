using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Models
{
    
    public class GetAllEndPointEndPointParametersModel
    {
        public int EndPointParameterId { get; set; } 
        
        public string DataType { get; set; } 
        
        public string EndPointParameterName { get; set; } 
        
        public int ParametersEndPointId { get; set; } 
        
        public int? DataSourceId { get; set; } 
    }
}