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
    
    public class DeleteEndPointController : Controller
    {
        [HttpGet("/api/DeleteEndPoints")]
        public dynamic GetAllDeleteEndPoints()
        {
            var orchestrator = new DeleteEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllDeleteEndPoints().GetResponse();
        }
        
        [HttpGet("/api/DeleteEndPoints/{deleteendpointId}")]
        public dynamic GetDeleteEndPointDetails(int deleteendpointId)
        {
            var orchestrator = new DeleteEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetDeleteEndPointDetails(deleteendpointId).GetResponse();
        }
        
        [HttpPut("/api/DeleteEndPoints")]
        public dynamic CreateDeleteEndPoint([FromBody] CreateDeleteEndPointInputModel model)
        {
            var orchestrator = new DeleteEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateDeleteEndPoint(model).GetResponse();
        }
        
        [HttpPost("/api/DeleteEndPoints/{deleteendpointId}")]
        public dynamic EditDeleteEndPoint(int deleteendpointId, [FromBody] EditDeleteEndPointInputModel model)
        {
            var orchestrator = new DeleteEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditDeleteEndPoint(deleteendpointId,model).GetResponse();
        }
    }
}