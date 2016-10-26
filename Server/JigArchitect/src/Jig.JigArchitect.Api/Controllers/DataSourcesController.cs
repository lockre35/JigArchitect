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
    
    public class DataSourceController : Controller
    {
        [HttpGet("/api/DataSources")]
        public dynamic GetAllDataSources()
        {
            var orchestrator = new DataSourceOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllDataSources().GetResponse();
        }
        
        [HttpGet("/api/DataSources/{datasourceId}")]
        public dynamic GetDataSourceDetails(int datasourceId)
        {
            var orchestrator = new DataSourceOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetDataSourceDetails(datasourceId).GetResponse();
        }
        
        [HttpPut("/api/DataSources")]
        public dynamic CreateDataSource([FromBody] CreateDataSourceInputModel model)
        {
            var orchestrator = new DataSourceOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateDataSource(model).GetResponse();
        }
        
        [HttpPost("/api/DataSources/{datasourceId}")]
        public dynamic EditDataSource(int datasourceId, [FromBody] EditDataSourceInputModel model)
        {
            var orchestrator = new DataSourceOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditDataSource(datasourceId,model).GetResponse();
        }
    }
}