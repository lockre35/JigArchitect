using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jig.JigArchitect.Business.Models;
using Jig.JigArchitect.Business.Services;
using Jig.JigArchitect.Domain;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Orchestrators
{
    
    public interface IApplicationOrchestrator
    {
        ResponseWrapper<List<GetAllApplicationModel>> GetAllApplications();
        
        ResponseWrapper<GetApplicationDetailsModel> GetApplicationDetails(int applicationId);
        
        ResponseWrapper<CreateApplicationModel> CreateApplication(CreateApplicationInputModel model);
        
        ResponseWrapper<EditApplicationModel> EditApplication(int applicationId,EditApplicationInputModel model);
    }
    
    
    public class ApplicationOrchestrator : IApplicationOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public ApplicationOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllApplicationModel>> GetAllApplications()
        {
            var response = context
                .Applications
                    .Select(x =>
                        new GetAllApplicationModel
                        {
                            ApplicationId = x.ApplicationId,
                            Name = x.Name,
                            Icon = x.Icon,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllApplicationModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetApplicationDetailsModel> GetApplicationDetails(int applicationId)
        {
            var data = context
                .Applications
                .Single(x => 
                    x.ApplicationId == applicationId
                );
            
            var response = 
                new GetApplicationDetailsModel
                {
                    ApplicationId = data.ApplicationId,
                    Name = data.Name,
                    Icon = data.Icon,
                };
            
            return new ResponseWrapper<GetApplicationDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateApplicationModel> CreateApplication(CreateApplicationInputModel model)
        {
            var newEntity = new Application
            {
                Name = model.Name,
                Icon = model.Icon,
            };
            
            context
                .Applications
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateApplicationModel
            {
                ApplicationId = newEntity.ApplicationId,
                Name = newEntity.Name,
                Icon = newEntity.Icon,
            };
            
            return new ResponseWrapper<CreateApplicationModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditApplicationModel> EditApplication(int applicationId, EditApplicationInputModel model)
        {
            var entity = context
                .Applications
                .Single(x => 
                    x.ApplicationId == applicationId
                );
            
            entity.Name = model.Name;
            entity.Icon = model.Icon;
            context.SaveChanges();
            var response = new EditApplicationModel
            {
                ApplicationId = entity.ApplicationId,
                Name = entity.Name,
                Icon = entity.Icon,
            };
            
            return new ResponseWrapper<EditApplicationModel>(_validationDictionary, response);
        }
    }
}