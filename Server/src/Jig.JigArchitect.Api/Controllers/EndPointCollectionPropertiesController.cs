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
    
    public class EndPointCollectionPropertyController : Controller
    {
        [HttpGet("/api/EndPointCollectionProperties")]
        public dynamic GetAllEndPointCollectionProperties()
        {
            var orchestrator = new EndPointCollectionPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEndPointCollectionProperties().GetResponse();
        }
        
        [HttpGet("/api/EndPointCollectionProperties/{endpointcollectionpropertyId}")]
        public dynamic GetEndPointCollectionPropertyDetails(int endpointcollectionpropertyId)
        {
            var orchestrator = new EndPointCollectionPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEndPointCollectionPropertyDetails(endpointcollectionpropertyId).GetResponse();
        }
        
        [HttpPut("/api/EndPointCollectionProperties")]
        public dynamic CreateEndPointCollectionProperty([FromBody] CreateEndPointCollectionPropertyInputModel model)
        {
            var orchestrator = new EndPointCollectionPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateEndPointCollectionProperty(model).GetResponse();
        }
        
        [HttpPost("/api/EndPointCollectionProperties/{endpointcollectionpropertyId}")]
        public dynamic EditEndPointCollectionProperty(int endpointcollectionpropertyId, [FromBody] EditEndPointCollectionPropertyInputModel model)
        {
            var orchestrator = new EndPointCollectionPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditEndPointCollectionProperty(endpointcollectionpropertyId,model).GetResponse();
        }
    }
}