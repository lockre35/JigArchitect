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
    
    public class EnumPropertyValueController : Controller
    {
        [HttpGet("/api/EnumPropertyValues")]
        public dynamic GetAllEnumPropertyValues()
        {
            var orchestrator = new EnumPropertyValueOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetAllEnumPropertyValues().GetResponse();
        }
        
        [HttpGet("/api/EnumPropertyValues/{enumpropertyvalueId}")]
        public dynamic GetEnumPropertyValueDetails(int enumpropertyvalueId)
        {
            var orchestrator = new EnumPropertyValueOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetEnumPropertyValueDetails(enumpropertyvalueId).GetResponse();
        }
        
        [HttpPut("/api/EnumPropertyValues")]
        public dynamic CreateEnumPropertyValue([FromBody] CreateEnumPropertyValueInputModel model)
        {
            var orchestrator = new EnumPropertyValueOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.CreateEnumPropertyValue(model).GetResponse();
        }
        
        [HttpPost("/api/EnumPropertyValues/{enumpropertyvalueId}")]
        public dynamic EditEnumPropertyValue(int enumpropertyvalueId, [FromBody] EditEnumPropertyValueInputModel model)
        {
            var orchestrator = new EnumPropertyValueOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.EditEnumPropertyValue(enumpropertyvalueId,model).GetResponse();
        }
    }
}