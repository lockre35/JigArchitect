using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Jig.JigArchitect.Business.Services;
using Jig.JigArchitect.Business.Orchestrators;
using Jig.JigArchitect.Business.Models;
using Jig.JigArchitect.Manual.Orchestrators;
using Jig.JigArchitect.Api.Services;

namespace Jig.JigArchitect.Controllers
{
    [Authorize]
    
    public class EndPointPropertyController : Controller
    {
        [HttpGet("/api/EndPointProperties")]
        public dynamic GetAllEndPointProperties()
        {
            var orchestrator = new EndPointPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEndPointProperties().GetResponse();
        }
        
        [HttpGet("/api/EndPointProperties/{endpointpropertyId}")]
        public dynamic GetEndPointPropertyDetails(int endpointpropertyId)
        {
            var orchestrator = new EndPointPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEndPointPropertyDetails(endpointpropertyId).GetResponse();
        }
        
        [HttpPut("/api/EndPointProperties")]
        public dynamic CreateEndPointProperty([FromBody] CreateEndPointPropertyInputModel model)
        {
            var orchestrator = new EndPointPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateEndPointProperty(model).GetResponse();
        }
        
        [HttpPost("/api/EndPointProperties/{endpointpropertyId}")]
        public dynamic EditEndPointProperty(int endpointpropertyId, [FromBody] EditEndPointPropertyInputModel model)
        {
            var orchestrator = new EndPointPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditEndPointProperty(endpointpropertyId,model).GetResponse();
        }
        
        [HttpGet("/api/EndPointProperties/{endpointpropertyId}/EndPointModelProperties")]
        public dynamic GetAllEndPointPropertyEndPointModelProperties(int endpointpropertyId)
        {
            var orchestrator = new EndPointPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEndPointPropertyEndPointModelProperties(endpointpropertyId).GetResponse();
        }
        
        [HttpGet("/api/EndPointProperties/{endpointpropertyId}/EndPointCollectionProperties")]
        public dynamic GetAllEndPointPropertyEndPointCollectionProperties(int endpointpropertyId)
        {
            var orchestrator = new EndPointPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEndPointPropertyEndPointCollectionProperties(endpointpropertyId).GetResponse();
        }
        
        [HttpGet("/api/EndPointProperties/{endpointpropertyId}/EndPointDefaultProperties")]
        public dynamic GetAllEndPointPropertyEndPointDefaultProperties(int endpointpropertyId)
        {
            var orchestrator = new EndPointPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEndPointPropertyEndPointDefaultProperties(endpointpropertyId).GetResponse();
        }
    }
}