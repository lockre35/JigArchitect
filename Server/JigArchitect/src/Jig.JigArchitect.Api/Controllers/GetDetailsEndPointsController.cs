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
    
    public class GetDetailsEndPointController : Controller
    {
        [HttpGet("/api/GetDetailsEndPoints")]
        public dynamic GetAllGetDetailsEndPoints()
        {
            var orchestrator = new GetDetailsEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllGetDetailsEndPoints().GetResponse();
        }
        
        [HttpGet("/api/GetDetailsEndPoints/{getdetailsendpointId}")]
        public dynamic GetGetDetailsEndPointDetails(int getdetailsendpointId)
        {
            var orchestrator = new GetDetailsEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetGetDetailsEndPointDetails(getdetailsendpointId).GetResponse();
        }
        
        [HttpPut("/api/GetDetailsEndPoints")]
        public dynamic CreateGetDetailsEndPoint([FromBody] CreateGetDetailsEndPointInputModel model)
        {
            var orchestrator = new GetDetailsEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateGetDetailsEndPoint(model).GetResponse();
        }
        
        [HttpPost("/api/GetDetailsEndPoints/{getdetailsendpointId}")]
        public dynamic EditGetDetailsEndPoint(int getdetailsendpointId, [FromBody] EditGetDetailsEndPointInputModel model)
        {
            var orchestrator = new GetDetailsEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditGetDetailsEndPoint(getdetailsendpointId,model).GetResponse();
        }
    }
}