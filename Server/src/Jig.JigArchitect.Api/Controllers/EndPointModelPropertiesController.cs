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
    
    public class EndPointModelPropertyController : Controller
    {
        [HttpGet("/api/EndPointModelProperties")]
        public dynamic GetAllEndPointModelProperties()
        {
            var orchestrator = new EndPointModelPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEndPointModelProperties().GetResponse();
        }
        
        [HttpGet("/api/EndPointModelProperties/{endpointmodelpropertyId}")]
        public dynamic GetEndPointModelPropertyDetails(int endpointmodelpropertyId)
        {
            var orchestrator = new EndPointModelPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEndPointModelPropertyDetails(endpointmodelpropertyId).GetResponse();
        }
        
        [HttpPut("/api/EndPointModelProperties")]
        public dynamic CreateEndPointModelProperty([FromBody] CreateEndPointModelPropertyInputModel model)
        {
            var orchestrator = new EndPointModelPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateEndPointModelProperty(model).GetResponse();
        }
        
        [HttpPost("/api/EndPointModelProperties/{endpointmodelpropertyId}")]
        public dynamic EditEndPointModelProperty(int endpointmodelpropertyId, [FromBody] EditEndPointModelPropertyInputModel model)
        {
            var orchestrator = new EndPointModelPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditEndPointModelProperty(endpointmodelpropertyId,model).GetResponse();
        }
    }
}