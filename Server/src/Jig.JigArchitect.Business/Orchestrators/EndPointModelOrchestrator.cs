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
    
    public interface IEndPointModelOrchestrator
    {
        ResponseWrapper<List<GetAllEndPointModelModel>> GetAllEndPointModels();
        
        ResponseWrapper<GetEndPointModelDetailsModel> GetEndPointModelDetails(int endpointmodelId);
        
        ResponseWrapper<CreateEndPointModelModel> CreateEndPointModel(CreateEndPointModelInputModel model);
        
        ResponseWrapper<EditEndPointModelModel> EditEndPointModel(int endpointmodelId,EditEndPointModelInputModel model);
        
        ResponseWrapper<GetEndPointModelEndPointModel> GetEndPointModelEndPoint(int endpointmodelId);
        
        ResponseWrapper<List<GetAllEndPointModelEndPointModelPropertiesModel>> GetAllEndPointModelEndPointModelProperties(int endpointmodelId);
    }
    
    
    public class EndPointModelOrchestrator : IEndPointModelOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public EndPointModelOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllEndPointModelModel>> GetAllEndPointModels()
        {
            var response = context
                .EndPointModels
                    .Select(x =>
                        new GetAllEndPointModelModel
                        {
                            EndPointModelId = x.EndPointModelId,
                            Name = x.Name,
                            EntityId = x.EntityId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEndPointModelModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEndPointModelDetailsModel> GetEndPointModelDetails(int endpointmodelId)
        {
            var data = context
                .EndPointModels
                .Single(x => 
                    x.EndPointModelId == endpointmodelId
                );
            
            var response = 
                new GetEndPointModelDetailsModel
                {
                    EndPointModelId = data.EndPointModelId,
                    Name = data.Name,
                    EntityId = data.EntityId,
                };
            
            return new ResponseWrapper<GetEndPointModelDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateEndPointModelModel> CreateEndPointModel(CreateEndPointModelInputModel model)
        {
            var newEntity = new EndPointModel
            {
                Name = model.Name,
                EntityId = model.EntityId,
            };
            
            context
                .EndPointModels
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateEndPointModelModel
            {
                EndPointModelId = newEntity.EndPointModelId,
                Name = newEntity.Name,
                EntityId = newEntity.EntityId,
            };
            
            return new ResponseWrapper<CreateEndPointModelModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditEndPointModelModel> EditEndPointModel(int endpointmodelId, EditEndPointModelInputModel model)
        {
            var entity = context
                .EndPointModels
                .Single(x => 
                    x.EndPointModelId == endpointmodelId
                );
            
            entity.Name = model.Name;
            entity.EntityId = model.EntityId;
            context.SaveChanges();
            var response = new EditEndPointModelModel
            {
                EndPointModelId = entity.EndPointModelId,
                Name = entity.Name,
                EntityId = entity.EntityId,
            };
            
            return new ResponseWrapper<EditEndPointModelModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEndPointModelEndPointModel> GetEndPointModelEndPoint(int endpointmodelId)
        {
            var data = context
                .EndPointModels
                .Include(i => i.EndPoint)
                .Single(x => 
                    x.EndPointModelId == endpointmodelId
                )
                .EndPoint;
            
            var response = 
                new GetEndPointModelEndPointModel
                {
                    EndPointId = data.EndPointId,
                    Name = data.Name,
                    Route = data.Route,
                    CustomEndPoint = data.CustomEndPoint,
                    EndPointType = data.EndPointType,
                    RootEntityEntityId = data.RootEntityEntityId,
                    EndPointModelId = data.EndPointModelId,
                    RootEndPointToRootEntityDataSourceId = data.RootEndPointToRootEntityDataSourceId,
                };
            
            return new ResponseWrapper<GetEndPointModelEndPointModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllEndPointModelEndPointModelPropertiesModel>> GetAllEndPointModelEndPointModelProperties(int endpointmodelId)
        {
            var response = context
                .EndPointModels
                .Include(i => i.EndPointModelProperties)
                .Single(x => 
                    x.EndPointModelId == endpointmodelId
                )
                .EndPointModelProperties
                    .Select(x =>
                        new GetAllEndPointModelEndPointModelPropertiesModel
                        {
                            EndPointModelPropertyId = x.EndPointModelPropertyId,
                            EndPointModelId = x.EndPointModelId,
                            EndPointPropertyId = x.EndPointPropertyId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEndPointModelEndPointModelPropertiesModel>>(_validationDictionary, response);
        }
    }
}