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
    
    public class RelationshipController : Controller
    {
        [HttpGet("/api/Relationships")]
        public dynamic GetAllRelationships()
        {
            var orchestrator = new RelationshipOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllRelationships().GetResponse();
        }
        
        [HttpGet("/api/Relationships/{relationshipId}")]
        public dynamic GetRelationshipDetails(int relationshipId)
        {
            var orchestrator = new RelationshipOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetRelationshipDetails(relationshipId).GetResponse();
        }
        
        [HttpPut("/api/Relationships")]
        public dynamic CreateRelationship([FromBody] CreateRelationshipInputModel model)
        {
            var orchestrator = new RelationshipOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateRelationship(model).GetResponse();
        }
        
        [HttpPost("/api/Relationships/{relationshipId}")]
        public dynamic EditRelationship(int relationshipId, [FromBody] EditRelationshipInputModel model)
        {
            var orchestrator = new RelationshipOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditRelationship(relationshipId,model).GetResponse();
        }
    }
}