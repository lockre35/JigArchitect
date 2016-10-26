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
    
    public class DataSourceRelationController : Controller
    {
        [HttpGet("/api/DataSourceRelations")]
        public dynamic GetAllDataSourceRelations()
        {
            var orchestrator = new DataSourceRelationOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllDataSourceRelations().GetResponse();
        }
        
        [HttpGet("/api/DataSourceRelations/{datasourcerelationId}")]
        public dynamic GetDataSourceRelationDetails(int datasourcerelationId)
        {
            var orchestrator = new DataSourceRelationOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetDataSourceRelationDetails(datasourcerelationId).GetResponse();
        }
        
        [HttpPut("/api/DataSourceRelations")]
        public dynamic CreateDataSourceRelation([FromBody] CreateDataSourceRelationInputModel model)
        {
            var orchestrator = new DataSourceRelationOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateDataSourceRelation(model).GetResponse();
        }
        
        [HttpPost("/api/DataSourceRelations/{datasourcerelationId}")]
        public dynamic EditDataSourceRelation(int datasourcerelationId, [FromBody] EditDataSourceRelationInputModel model)
        {
            var orchestrator = new DataSourceRelationOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditDataSourceRelation(datasourcerelationId,model).GetResponse();
        }
    }
}