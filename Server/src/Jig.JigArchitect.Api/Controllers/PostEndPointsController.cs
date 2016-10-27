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
    
    public class PostEndPointController : Controller
    {
        [HttpGet("/api/PostEndPoints")]
        public dynamic GetAllPostEndPoints()
        {
            var orchestrator = new PostEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllPostEndPoints().GetResponse();
        }
        
        [HttpGet("/api/PostEndPoints/{postendpointId}")]
        public dynamic GetPostEndPointDetails(int postendpointId)
        {
            var orchestrator = new PostEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetPostEndPointDetails(postendpointId).GetResponse();
        }
        
        [HttpPut("/api/PostEndPoints")]
        public dynamic CreatePostEndPoint([FromBody] CreatePostEndPointInputModel model)
        {
            var orchestrator = new PostEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreatePostEndPoint(model).GetResponse();
        }
        
        [HttpPost("/api/PostEndPoints/{postendpointId}")]
        public dynamic EditPostEndPoint(int postendpointId, [FromBody] EditPostEndPointInputModel model)
        {
            var orchestrator = new PostEndPointOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditPostEndPoint(postendpointId,model).GetResponse();
        }
    }
}