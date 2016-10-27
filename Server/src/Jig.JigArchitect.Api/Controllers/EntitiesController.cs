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
    
    public class EntityController : Controller
    {
        [HttpGet("/api/Entities")]
        public dynamic GetAllEntities()
        {
            var orchestrator = new EntityOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEntities().GetResponse();
        }
        
        [HttpGet("/api/Entities/{entityId}")]
        public dynamic GetEntityDetails(int entityId)
        {
            var orchestrator = new EntityOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEntityDetails(entityId).GetResponse();
        }
        
        [HttpPut("/api/Entities")]
        public dynamic CreateEntity([FromBody] CreateEntityInputModel model)
        {
            var orchestrator = new EntityOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateEntity(model).GetResponse();
        }
        
        [HttpPost("/api/Entities/{entityId}")]
        public dynamic EditEntity(int entityId, [FromBody] EditEntityInputModel model)
        {
            var orchestrator = new EntityOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditEntity(entityId,model).GetResponse();
        }
        
        [HttpGet("/api/Entities/{entityId}/Properties")]
        public dynamic GetAllEntityProperties(int entityId)
        {
            var orchestrator = new EntityOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEntityProperties(entityId).GetResponse();
        }
        
        [HttpGet("/api/Entities/{entityId}/ParentRelationships")]
        public dynamic GetAllEntityParentRelationships(int entityId)
        {
            var orchestrator = new EntityOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEntityParentRelationships(entityId).GetResponse();
        }
        
        [HttpGet("/api/Entities/{entityId}/ChildrenRelationships")]
        public dynamic GetAllEntityChildrenRelationships(int entityId)
        {
            var orchestrator = new EntityOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEntityChildrenRelationships(entityId).GetResponse();
        }
        
        [HttpGet("/api/Entities/{entityId}/EndPointProperties")]
        public dynamic GetAllEntityEndPointProperties(int entityId)
        {
            var orchestrator = new EntityOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEntityEndPointProperties(entityId).GetResponse();
        }
    }
}