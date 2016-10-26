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
    
    public interface IEndPointCollectionPropertyOrchestrator
    {
        ResponseWrapper<List<GetAllEndPointCollectionPropertyModel>> GetAllEndPointCollectionProperties();
        
        ResponseWrapper<GetEndPointCollectionPropertyDetailsModel> GetEndPointCollectionPropertyDetails(int endpointcollectionpropertyId);
        
        ResponseWrapper<CreateEndPointCollectionPropertyModel> CreateEndPointCollectionProperty(CreateEndPointCollectionPropertyInputModel model);
        
        ResponseWrapper<EditEndPointCollectionPropertyModel> EditEndPointCollectionProperty(int endpointcollectionpropertyId,EditEndPointCollectionPropertyInputModel model);
    }
    
    
    public class EndPointCollectionPropertyOrchestrator : IEndPointCollectionPropertyOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public EndPointCollectionPropertyOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllEndPointCollectionPropertyModel>> GetAllEndPointCollectionProperties()
        {
            var response = context
                .EndPointCollectionProperties
                    .Select(x =>
                        new GetAllEndPointCollectionPropertyModel
                        {
                            EndPointCollectionPropertyId = x.EndPointCollectionPropertyId,
                            PropertiesEndPointPropertyId = x.PropertiesEndPointPropertyId,
                            EndPointPropertyId = x.EndPointPropertyId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEndPointCollectionPropertyModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEndPointCollectionPropertyDetailsModel> GetEndPointCollectionPropertyDetails(int endpointcollectionpropertyId)
        {
            var data = context
                .EndPointCollectionProperties
                .Single(x => 
                    x.EndPointCollectionPropertyId == endpointcollectionpropertyId
                );
            
            var response = 
                new GetEndPointCollectionPropertyDetailsModel
                {
                    EndPointCollectionPropertyId = data.EndPointCollectionPropertyId,
                    PropertiesEndPointPropertyId = data.PropertiesEndPointPropertyId,
                    EndPointPropertyId = data.EndPointPropertyId,
                };
            
            return new ResponseWrapper<GetEndPointCollectionPropertyDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateEndPointCollectionPropertyModel> CreateEndPointCollectionProperty(CreateEndPointCollectionPropertyInputModel model)
        {
            var newEntity = new EndPointCollectionProperty
            {
                PropertiesEndPointPropertyId = model.PropertiesEndPointPropertyId,
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
                .EndPointCollectionProperties
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateEndPointCollectionPropertyModel
            {
                EndPointCollectionPropertyId = newEntity.EndPointCollectionPropertyId,
                PropertiesEndPointPropertyId = newEntity.PropertiesEndPointPropertyId,
                EndPointPropertyId = newEntity.EndPointPropertyId,
            };
            
            return new ResponseWrapper<CreateEndPointCollectionPropertyModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditEndPointCollectionPropertyModel> EditEndPointCollectionProperty(int endpointcollectionpropertyId, EditEndPointCollectionPropertyInputModel model)
        {
            var entity = context
                .EndPointCollectionProperties
                .Single(x => 
                    x.EndPointCollectionPropertyId == endpointcollectionpropertyId
                );
            
            entity.PropertiesEndPointPropertyId = model.PropertiesEndPointPropertyId;
            entity.EndPointPropertyId = model.EndPointPropertyId;
            context.SaveChanges();
            var response = new EditEndPointCollectionPropertyModel
            {
                EndPointCollectionPropertyId = entity.EndPointCollectionPropertyId,
                PropertiesEndPointPropertyId = entity.PropertiesEndPointPropertyId,
                EndPointPropertyId = entity.EndPointPropertyId,
            };
            
            return new ResponseWrapper<EditEndPointCollectionPropertyModel>(_validationDictionary, response);
        }
    }
}