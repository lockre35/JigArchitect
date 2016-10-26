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
    
    public class EnumPropertyController : Controller
    {
        [HttpGet("/api/EnumProperties")]
        public dynamic GetAllEnumProperties()
        {
            var orchestrator = new EnumPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEnumProperties().GetResponse();
        }
        
        [HttpGet("/api/EnumProperties/{enumpropertyId}")]
        public dynamic GetEnumPropertyDetails(int enumpropertyId)
        {
            var orchestrator = new EnumPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEnumPropertyDetails(enumpropertyId).GetResponse();
        }
        
        [HttpPut("/api/EnumProperties")]
        public dynamic CreateEnumProperty([FromBody] CreateEnumPropertyInputModel model)
        {
            var orchestrator = new EnumPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateEnumProperty(model).GetResponse();
        }
        
        [HttpPost("/api/EnumProperties/{enumpropertyId}")]
        public dynamic EditEnumProperty(int enumpropertyId, [FromBody] EditEnumPropertyInputModel model)
        {
            var orchestrator = new EnumPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditEnumProperty(enumpropertyId,model).GetResponse();
        }
        
        [HttpGet("/api/EnumProperties/{enumpropertyId}/EnumPropertyValues")]
        public dynamic GetAllEnumPropertyEnumPropertyValues(int enumpropertyId)
        {
            var orchestrator = new EnumPropertyOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEnumPropertyEnumPropertyValues(enumpropertyId).GetResponse();
        }
    }
}