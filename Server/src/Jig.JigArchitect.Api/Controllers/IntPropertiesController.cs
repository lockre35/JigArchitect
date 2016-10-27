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
    
    public class IntPropertyController : Controller
    {
        [HttpGet("/api/IntProperties")]
        public dynamic GetAllIntProperties()
        {
            var orchestrator = new IntPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllIntProperties().GetResponse();
        }
        
        [HttpGet("/api/IntProperties/{intpropertyId}")]
        public dynamic GetIntPropertyDetails(int intpropertyId)
        {
            var orchestrator = new IntPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetIntPropertyDetails(intpropertyId).GetResponse();
        }
        
        [HttpPut("/api/IntProperties")]
        public dynamic CreateIntProperty([FromBody] CreateIntPropertyInputModel model)
        {
            var orchestrator = new IntPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateIntProperty(model).GetResponse();
        }
        
        [HttpPost("/api/IntProperties/{intpropertyId}")]
        public dynamic EditIntProperty(int intpropertyId, [FromBody] EditIntPropertyInputModel model)
        {
            var orchestrator = new IntPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditIntProperty(intpropertyId,model).GetResponse();
        }
    }
}