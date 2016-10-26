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
    
    public class PutEndPointController : Controller
    {
        [HttpGet("/api/PutEndPoints")]
        public dynamic GetAllPutEndPoints()
        {
            var orchestrator = new PutEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllPutEndPoints().GetResponse();
        }
        
        [HttpGet("/api/PutEndPoints/{putendpointId}")]
        public dynamic GetPutEndPointDetails(int putendpointId)
        {
            var orchestrator = new PutEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetPutEndPointDetails(putendpointId).GetResponse();
        }
        
        [HttpPut("/api/PutEndPoints")]
        public dynamic CreatePutEndPoint([FromBody] CreatePutEndPointInputModel model)
        {
            var orchestrator = new PutEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreatePutEndPoint(model).GetResponse();
        }
        
        [HttpPost("/api/PutEndPoints/{putendpointId}")]
        public dynamic EditPutEndPoint(int putendpointId, [FromBody] EditPutEndPointInputModel model)
        {
            var orchestrator = new PutEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditPutEndPoint(putendpointId,model).GetResponse();
        }
    }
}