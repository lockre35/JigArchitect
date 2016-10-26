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
    
    public class PropertyController : Controller
    {
        [HttpGet("/api/Properties")]
        public dynamic GetAllProperties()
        {
            var orchestrator = new PropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllProperties().GetResponse();
        }
        
        [HttpGet("/api/Properties/{propertyId}")]
        public dynamic GetPropertyDetails(int propertyId)
        {
            var orchestrator = new PropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetPropertyDetails(propertyId).GetResponse();
        }
        
        [HttpPut("/api/Properties")]
        public dynamic CreateProperty([FromBody] CreatePropertyInputModel model)
        {
            var orchestrator = new PropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateProperty(model).GetResponse();
        }
        
        [HttpPost("/api/Properties/{propertyId}")]
        public dynamic EditProperty(int propertyId, [FromBody] EditPropertyInputModel model)
        {
            var orchestrator = new PropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditProperty(propertyId,model).GetResponse();
        }
        
        [HttpGet("/api/Properties/{propertyId}/IntProperty")]
        public dynamic GetPropertyIntProperty(int propertyId)
        {
            var orchestrator = new PropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetPropertyIntProperty(propertyId).GetResponse();
        }
        
        [HttpGet("/api/Properties/{propertyId}/EnumProperty")]
        public dynamic GetPropertyEnumProperty(int propertyId)
        {
            var orchestrator = new PropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetPropertyEnumProperty(propertyId).GetResponse();
        }
    }
}