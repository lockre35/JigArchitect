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
    
    public class EndPointParameterController : Controller
    {
        [HttpGet("/api/EndPointParameters")]
        public dynamic GetAllEndPointParameters()
        {
            var orchestrator = new EndPointParameterOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEndPointParameters().GetResponse();
        }
        
        [HttpGet("/api/EndPointParameters/{endpointparameterId}")]
        public dynamic GetEndPointParameterDetails(int endpointparameterId)
        {
            var orchestrator = new EndPointParameterOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEndPointParameterDetails(endpointparameterId).GetResponse();
        }
        
        [HttpPut("/api/EndPointParameters")]
        public dynamic CreateEndPointParameter([FromBody] CreateEndPointParameterInputModel model)
        {
            var orchestrator = new EndPointParameterOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateEndPointParameter(model).GetResponse();
        }
        
        [HttpPost("/api/EndPointParameters/{endpointparameterId}")]
        public dynamic EditEndPointParameter(int endpointparameterId, [FromBody] EditEndPointParameterInputModel model)
        {
            var orchestrator = new EndPointParameterOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditEndPointParameter(endpointparameterId,model).GetResponse();
        }
    }
}