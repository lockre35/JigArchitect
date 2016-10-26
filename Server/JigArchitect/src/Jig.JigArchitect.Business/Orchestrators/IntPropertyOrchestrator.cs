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
    
    public interface IIntPropertyOrchestrator
    {
        ResponseWrapper<List<GetAllIntPropertyModel>> GetAllIntProperties();
        
        ResponseWrapper<GetIntPropertyDetailsModel> GetIntPropertyDetails(int intpropertyId);
        
        ResponseWrapper<CreateIntPropertyModel> CreateIntProperty(CreateIntPropertyInputModel model);
        
        ResponseWrapper<EditIntPropertyModel> EditIntProperty(int intpropertyId,EditIntPropertyInputModel model);
    }
    
    
    public class IntPropertyOrchestrator : IIntPropertyOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public IntPropertyOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllIntPropertyModel>> GetAllIntProperties()
        {
            var response = context
                .IntProperties
                    .Select(x =>
                        new GetAllIntPropertyModel
                        {
                            IntPropertyId = x.IntPropertyId,
                            MaxValue = x.MaxValue,
                            MinValue = x.MinValue,
                            PropertyId = x.PropertyId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllIntPropertyModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetIntPropertyDetailsModel> GetIntPropertyDetails(int intpropertyId)
        {
            var data = context
                .IntProperties
                .Single(x => 
                    x.IntPropertyId == intpropertyId
                );
            
            var response = 
                new GetIntPropertyDetailsModel
                {
                    IntPropertyId = data.IntPropertyId,
                    MaxValue = data.MaxValue,
                    MinValue = data.MinValue,
                    PropertyId = data.PropertyId,
                };
            
            return new ResponseWrapper<GetIntPropertyDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateIntPropertyModel> CreateIntProperty(CreateIntPropertyInputModel model)
        {
            var newEntity = new IntProperty
            {
                MaxValue = model.MaxValue,
                MinValue = model.MinValue,
                PropertyId = model.PropertyId,
                Property = 
                        new Property
                        {
                            Name = model.Property.Name,
                            PropertyType = model.Property.PropertyType,
                            EntityId = model.Property.EntityId,
                        },
            };
            
            context
                .IntProperties
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateIntPropertyModel
            {
                IntPropertyId = newEntity.IntPropertyId,
                MaxValue = newEntity.MaxValue,
                MinValue = newEntity.MinValue,
                PropertyId = newEntity.PropertyId,
            };
            
            return new ResponseWrapper<CreateIntPropertyModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditIntPropertyModel> EditIntProperty(int intpropertyId, EditIntPropertyInputModel model)
        {
            var entity = context
                .IntProperties
                .Single(x => 
                    x.IntPropertyId == intpropertyId
                );
            
            entity.MaxValue = model.MaxValue;
            entity.MinValue = model.MinValue;
            entity.PropertyId = model.PropertyId;
            context.SaveChanges();
            var response = new EditIntPropertyModel
            {
                IntPropertyId = entity.IntPropertyId,
                MaxValue = entity.MaxValue,
                MinValue = entity.MinValue,
                PropertyId = entity.PropertyId,
            };
            
            return new ResponseWrapper<EditIntPropertyModel>(_validationDictionary, response);
        }
    }
}