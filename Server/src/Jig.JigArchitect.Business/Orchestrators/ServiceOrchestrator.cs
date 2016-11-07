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
    
    public interface IServiceOrchestrator
    {
        ResponseWrapper<List<GetAllServiceModel>> GetAllServices();
        
        ResponseWrapper<GetServiceDetailsModel> GetServiceDetails(int serviceId);
        
        ResponseWrapper<CreateServiceModel> CreateService(CreateServiceInputModel model);
        
        ResponseWrapper<EditServiceModel> EditService(int serviceId,EditServiceInputModel model);
        
        ResponseWrapper<List<GetAllServiceEndPointsModel>> GetAllServiceEndPoints(int serviceId);
    }
    
    
    public class ServiceOrchestrator : IServiceOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public ServiceOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllServiceModel>> GetAllServices()
        {
            var response = context
                .Services
                    .Select(x =>
                        new GetAllServiceModel
                        {
                            ServiceId = x.ServiceId,
                            Name = x.Name,
                            PluralName = x.PluralName,
                            ApplicationId = x.ApplicationId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllServiceModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetServiceDetailsModel> GetServiceDetails(int serviceId)
        {
            var data = context
                .Services
                .Single(x => 
                    x.ServiceId == serviceId
                );
            
            var response = 
                new GetServiceDetailsModel
                {
                    ServiceId = data.ServiceId,
                    Name = data.Name,
                    PluralName = data.PluralName,
                    ApplicationId = data.ApplicationId,
                };
            
            return new ResponseWrapper<GetServiceDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateServiceModel> CreateService(CreateServiceInputModel model)
        {
            var newEntity = new Service
            {
                Name = model.Name,
                PluralName = model.PluralName,
                ApplicationId = model.ApplicationId,
            };
            
            context
                .Services
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateServiceModel
            {
                ServiceId = newEntity.ServiceId,
                Name = newEntity.Name,
                PluralName = newEntity.PluralName,
                ApplicationId = newEntity.ApplicationId,
            };
            
            return new ResponseWrapper<CreateServiceModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditServiceModel> EditService(int serviceId, EditServiceInputModel model)
        {
            var entity = context
                .Services
                .Single(x => 
                    x.ServiceId == serviceId
                );
            
            entity.Name = model.Name;
            entity.PluralName = model.PluralName;
            entity.ApplicationId = model.ApplicationId;
            context.SaveChanges();
            var response = new EditServiceModel
            {
                ServiceId = entity.ServiceId,
                Name = entity.Name,
                PluralName = entity.PluralName,
                ApplicationId = entity.ApplicationId,
            };
            
            return new ResponseWrapper<EditServiceModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllServiceEndPointsModel>> GetAllServiceEndPoints(int serviceId)
        {
            var response = context
                .Services
                .Include(i => i.EndPoints)
                .Single(x => 
                    x.ServiceId == serviceId
                )
                .EndPoints
                    .Select(x =>
                        new GetAllServiceEndPointsModel
                        {
                            EndPointId = x.EndPointId,
                            Name = x.Name,
                            Route = x.Route,
                            CustomEndPoint = x.CustomEndPoint,
                            EndPointType = x.EndPointType,
                            RootEntityEntityId = x.RootEntityEntityId,
                            ServiceId = x.ServiceId,
                            EndPointModelId = x.EndPointModelId,
                            RootEndPointToRootEntityDataSourceId = x.RootEndPointToRootEntityDataSourceId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllServiceEndPointsModel>>(_validationDictionary, response);
        }
    }
}