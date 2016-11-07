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
    
    public class ServiceController : Controller
    {
        [HttpGet("/api/Services")]
        public dynamic GetAllServices()
        {
            var orchestrator = new ServiceOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllServices().GetResponse();
        }
        
        [HttpGet("/api/Services/{serviceId}")]
        public dynamic GetServiceDetails(int serviceId)
        {
            var orchestrator = new ServiceOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetServiceDetails(serviceId).GetResponse();
        }
        
        [HttpPut("/api/Services")]
        public dynamic CreateService([FromBody] CreateServiceInputModel model)
        {
            var orchestrator = new ServiceOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateService(model).GetResponse();
        }
        
        [HttpPost("/api/Services/{serviceId}")]
        public dynamic EditService(int serviceId, [FromBody] EditServiceInputModel model)
        {
            var orchestrator = new ServiceOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditService(serviceId,model).GetResponse();
        }
        
        [HttpGet("/api/Services/{serviceId}/EndPoints")]
        public dynamic GetAllServiceEndPoints(int serviceId)
        {
            var orchestrator = new ServiceOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllServiceEndPoints(serviceId).GetResponse();
        }
    }
}