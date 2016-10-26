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
    
    public class GetAllEndPointController : Controller
    {
        [HttpGet("/api/GetAllEndPoints")]
        public dynamic GetAllGetAllEndPoints()
        {
            var orchestrator = new GetAllEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllGetAllEndPoints().GetResponse();
        }
        
        [HttpGet("/api/GetAllEndPoints/{getallendpointId}")]
        public dynamic GetGetAllEndPointDetails(int getallendpointId)
        {
            var orchestrator = new GetAllEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetGetAllEndPointDetails(getallendpointId).GetResponse();
        }
        
        [HttpPut("/api/GetAllEndPoints")]
        public dynamic CreateGetAllEndPoint([FromBody] CreateGetAllEndPointInputModel model)
        {
            var orchestrator = new GetAllEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateGetAllEndPoint(model).GetResponse();
        }
        
        [HttpPost("/api/GetAllEndPoints/{getallendpointId}")]
        public dynamic EditGetAllEndPoint(int getallendpointId, [FromBody] EditGetAllEndPointInputModel model)
        {
            var orchestrator = new GetAllEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditGetAllEndPoint(getallendpointId,model).GetResponse();
        }
    }
}