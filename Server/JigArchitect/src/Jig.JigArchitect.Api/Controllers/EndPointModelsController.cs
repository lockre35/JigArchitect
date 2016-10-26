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
    
    public class EndPointModelController : Controller
    {
        [HttpGet("/api/EndPointModels")]
        public dynamic GetAllEndPointModels()
        {
            var orchestrator = new EndPointModelOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEndPointModels().GetResponse();
        }
        
        [HttpGet("/api/EndPointModels/{endpointmodelId}")]
        public dynamic GetEndPointModelDetails(int endpointmodelId)
        {
            var orchestrator = new EndPointModelOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEndPointModelDetails(endpointmodelId).GetResponse();
        }
        
        [HttpPut("/api/EndPointModels")]
        public dynamic CreateEndPointModel([FromBody] CreateEndPointModelInputModel model)
        {
            var orchestrator = new EndPointModelOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateEndPointModel(model).GetResponse();
        }
        
        [HttpPost("/api/EndPointModels/{endpointmodelId}")]
        public dynamic EditEndPointModel(int endpointmodelId, [FromBody] EditEndPointModelInputModel model)
        {
            var orchestrator = new EndPointModelOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditEndPointModel(endpointmodelId,model).GetResponse();
        }
        
        [HttpGet("/api/EndPointModels/{endpointmodelId}/EndPoint")]
        public dynamic GetEndPointModelEndPoint(int endpointmodelId)
        {
            var orchestrator = new EndPointModelOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEndPointModelEndPoint(endpointmodelId).GetResponse();
        }
        
        [HttpGet("/api/EndPointModels/{endpointmodelId}/EndPointModelProperties")]
        public dynamic GetAllEndPointModelEndPointModelProperties(int endpointmodelId)
        {
            var orchestrator = new EndPointModelOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEndPointModelEndPointModelProperties(endpointmodelId).GetResponse();
        }
    }
}