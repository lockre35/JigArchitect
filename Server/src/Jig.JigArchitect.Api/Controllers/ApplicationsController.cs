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
    
    public class ApplicationController : Controller
    {
        [HttpGet("/api/Applications")]
        public dynamic GetAllApplications()
        {
            var orchestrator = new ApplicationOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllApplications().GetResponse();
        }
        
        [HttpGet("/api/Applications/{applicationId}")]
        public dynamic GetApplicationDetails(int applicationId)
        {
            var orchestrator = new ApplicationOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetApplicationDetails(applicationId).GetResponse();
        }
        
        [HttpPut("/api/Applications")]
        public dynamic CreateApplication([FromBody] CreateApplicationInputModel model)
        {
            var orchestrator = new ApplicationOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateApplication(model).GetResponse();
        }
        
        [HttpPost("/api/Applications/{applicationId}")]
        public dynamic EditApplication(int applicationId, [FromBody] EditApplicationInputModel model)
        {
            var orchestrator = new ApplicationOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditApplication(applicationId,model).GetResponse();
        }
        
        [HttpGet("/api/Applications/{applicationId}/Schemas")]
        public dynamic GetAllApplicationSchemas(int applicationId)
        {
            var orchestrator = new ApplicationOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllApplicationSchemas(applicationId).GetResponse();
        }
        
        [HttpGet("/api/Applications/{applicationId}/Services")]
        public dynamic GetAllApplicationServices(int applicationId)
        {
            var orchestrator = new ApplicationOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllApplicationServices(applicationId).GetResponse();
        }
    }
}