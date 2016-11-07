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
    
    public interface ISchemaOrchestrator
    {
        ResponseWrapper<List<GetAllSchemaModel>> GetAllSchemas();
        
        ResponseWrapper<GetSchemaDetailsModel> GetSchemaDetails(int schemaId);
        
        ResponseWrapper<CreateSchemaModel> CreateSchema(CreateSchemaInputModel model);
        
        ResponseWrapper<EditSchemaModel> EditSchema(int schemaId,EditSchemaInputModel model);
        
        ResponseWrapper<List<GetAllSchemaEntitiesModel>> GetAllSchemaEntities(int schemaId);
    }
    
    
    public class SchemaOrchestrator : ISchemaOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public SchemaOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllSchemaModel>> GetAllSchemas()
        {
            var response = context
                .Schemas
                    .Select(x =>
                        new GetAllSchemaModel
                        {
                            Name = x.Name,
                            SchemaId = x.SchemaId,
                            ApplicationId = x.ApplicationId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllSchemaModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetSchemaDetailsModel> GetSchemaDetails(int schemaId)
        {
            var data = context
                .Schemas
                .Single(x => 
                    x.SchemaId == schemaId
                );
            
            var response = 
                new GetSchemaDetailsModel
                {
                    Name = data.Name,
                    SchemaId = data.SchemaId,
                    ApplicationId = data.ApplicationId,
                };
            
            return new ResponseWrapper<GetSchemaDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateSchemaModel> CreateSchema(CreateSchemaInputModel model)
        {
            var newEntity = new Schema
            {
                Name = model.Name,
                ApplicationId = model.ApplicationId,
            };
            
            context
                .Schemas
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateSchemaModel
            {
                Name = newEntity.Name,
                SchemaId = newEntity.SchemaId,
                ApplicationId = newEntity.ApplicationId,
            };
            
            return new ResponseWrapper<CreateSchemaModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditSchemaModel> EditSchema(int schemaId, EditSchemaInputModel model)
        {
            var entity = context
                .Schemas
                .Single(x => 
                    x.SchemaId == schemaId
                );
            
            entity.Name = model.Name;
            entity.ApplicationId = model.ApplicationId;
            context.SaveChanges();
            var response = new EditSchemaModel
            {
                Name = entity.Name,
                SchemaId = entity.SchemaId,
                ApplicationId = entity.ApplicationId,
            };
            
            return new ResponseWrapper<EditSchemaModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllSchemaEntitiesModel>> GetAllSchemaEntities(int schemaId)
        {
            var response = context
                .Schemas
                .Include(i => i.Entities)
                .Single(x => 
                    x.SchemaId == schemaId
                )
                .Entities
                    .Select(x =>
                        new GetAllSchemaEntitiesModel
                        {
                            EntityId = x.EntityId,
                            Name = x.Name,
                            PluralName = x.PluralName,
                            SchemaId = x.SchemaId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllSchemaEntitiesModel>>(_validationDictionary, response);
        }
    }
}