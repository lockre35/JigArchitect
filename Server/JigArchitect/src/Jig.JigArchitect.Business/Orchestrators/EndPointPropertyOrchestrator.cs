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
    
    public interface IEndPointPropertyOrchestrator
    {
        ResponseWrapper<List<GetAllEndPointPropertyModel>> GetAllEndPointProperties();
        
        ResponseWrapper<GetEndPointPropertyDetailsModel> GetEndPointPropertyDetails(int endpointpropertyId);
        
        ResponseWrapper<CreateEndPointPropertyModel> CreateEndPointProperty(CreateEndPointPropertyInputModel model);
        
        ResponseWrapper<EditEndPointPropertyModel> EditEndPointProperty(int endpointpropertyId,EditEndPointPropertyInputModel model);
        
        ResponseWrapper<List<GetAllEndPointPropertyEndPointModelPropertiesModel>> GetAllEndPointPropertyEndPointModelProperties(int endpointpropertyId);
        
        ResponseWrapper<List<GetAllEndPointPropertyEndPointCollectionPropertiesModel>> GetAllEndPointPropertyEndPointCollectionProperties(int endpointpropertyId);
        
        ResponseWrapper<List<GetAllEndPointPropertyEndPointDefaultPropertiesModel>> GetAllEndPointPropertyEndPointDefaultProperties(int endpointpropertyId);
    }
    
    
    public class EndPointPropertyOrchestrator : IEndPointPropertyOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public EndPointPropertyOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllEndPointPropertyModel>> GetAllEndPointProperties()
        {
            var response = context
                .EndPointProperties
                    .Select(x =>
                        new GetAllEndPointPropertyModel
                        {
                            EndPointPropertyId = x.EndPointPropertyId,
                            Name = x.Name,
                            EndPointPropertyType = x.EndPointPropertyType,
                            EntityId = x.EntityId,
                            DataSourceId = x.DataSourceId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEndPointPropertyModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEndPointPropertyDetailsModel> GetEndPointPropertyDetails(int endpointpropertyId)
        {
            var data = context
                .EndPointProperties
                .Single(x => 
                    x.EndPointPropertyId == endpointpropertyId
                );
            
            var response = 
                new GetEndPointPropertyDetailsModel
                {
                    EndPointPropertyId = data.EndPointPropertyId,
                    Name = data.Name,
                    EndPointPropertyType = data.EndPointPropertyType,
                    EntityId = data.EntityId,
                    DataSourceId = data.DataSourceId,
                };
            
            return new ResponseWrapper<GetEndPointPropertyDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateEndPointPropertyModel> CreateEndPointProperty(CreateEndPointPropertyInputModel model)
        {
            var newEntity = new EndPointProperty
            {
                Name = model.Name,
                EndPointPropertyType = model.EndPointPropertyType,
                EntityId = model.EntityId,
                DataSourceId = model.DataSourceId,
            };
            
            context
                .EndPointProperties
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateEndPointPropertyModel
            {
                EndPointPropertyId = newEntity.EndPointPropertyId,
                Name = newEntity.Name,
                EndPointPropertyType = newEntity.EndPointPropertyType,
                EntityId = newEntity.EntityId,
                DataSourceId = newEntity.DataSourceId,
            };
            
            return new ResponseWrapper<CreateEndPointPropertyModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditEndPointPropertyModel> EditEndPointProperty(int endpointpropertyId, EditEndPointPropertyInputModel model)
        {
            var entity = context
                .EndPointProperties
                .Single(x => 
                    x.EndPointPropertyId == endpointpropertyId
                );
            
            entity.Name = model.Name;
            entity.EndPointPropertyType = model.EndPointPropertyType;
            entity.EntityId = model.EntityId;
            entity.DataSourceId = model.DataSourceId;
            context.SaveChanges();
            var response = new EditEndPointPropertyModel
            {
                EndPointPropertyId = entity.EndPointPropertyId,
                Name = entity.Name,
                EndPointPropertyType = entity.EndPointPropertyType,
                EntityId = entity.EntityId,
                DataSourceId = entity.DataSourceId,
            };
            
            return new ResponseWrapper<EditEndPointPropertyModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllEndPointPropertyEndPointModelPropertiesModel>> GetAllEndPointPropertyEndPointModelProperties(int endpointpropertyId)
        {
            var response = context
                .EndPointProperties
                .Include(i => i.EndPointModelProperties)
                .Single(x => 
                    x.EndPointPropertyId == endpointpropertyId
                )
                .EndPointModelProperties
                    .Select(x =>
                        new GetAllEndPointPropertyEndPointModelPropertiesModel
                        {
                            EndPointModelPropertyId = x.EndPointModelPropertyId,
                            EndPointModelId = x.EndPointModelId,
                            EndPointPropertyId = x.EndPointPropertyId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEndPointPropertyEndPointModelPropertiesModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllEndPointPropertyEndPointCollectionPropertiesModel>> GetAllEndPointPropertyEndPointCollectionProperties(int endpointpropertyId)
        {
            var response = context
                .EndPointProperties
                .Include(i => i.EndPointCollectionProperties)
                .Single(x => 
                    x.EndPointPropertyId == endpointpropertyId
                )
                .EndPointCollectionProperties
                    .Select(x =>
                        new GetAllEndPointPropertyEndPointCollectionPropertiesModel
                        {
                            EndPointCollectionPropertyId = x.EndPointCollectionPropertyId,
                            PropertiesEndPointPropertyId = x.PropertiesEndPointPropertyId,
                            EndPointPropertyId = x.EndPointPropertyId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEndPointPropertyEndPointCollectionPropertiesModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllEndPointPropertyEndPointDefaultPropertiesModel>> GetAllEndPointPropertyEndPointDefaultProperties(int endpointpropertyId)
        {
            var response = context
                .EndPointProperties
                .Include(i => i.EndPointDefaultProperties)
                .Single(x => 
                    x.EndPointPropertyId == endpointpropertyId
                )
                .EndPointDefaultProperties
                    .Select(x =>
                        new GetAllEndPointPropertyEndPointDefaultPropertiesModel
                        {
                            EndPointDefaultPropertyId = x.EndPointDefaultPropertyId,
                            DataType = x.DataType,
                            EndPointPropertyId = x.EndPointPropertyId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEndPointPropertyEndPointDefaultPropertiesModel>>(_validationDictionary, response);
        }
    }
}