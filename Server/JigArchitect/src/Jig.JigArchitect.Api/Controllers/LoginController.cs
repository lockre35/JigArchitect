using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Jig.JigArchitect.Domain;
using Jig.JigArchitect.Api.Services;
using Jig.JigArchitect.Business.Services;
using Jig.JigArchitect.Business.Orchestrators;
using Jig.JigArchitect.Business.Models;

namespace Jig.JigArchitect.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        // GET api/logins
        [HttpGet]
        public ResponseModel<List<LoginModel>> Get()
        {
            var orchestrator = new LoginOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetLogins().GetResponse();
        }

        // GET api/logins/5
        [HttpGet("{id}")]
        public ResponseModel<LoginModel> Get(int id)
        {
            var orchestrator = new LoginOrchestrator(new ModelStateWrapper(this.ModelState));
            return orchestrator.GetLogin(id).GetResponse();
        }

        // POST api/logins
        [HttpPost]
        public dynamic Post([FromBody]LoginModel model)
        {
            var orchestrator = new LoginOrchestrator(new ModelStateWrapper(this.ModelState));
            var responseWrapper = orchestrator.CreateLogin(model);
            if (!responseWrapper.IsValid())
            {
                Response.StatusCode = 400;
                return responseWrapper.GetErrors();
            }

            return responseWrapper.GetResponse();
        }

        // PUT api/logins/5
        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody]LoginModel model)
        {
            var orchestrator = new LoginOrchestrator(new ModelStateWrapper(this.ModelState));
            var responseWrapper = orchestrator.SaveLogin(id, model);
            if (!responseWrapper.IsValid())
            {
                Response.StatusCode = 400;
                return responseWrapper.GetErrors();
            }

            return responseWrapper.GetResponse();
        }

        // DELETE api/logins/5
        [HttpDelete("{id}")]
        public dynamic Delete(int id, [FromBody]LoginModel model)
        {
            var orchestrator = new LoginOrchestrator(new ModelStateWrapper(this.ModelState));
            var responseWrapper = orchestrator.DeleteLogin(id, model);
            if (!responseWrapper.IsValid())
            {
                Response.StatusCode = 400;
                return responseWrapper.GetErrors();
            }

            return responseWrapper.GetResponse();
        }
    }
}
