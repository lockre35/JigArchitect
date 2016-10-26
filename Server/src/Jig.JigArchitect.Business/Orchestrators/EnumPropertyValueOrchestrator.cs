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
    
    public interface IEnumPropertyValueOrchestrator
    {
        ResponseWrapper<List<GetAllEnumPropertyValueModel>> GetAllEnumPropertyValues();
        
        ResponseWrapper<GetEnumPropertyValueDetailsModel> GetEnumPropertyValueDetails(int enumpropertyvalueId);
        
        ResponseWrapper<CreateEnumPropertyValueModel> CreateEnumPropertyValue(CreateEnumPropertyValueInputModel model);
        
        ResponseWrapper<EditEnumPropertyValueModel> EditEnumPropertyValue(int enumpropertyvalueId,EditEnumPropertyValueInputModel model);
    }
    
    
    public class EnumPropertyValueOrchestrator : IEnumPropertyValueOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public EnumPropertyValueOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllEnumPropertyValueModel>> GetAllEnumPropertyValues()
        {
            var response = context
                .EnumPropertyValues
                    .Select(x =>
                        new GetAllEnumPropertyValueModel
                        {
                            EnumPropertyValueId = x.EnumPropertyValueId,
                            Name = x.Name,
                            EnumPropertyId = x.EnumPropertyId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEnumPropertyValueModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEnumPropertyValueDetailsModel> GetEnumPropertyValueDetails(int enumpropertyvalueId)
        {
            var data = context
                .EnumPropertyValues
                .Single(x => 
                    x.EnumPropertyValueId == enumpropertyvalueId
                );
            
            var response = 
                new GetEnumPropertyValueDetailsModel
                {
                    EnumPropertyValueId = data.EnumPropertyValueId,
                    Name = data.Name,
                    EnumPropertyId = data.EnumPropertyId,
                };
            
            return new ResponseWrapper<GetEnumPropertyValueDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateEnumPropertyValueModel> CreateEnumPropertyValue(CreateEnumPropertyValueInputModel model)
        {
            var newEntity = new EnumPropertyValue
            {
                Name = model.Name,
                EnumPropertyId = model.EnumPropertyId,
            };
            
            context
                .EnumPropertyValues
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateEnumPropertyValueModel
            {
                EnumPropertyValueId = newEntity.EnumPropertyValueId,
                Name = newEntity.Name,
                EnumPropertyId = newEntity.EnumPropertyId,
            };
            
            return new ResponseWrapper<CreateEnumPropertyValueModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditEnumPropertyValueModel> EditEnumPropertyValue(int enumpropertyvalueId, EditEnumPropertyValueInputModel model)
        {
            var entity = context
                .EnumPropertyValues
                .Single(x => 
                    x.EnumPropertyValueId == enumpropertyvalueId
                );
            
            entity.Name = model.Name;
            entity.EnumPropertyId = model.EnumPropertyId;
            context.SaveChanges();
            var response = new EditEnumPropertyValueModel
            {
                EnumPropertyValueId = entity.EnumPropertyValueId,
                Name = entity.Name,
                EnumPropertyId = entity.EnumPropertyId,
            };
            
            return new ResponseWrapper<EditEnumPropertyValueModel>(_validationDictionary, response);
        }
    }
}