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
    
    public interface IPropertyOrchestrator
    {
        ResponseWrapper<List<GetAllPropertyModel>> GetAllProperties();
        
        ResponseWrapper<GetPropertyDetailsModel> GetPropertyDetails(int propertyId);
        
        ResponseWrapper<CreatePropertyModel> CreateProperty(CreatePropertyInputModel model);
        
        ResponseWrapper<EditPropertyModel> EditProperty(int propertyId,EditPropertyInputModel model);
        
        ResponseWrapper<GetPropertyIntPropertyModel> GetPropertyIntProperty(int propertyId);
        
        ResponseWrapper<GetPropertyEnumPropertyModel> GetPropertyEnumProperty(int propertyId);
    }
    
    
    public class PropertyOrchestrator : IPropertyOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public PropertyOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllPropertyModel>> GetAllProperties()
        {
            var response = context
                .Properties
                    .Select(x =>
                        new GetAllPropertyModel
                        {
                            PropertyId = x.PropertyId,
                            Name = x.Name,
                            PropertyType = x.PropertyType,
                            EntityId = x.EntityId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllPropertyModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetPropertyDetailsModel> GetPropertyDetails(int propertyId)
        {
            var data = context
                .Properties
                .Single(x => 
                    x.PropertyId == propertyId
                );
            
            var response = 
                new GetPropertyDetailsModel
                {
                    PropertyId = data.PropertyId,
                    Name = data.Name,
                    PropertyType = data.PropertyType,
                    EntityId = data.EntityId,
                };
            
            return new ResponseWrapper<GetPropertyDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreatePropertyModel> CreateProperty(CreatePropertyInputModel model)
        {
            var newEntity = new Property
            {
                Name = model.Name,
                PropertyType = model.PropertyType,
                EntityId = model.EntityId,
            };
            
            context
                .Properties
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreatePropertyModel
            {
                PropertyId = newEntity.PropertyId,
                Name = newEntity.Name,
                PropertyType = newEntity.PropertyType,
                EntityId = newEntity.EntityId,
            };
            
            return new ResponseWrapper<CreatePropertyModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditPropertyModel> EditProperty(int propertyId, EditPropertyInputModel model)
        {
            var entity = context
                .Properties
                .Single(x => 
                    x.PropertyId == propertyId
                );
            
            entity.Name = model.Name;
            entity.PropertyType = model.PropertyType;
            entity.EntityId = model.EntityId;
            context.SaveChanges();
            var response = new EditPropertyModel
            {
                PropertyId = entity.PropertyId,
                Name = entity.Name,
                PropertyType = entity.PropertyType,
                EntityId = entity.EntityId,
            };
            
            return new ResponseWrapper<EditPropertyModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetPropertyIntPropertyModel> GetPropertyIntProperty(int propertyId)
        {
            var data = context
                .Properties
                .Include(i => i.IntProperty)
                .Single(x => 
                    x.PropertyId == propertyId
                )
                .IntProperty;
            
            var response = 
                new GetPropertyIntPropertyModel
                {
                    IntPropertyId = data.IntPropertyId,
                    MaxValue = data.MaxValue,
                    MinValue = data.MinValue,
                    PropertyId = data.PropertyId,
                };
            
            return new ResponseWrapper<GetPropertyIntPropertyModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetPropertyEnumPropertyModel> GetPropertyEnumProperty(int propertyId)
        {
            var data = context
                .Properties
                .Include(i => i.EnumProperty)
                .Single(x => 
                    x.PropertyId == propertyId
                )
                .EnumProperty;
            
            var response = 
                new GetPropertyEnumPropertyModel
                {
                    EnumPropertyId = data.EnumPropertyId,
                    Name = data.Name,
                    PropertyId = data.PropertyId,
                };
            
            return new ResponseWrapper<GetPropertyEnumPropertyModel>(_validationDictionary, response);
        }
    }
}