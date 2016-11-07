using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Models
{
    
    public class GetAllServiceEndPointsModel
    {
        public int EndPointId { get; set; } 
        
        public string Name { get; set; } 
        
        public string Route { get; set; } 
        
        public bool CustomEndPoint { get; set; } 
        
        public EndPointType EndPointType { get; set; } 
        
        public int? RootEntityEntityId { get; set; } 
        
        public int ServiceId { get; set; } 
        
        public int EndPointModelId { get; set; } 
        
        public int? RootEndPointToRootEntityDataSourceId { get; set; } 
    }
}