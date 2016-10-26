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
    
    public interface IEndPointModelPropertyOrchestrator
    {
        ResponseWrapper<List<GetAllEndPointModelPropertyModel>> GetAllEndPointModelProperties();
        
        ResponseWrapper<GetEndPointModelPropertyDetailsModel> GetEndPointModelPropertyDetails(int endpointmodelpropertyId);
        
        ResponseWrapper<CreateEndPointModelPropertyModel> CreateEndPointModelProperty(CreateEndPointModelPropertyInputModel model);
        
        ResponseWrapper<EditEndPointModelPropertyModel> EditEndPointModelProperty(int endpointmodelpropertyId,EditEndPointModelPropertyInputModel model);
    }
    
    
    public class EndPointModelPropertyOrchestrator : IEndPointModelPropertyOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public EndPointModelPropertyOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllEndPointModelPropertyModel>> GetAllEndPointModelProperties()
        {
            var response = context
                .EndPointModelProperties
                    .Select(x =>
                        new GetAllEndPointModelPropertyModel
                        {
                            EndPointModelPropertyId = x.EndPointModelPropertyId,
                            EndPointModelId = x.EndPointModelId,
                            EndPointPropertyId = x.EndPointPropertyId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEndPointModelPropertyModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEndPointModelPropertyDetailsModel> GetEndPointModelPropertyDetails(int endpointmodelpropertyId)
        {
            var data = context
                .EndPointModelProperties
                .Single(x => 
                    x.EndPointModelPropertyId == endpointmodelpropertyId
                );
            
            var response = 
                new GetEndPointModelPropertyDetailsModel
                {
                    EndPointModelPropertyId = data.EndPointModelPropertyId,
                    EndPointModelId = data.EndPointModelId,
                    EndPointPropertyId = data.EndPointPropertyId,
                };
            
            return new ResponseWrapper<GetEndPointModelPropertyDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateEndPointModelPropertyModel> CreateEndPointModelProperty(CreateEndPointModelPropertyInputModel model)
        {
            var newEntity = new EndPointModelProperty
            {
                EndPointModelId = model.EndPointModelId,
                EndPointPropertyId = model.EndPointPropertyId,
                EndPointProperty = 
                        new EndPointProperty
                        {
                            Name = model.EndPointProperty.Name,
                            EndPointPropertyType = model.EndPointProperty.EndPointPropertyType,
                            EntityId = model.EndPointProperty.EntityId,
                            DataSourceId = model.EndPointProperty.DataSourceId,
                        },
            };
            
            context
                .EndPointModelProperties
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateEndPointModelPropertyModel
            {
                EndPointModelPropertyId = newEntity.EndPointModelPropertyId,
                EndPointModelId = newEntity.EndPointModelId,
                EndPointPropertyId = newEntity.EndPointPropertyId,
            };
            
            return new ResponseWrapper<CreateEndPointModelPropertyModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditEndPointModelPropertyModel> EditEndPointModelProperty(int endpointmodelpropertyId, EditEndPointModelPropertyInputModel model)
        {
            var entity = context
                .EndPointModelProperties
                .Single(x => 
                    x.EndPointModelPropertyId == endpointmodelpropertyId
                );
            
            entity.EndPointModelId = model.EndPointModelId;
            entity.EndPointPropertyId = model.EndPointPropertyId;
            context.SaveChanges();
            var response = new EditEndPointModelPropertyModel
            {
                EndPointModelPropertyId = entity.EndPointModelPropertyId,
                EndPointModelId = entity.EndPointModelId,
                EndPointPropertyId = entity.EndPointPropertyId,
            };
            
            return new ResponseWrapper<EditEndPointModelPropertyModel>(_validationDictionary, response);
        }
    }
}