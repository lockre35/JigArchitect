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
    
    public interface IEndPointDefaultPropertyOrchestrator
    {
        ResponseWrapper<List<GetAllEndPointDefaultPropertyModel>> GetAllEndPointDefaultProperties();
        
        ResponseWrapper<GetEndPointDefaultPropertyDetailsModel> GetEndPointDefaultPropertyDetails(int endpointdefaultpropertyId);
        
        ResponseWrapper<CreateEndPointDefaultPropertyModel> CreateEndPointDefaultProperty(CreateEndPointDefaultPropertyInputModel model);
        
        ResponseWrapper<EditEndPointDefaultPropertyModel> EditEndPointDefaultProperty(int endpointdefaultpropertyId,EditEndPointDefaultPropertyInputModel model);
    }
    
    
    public class EndPointDefaultPropertyOrchestrator : IEndPointDefaultPropertyOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public EndPointDefaultPropertyOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllEndPointDefaultPropertyModel>> GetAllEndPointDefaultProperties()
        {
            var response = context
                .EndPointDefaultProperties
                    .Select(x =>
                        new GetAllEndPointDefaultPropertyModel
                        {
                            EndPointDefaultPropertyId = x.EndPointDefaultPropertyId,
                            DataType = x.DataType,
                            EndPointPropertyId = x.EndPointPropertyId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEndPointDefaultPropertyModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEndPointDefaultPropertyDetailsModel> GetEndPointDefaultPropertyDetails(int endpointdefaultpropertyId)
        {
            var data = context
                .EndPointDefaultProperties
                .Single(x => 
                    x.EndPointDefaultPropertyId == endpointdefaultpropertyId
                );
            
            var response = 
                new GetEndPointDefaultPropertyDetailsModel
                {
                    EndPointDefaultPropertyId = data.EndPointDefaultPropertyId,
                    DataType = data.DataType,
                    EndPointPropertyId = data.EndPointPropertyId,
                };
            
            return new ResponseWrapper<GetEndPointDefaultPropertyDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateEndPointDefaultPropertyModel> CreateEndPointDefaultProperty(CreateEndPointDefaultPropertyInputModel model)
        {
            var newEntity = new EndPointDefaultProperty
            {
                DataType = model.DataType,
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
                .EndPointDefaultProperties
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateEndPointDefaultPropertyModel
            {
                EndPointDefaultPropertyId = newEntity.EndPointDefaultPropertyId,
                DataType = newEntity.DataType,
                EndPointPropertyId = newEntity.EndPointPropertyId,
            };
            
            return new ResponseWrapper<CreateEndPointDefaultPropertyModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditEndPointDefaultPropertyModel> EditEndPointDefaultProperty(int endpointdefaultpropertyId, EditEndPointDefaultPropertyInputModel model)
        {
            var entity = context
                .EndPointDefaultProperties
                .Single(x => 
                    x.EndPointDefaultPropertyId == endpointdefaultpropertyId
                );
            
            entity.DataType = model.DataType;
            entity.EndPointPropertyId = model.EndPointPropertyId;
            context.SaveChanges();
            var response = new EditEndPointDefaultPropertyModel
            {
                EndPointDefaultPropertyId = entity.EndPointDefaultPropertyId,
                DataType = entity.DataType,
                EndPointPropertyId = entity.EndPointPropertyId,
            };
            
            return new ResponseWrapper<EditEndPointDefaultPropertyModel>(_validationDictionary, response);
        }
    }
}