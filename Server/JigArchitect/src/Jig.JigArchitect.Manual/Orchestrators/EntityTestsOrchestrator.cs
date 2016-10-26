using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jig.JigArchitect.Business.Models;
using Jig.JigArchitect.Business.Services;
using Jig.JigArchitect.Business.Orchestrators;
using Jig.JigArchitect.Domain;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Manual.Orchestrators
{
    
    public class EntityTestOrchestrator : AbstractEntityTestOrchestrator
    {
        public EntityTestOrchestrator(IValidationDictionary dictionary) : base(dictionary)
        {
        }
        
        public override ResponseWrapper<List<CustomEntityModel>> Custom()
        {
            throw new NotImplementedException();
        }
    }
}