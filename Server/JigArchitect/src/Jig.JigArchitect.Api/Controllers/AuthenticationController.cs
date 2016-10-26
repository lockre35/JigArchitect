using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Jig.JigArchitect.Api.Models;
using Jig.JigArchitect.Api.Orchestrators;

namespace Jig.JigArchitect.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly TokenOptionsModel tokenOptions;

        public AuthenticationController(TokenOptionsModel tokenOptions)
        {
            this.tokenOptions = tokenOptions;
        }

        /// <summary>
        /// Request a new token for a given username/password pair.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic Post([FromBody] AuthenticationModel model)
        {
            var loginOrchestrator = new AuthenticationOrchestrator(tokenOptions);
            return loginOrchestrator.Authenticate(model);
        }
    }
}
