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
    
    public class EndPointController : Controller
    {
        [HttpGet("/api/EndPoints")]
        public dynamic GetAllEndPoints()
        {
            var orchestrator = new EndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEndPoints().GetResponse();
        }
        
        [HttpGet("/api/EndPoints/{endpointId}")]
        public dynamic GetEndPointDetails(int endpointId)
        {
            var orchestrator = new EndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEndPointDetails(endpointId).GetResponse();
        }
        
        [HttpPut("/api/EndPoints")]
        public dynamic CreateEndPoint([FromBody] CreateEndPointInputModel model)
        {
            var orchestrator = new EndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateEndPoint(model).GetResponse();
        }
        
        [HttpPost("/api/EndPoints/{endpointId}")]
        public dynamic EditEndPoint(int endpointId, [FromBody] EditEndPointInputModel model)
        {
            var orchestrator = new EndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditEndPoint(endpointId,model).GetResponse();
        }
        
        [HttpGet("/api/EndPoints/{endpointId}/GetAllEndPoint")]
        public dynamic GetEndPointGetAllEndPoint(int endpointId)
        {
            var orchestrator = new EndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEndPointGetAllEndPoint(endpointId).GetResponse();
        }
        
        [HttpGet("/api/EndPoints/{endpointId}/DeleteEndPoint")]
        public dynamic GetEndPointDeleteEndPoint(int endpointId)
        {
            var orchestrator = new EndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEndPointDeleteEndPoint(endpointId).GetResponse();
        }
        
        [HttpGet("/api/EndPoints/{endpointId}/PostEndPoint")]
        public dynamic GetEndPointPostEndPoint(int endpointId)
        {
            var orchestrator = new EndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEndPointPostEndPoint(endpointId).GetResponse();
        }
        
        [HttpGet("/api/EndPoints/{endpointId}/PutEndPoint")]
        public dynamic GetEndPointPutEndPoint(int endpointId)
        {
            var orchestrator = new EndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEndPointPutEndPoint(endpointId).GetResponse();
        }
        
        [HttpGet("/api/EndPoints/{endpointId}/GetDetailsEndPoint")]
        public dynamic GetEndPointGetDetailsEndPoint(int endpointId)
        {
            var orchestrator = new EndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEndPointGetDetailsEndPoint(endpointId).GetResponse();
        }
        
        [HttpGet("/api/EndPoints/{endpointId}/EndPointParameters")]
        public dynamic GetAllEndPointEndPointParameters(int endpointId)
        {
            var orchestrator = new EndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEndPointEndPointParameters(endpointId).GetResponse();
        }
    }
}