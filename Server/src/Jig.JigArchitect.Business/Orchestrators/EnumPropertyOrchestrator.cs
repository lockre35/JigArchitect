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
    
    public interface IEnumPropertyOrchestrator
    {
        ResponseWrapper<List<GetAllEnumPropertyModel>> GetAllEnumProperties();
        
        ResponseWrapper<GetEnumPropertyDetailsModel> GetEnumPropertyDetails(int enumpropertyId);
        
        ResponseWrapper<CreateEnumPropertyModel> CreateEnumProperty(CreateEnumPropertyInputModel model);
        
        ResponseWrapper<EditEnumPropertyModel> EditEnumProperty(int enumpropertyId,EditEnumPropertyInputModel model);
        
        ResponseWrapper<List<GetAllEnumPropertyEnumPropertyValuesModel>> GetAllEnumPropertyEnumPropertyValues(int enumpropertyId);
    }
    
    
    public class EnumPropertyOrchestrator : IEnumPropertyOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public EnumPropertyOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllEnumPropertyModel>> GetAllEnumProperties()
        {
            var response = context
                .EnumProperties
                    .Select(x =>
                        new GetAllEnumPropertyModel
                        {
                            EnumPropertyId = x.EnumPropertyId,
                            Name = x.Name,
                            PropertyId = x.PropertyId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEnumPropertyModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEnumPropertyDetailsModel> GetEnumPropertyDetails(int enumpropertyId)
        {
            var data = context
                .EnumProperties
                .Single(x => 
                    x.EnumPropertyId == enumpropertyId
                );
            
            var response = 
                new GetEnumPropertyDetailsModel
                {
                    EnumPropertyId = data.EnumPropertyId,
                    Name = data.Name,
                    PropertyId = data.PropertyId,
                };
            
            return new ResponseWrapper<GetEnumPropertyDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateEnumPropertyModel> CreateEnumProperty(CreateEnumPropertyInputModel model)
        {
            var newEntity = new EnumProperty
            {
                Name = model.Name,
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
                .EnumProperties
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateEnumPropertyModel
            {
                EnumPropertyId = newEntity.EnumPropertyId,
                Name = newEntity.Name,
                PropertyId = newEntity.PropertyId,
            };
            
            return new ResponseWrapper<CreateEnumPropertyModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditEnumPropertyModel> EditEnumProperty(int enumpropertyId, EditEnumPropertyInputModel model)
        {
            var entity = context
                .EnumProperties
                .Single(x => 
                    x.EnumPropertyId == enumpropertyId
                );
            
            entity.Name = model.Name;
            entity.PropertyId = model.PropertyId;
            context.SaveChanges();
            var response = new EditEnumPropertyModel
            {
                EnumPropertyId = entity.EnumPropertyId,
                Name = entity.Name,
                PropertyId = entity.PropertyId,
            };
            
            return new ResponseWrapper<EditEnumPropertyModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllEnumPropertyEnumPropertyValuesModel>> GetAllEnumPropertyEnumPropertyValues(int enumpropertyId)
        {
            var response = context
                .EnumProperties
                .Include(i => i.EnumPropertyValues)
                .Single(x => 
                    x.EnumPropertyId == enumpropertyId
                )
                .EnumPropertyValues
                    .Select(x =>
                        new GetAllEnumPropertyEnumPropertyValuesModel
                        {
                            EnumPropertyValueId = x.EnumPropertyValueId,
                            Name = x.Name,
                            EnumPropertyId = x.EnumPropertyId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEnumPropertyEnumPropertyValuesModel>>(_validationDictionary, response);
        }
    }
}