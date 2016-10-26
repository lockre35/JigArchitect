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
    
    public interface IEntityOrchestrator
    {
        ResponseWrapper<List<GetAllEntityModel>> GetAllEntities();
        
        ResponseWrapper<GetEntityDetailsModel> GetEntityDetails(int entityId);
        
        ResponseWrapper<CreateEntityModel> CreateEntity(CreateEntityInputModel model);
        
        ResponseWrapper<EditEntityModel> EditEntity(int entityId,EditEntityInputModel model);
        
        ResponseWrapper<List<GetAllEntityPropertiesModel>> GetAllEntityProperties(int entityId);
        
        ResponseWrapper<List<GetAllEntityParentRelationshipsModel>> GetAllEntityParentRelationships(int entityId);
        
        ResponseWrapper<List<GetAllEntityChildrenRelationshipsModel>> GetAllEntityChildrenRelationships(int entityId);
        
        ResponseWrapper<List<GetAllEntityEndPointPropertiesModel>> GetAllEntityEndPointProperties(int entityId);
    }
    
    
    public class EntityOrchestrator : IEntityOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public EntityOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllEntityModel>> GetAllEntities()
        {
            var response = context
                .Entities
                    .Select(x =>
                        new GetAllEntityModel
                        {
                            EntityId = x.EntityId,
                            Name = x.Name,
                            PluralName = x.PluralName,
                            SchemaId = x.SchemaId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEntityModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEntityDetailsModel> GetEntityDetails(int entityId)
        {
            var data = context
                .Entities
                .Single(x => 
                    x.EntityId == entityId
                );
            
            var response = 
                new GetEntityDetailsModel
                {
                    EntityId = data.EntityId,
                    Name = data.Name,
                    PluralName = data.PluralName,
                    SchemaId = data.SchemaId,
                };
            
            return new ResponseWrapper<GetEntityDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateEntityModel> CreateEntity(CreateEntityInputModel model)
        {
            var newEntity = new Entity
            {
                Name = model.Name,
                PluralName = model.PluralName,
                SchemaId = model.SchemaId,
            };
            
            context
                .Entities
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateEntityModel
            {
                EntityId = newEntity.EntityId,
                Name = newEntity.Name,
                PluralName = newEntity.PluralName,
                SchemaId = newEntity.SchemaId,
            };
            
            return new ResponseWrapper<CreateEntityModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditEntityModel> EditEntity(int entityId, EditEntityInputModel model)
        {
            var entity = context
                .Entities
                .Single(x => 
                    x.EntityId == entityId
                );
            
            entity.Name = model.Name;
            entity.PluralName = model.PluralName;
            entity.SchemaId = model.SchemaId;
            context.SaveChanges();
            var response = new EditEntityModel
            {
                EntityId = entity.EntityId,
                Name = entity.Name,
                PluralName = entity.PluralName,
                SchemaId = entity.SchemaId,
            };
            
            return new ResponseWrapper<EditEntityModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllEntityPropertiesModel>> GetAllEntityProperties(int entityId)
        {
            var response = context
                .Entities
                .Include(i => i.Properties)
                .Single(x => 
                    x.EntityId == entityId
                )
                .Properties
                    .Select(x =>
                        new GetAllEntityPropertiesModel
                        {
                            PropertyId = x.PropertyId,
                            Name = x.Name,
                            PropertyType = x.PropertyType,
                            EntityId = x.EntityId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEntityPropertiesModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllEntityParentRelationshipsModel>> GetAllEntityParentRelationships(int entityId)
        {
            var response = context
                .Entities
                .Include(i => i.ParentRelationships)
                .Single(x => 
                    x.EntityId == entityId
                )
                .ParentRelationships
                    .Select(x =>
                        new GetAllEntityParentRelationshipsModel
                        {
                            RelationshipId = x.RelationshipId,
                            RelationshipType = x.RelationshipType,
                            ParentEntityEntityId = x.ParentEntityEntityId,
                            ChildEntityEntityId = x.ChildEntityEntityId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEntityParentRelationshipsModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllEntityChildrenRelationshipsModel>> GetAllEntityChildrenRelationships(int entityId)
        {
            var response = context
                .Entities
                .Include(i => i.ChildrenRelationships)
                .Single(x => 
                    x.EntityId == entityId
                )
                .ChildrenRelationships
                    .Select(x =>
                        new GetAllEntityChildrenRelationshipsModel
                        {
                            RelationshipId = x.RelationshipId,
                            RelationshipType = x.RelationshipType,
                            ParentEntityEntityId = x.ParentEntityEntityId,
                            ChildEntityEntityId = x.ChildEntityEntityId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEntityChildrenRelationshipsModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllEntityEndPointPropertiesModel>> GetAllEntityEndPointProperties(int entityId)
        {
            var response = context
                .Entities
                .Include(i => i.EndPointProperties)
                .Single(x => 
                    x.EntityId == entityId
                )
                .EndPointProperties
                    .Select(x =>
                        new GetAllEntityEndPointPropertiesModel
                        {
                            EndPointPropertyId = x.EndPointPropertyId,
                            Name = x.Name,
                            EndPointPropertyType = x.EndPointPropertyType,
                            EntityId = x.EntityId,
                            DataSourceId = x.DataSourceId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEntityEndPointPropertiesModel>>(_validationDictionary, response);
        }
    }
}