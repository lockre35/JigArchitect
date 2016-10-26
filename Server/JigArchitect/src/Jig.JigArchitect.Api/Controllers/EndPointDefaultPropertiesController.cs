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
    
    public class EndPointDefaultPropertyController : Controller
    {
        [HttpGet("/api/EndPointDefaultProperties")]
        public dynamic GetAllEndPointDefaultProperties()
        {
            var orchestrator = new EndPointDefaultPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEndPointDefaultProperties().GetResponse();
        }
        
        [HttpGet("/api/EndPointDefaultProperties/{endpointdefaultpropertyId}")]
        public dynamic GetEndPointDefaultPropertyDetails(int endpointdefaultpropertyId)
        {
            var orchestrator = new EndPointDefaultPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEndPointDefaultPropertyDetails(endpointdefaultpropertyId).GetResponse();
        }
        
        [HttpPut("/api/EndPointDefaultProperties")]
        public dynamic CreateEndPointDefaultProperty([FromBody] CreateEndPointDefaultPropertyInputModel model)
        {
            var orchestrator = new EndPointDefaultPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateEndPointDefaultProperty(model).GetResponse();
        }
        
        [HttpPost("/api/EndPointDefaultProperties/{endpointdefaultpropertyId}")]
        public dynamic EditEndPointDefaultProperty(int endpointdefaultpropertyId, [FromBody] EditEndPointDefaultPropertyInputModel model)
        {
            var orchestrator = new EndPointDefaultPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditEndPointDefaultProperty(endpointdefaultpropertyId,model).GetResponse();
        }
    }
}