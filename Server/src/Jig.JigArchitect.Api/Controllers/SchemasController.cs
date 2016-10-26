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
    
    public class SchemaController : Controller
    {
        [HttpGet("/api/Schemas")]
        public dynamic GetAllSchemas()
        {
            var orchestrator = new SchemaOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllSchemas().GetResponse();
        }
        
        [HttpGet("/api/Schemas/{schemaId}")]
        public dynamic GetSchemaDetails(int schemaId)
        {
            var orchestrator = new SchemaOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetSchemaDetails(schemaId).GetResponse();
        }
        
        [HttpPut("/api/Schemas")]
        public dynamic CreateSchema([FromBody] CreateSchemaInputModel model)
        {
            var orchestrator = new SchemaOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateSchema(model).GetResponse();
        }
        
        [HttpPost("/api/Schemas/{schemaId}")]
        public dynamic EditSchema(int schemaId, [FromBody] EditSchemaInputModel model)
        {
            var orchestrator = new SchemaOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditSchema(schemaId,model).GetResponse();
        }
        
        [HttpGet("/api/Schemas/{schemaId}/Entities")]
        public dynamic GetAllSchemaEntities(int schemaId)
        {
            var orchestrator = new SchemaOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllSchemaEntities(schemaId).GetResponse();
        }
    }
}