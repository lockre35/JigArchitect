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
    
    public class EntityTestController : Controller
    {
        [HttpGet("/api/entities")]
        public dynamic Get()
        {
            var orchestrator = new EntityTestOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.Get().GetResponse();
        }
        
        [HttpGet("/api/entities/custom")]
        public dynamic Custom()
        {
            var orchestrator = new EntityTestOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.Custom().GetResponse();
        }
        
        [HttpGet("/api/entities/{id}")]
        public dynamic EntityDetails(int entityId)
        {
            var orchestrator = new EntityTestOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EntityDetails(entityId).GetResponse();
        }
        
        [HttpGet("/api/entities/{id}/properties")]
        public dynamic EntityProperties(int entityId)
        {
            var orchestrator = new EntityTestOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EntityProperties(entityId).GetResponse();
        }
        
        [HttpDelete("/api/entities/{id}")]
        public dynamic DeleteEntity(int entityId)
        {
            var orchestrator = new EntityTestOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.DeleteEntity(entityId).GetResponse();
        }
        
        [HttpPut("/api/entities")]
        public dynamic PutEntity([FromBody] EntityPutInputModel model)
        {
            var orchestrator = new EntityTestOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.PutEntity(model).GetResponse();
        }
        
        [HttpPost("")]
        public dynamic EditEntity(int entityId, [FromBody] TestEditEntityInputModel model)
        {
            var orchestrator = new EntityTestOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditEntity(entityId,model).GetResponse();
        }
    }
}