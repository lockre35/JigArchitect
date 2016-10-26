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
    
    public interface IEntityTestOrchestrator
    {
        ResponseWrapper<List<EntityModel>> Get();
        
        ResponseWrapper<List<CustomEntityModel>> Custom();
        
        ResponseWrapper<EntityDetailsModel> EntityDetails(int entityId);
        
        ResponseWrapper<List<EntityPropertyModel>> EntityProperties(int entityId);
        
        ResponseWrapper<EntityDeleteModel> DeleteEntity(int entityId);
        
        ResponseWrapper<EntityPutModel> PutEntity(EntityPutInputModel model);
        
        ResponseWrapper<TestEditEntityModel> EditEntity(int entityId,TestEditEntityInputModel model);
    }
    
    
    public abstract class AbstractEntityTestOrchestrator : IEntityTestOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public AbstractEntityTestOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<EntityModel>> Get()
        {
            var response = context
                .Entities
                    .Select(x =>
                        new EntityModel
                        {
                            Name = x.Name,
                            EntityId = x.EntityId,
                            SchemaName = x.Schema.Name,
                            SchemaEntities = x.Schema.Entities
                                .Select(xx =>
                                        new SchemaEntityModel
                                        {
                                            EntityId = xx.EntityId,
                                        }
                                )
                                .ToList(),
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<EntityModel>>(_validationDictionary, response);
        }
        
        public abstract ResponseWrapper<List<CustomEntityModel>> Custom();
        
        public ResponseWrapper<EntityDetailsModel> EntityDetails(int entityId)
        {
            var data = context
                .Entities
                .Single(x => 
                    x.EntityId == entityId
                );
            
            var response = 
                new EntityDetailsModel
                {
                    EntityId = data.EntityId,
                };
            
            return new ResponseWrapper<EntityDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<EntityPropertyModel>> EntityProperties(int entityId)
        {
            var response = context
                .Entities
                .Include(i => i.Properties)
                .Single(x => 
                    x.EntityId == entityId
                )
                .Properties
                    .Select(x =>
                        new EntityPropertyModel
                        {
                            PropertyId = x.PropertyId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<EntityPropertyModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EntityDeleteModel> DeleteEntity(int entityId)
        {
            var entity = context
                .Entities
                .Single(x => 
                    x.EntityId == entityId
                );
            
            context
                .Entities
                .Remove(entity);
            
            context.SaveChanges();
            
            var response = new EntityDeleteModel
            {
                EntityId = entity.EntityId,
            };
            
            return new ResponseWrapper<EntityDeleteModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EntityPutModel> PutEntity(EntityPutInputModel model)
        {
            var newEntity = new Entity
            {
                Name = model.Name,
            };
            
            context
                .Entities
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new EntityPutModel
            {
                Name = newEntity.Name,
                EntityId = newEntity.EntityId,
            };
            
            return new ResponseWrapper<EntityPutModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<TestEditEntityModel> EditEntity(int entityId, TestEditEntityInputModel model)
        {
            var entity = context
                .Entities
                .Single(x => 
                    x.EntityId == entityId
                );
            
            entity.Name = model.Name;
            entity.Properties = model.Properties
                .Select(x =>
                    new Property
                    {
                        Name = x.Name,
                    }
                )
                .ToList();
            context.SaveChanges();
            var response = new TestEditEntityModel
            {
                Name = entity.Name,
                EntityId = entity.EntityId,
            };
            
            return new ResponseWrapper<TestEditEntityModel>(_validationDictionary, response);
        }
    }
}