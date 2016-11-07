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
        
        ResponseWrapper<List<GetAllApplicationSchemasModel>> GetAllApplicationSchemas(int applicationId);
        
        ResponseWrapper<List<GetAllApplicationServicesModel>> GetAllApplicationServices(int applicationId);
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
                            Description = x.Description,
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
                    Description = data.Description,
                };
            
            return new ResponseWrapper<GetApplicationDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateApplicationModel> CreateApplication(CreateApplicationInputModel model)
        {
            var newEntity = new Application
            {
                Name = model.Name,
                Icon = model.Icon,
                Description = model.Description,
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
                Description = newEntity.Description,
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
            entity.Description = model.Description;
            context.SaveChanges();
            var response = new EditApplicationModel
            {
                ApplicationId = entity.ApplicationId,
                Name = entity.Name,
                Icon = entity.Icon,
                Description = entity.Description,
            };
            
            return new ResponseWrapper<EditApplicationModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllApplicationSchemasModel>> GetAllApplicationSchemas(int applicationId)
        {
            var response = context
                .Applications
                .Include(i => i.Schemas)
                .Single(x => 
                    x.ApplicationId == applicationId
                )
                .Schemas
                    .Select(x =>
                        new GetAllApplicationSchemasModel
                        {
                            Name = x.Name,
                            SchemaId = x.SchemaId,
                            ApplicationId = x.ApplicationId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllApplicationSchemasModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllApplicationServicesModel>> GetAllApplicationServices(int applicationId)
        {
            var response = context
                .Applications
                .Include(i => i.Services)
                .Single(x => 
                    x.ApplicationId == applicationId
                )
                .Services
                    .Select(x =>
                        new GetAllApplicationServicesModel
                        {
                            ServiceId = x.ServiceId,
                            Name = x.Name,
                            PluralName = x.PluralName,
                            ApplicationId = x.ApplicationId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllApplicationServicesModel>>(_validationDictionary, response);
        }
    }
}