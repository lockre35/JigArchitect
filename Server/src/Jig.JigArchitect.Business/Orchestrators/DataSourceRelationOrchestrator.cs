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
    
    public interface IDataSourceRelationOrchestrator
    {
        ResponseWrapper<List<GetAllDataSourceRelationModel>> GetAllDataSourceRelations();
        
        ResponseWrapper<GetDataSourceRelationDetailsModel> GetDataSourceRelationDetails(int datasourcerelationId);
        
        ResponseWrapper<CreateDataSourceRelationModel> CreateDataSourceRelation(CreateDataSourceRelationInputModel model);
        
        ResponseWrapper<EditDataSourceRelationModel> EditDataSourceRelation(int datasourcerelationId,EditDataSourceRelationInputModel model);
    }
    
    
    public class DataSourceRelationOrchestrator : IDataSourceRelationOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public DataSourceRelationOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllDataSourceRelationModel>> GetAllDataSourceRelations()
        {
            var response = context
                .DataSourceRelations
                    .Select(x =>
                        new GetAllDataSourceRelationModel
                        {
                            DataSourceRelationId = x.DataSourceRelationId,
                            UseChildEntity = x.UseChildEntity,
                            RecursiveRelationDataSourceRelationId = x.RecursiveRelationDataSourceRelationId,
                            EntityRelationRelationshipId = x.EntityRelationRelationshipId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllDataSourceRelationModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetDataSourceRelationDetailsModel> GetDataSourceRelationDetails(int datasourcerelationId)
        {
            var data = context
                .DataSourceRelations
                .Single(x => 
                    x.DataSourceRelationId == datasourcerelationId
                );
            
            var response = 
                new GetDataSourceRelationDetailsModel
                {
                    DataSourceRelationId = data.DataSourceRelationId,
                    UseChildEntity = data.UseChildEntity,
                    RecursiveRelationDataSourceRelationId = data.RecursiveRelationDataSourceRelationId,
                    EntityRelationRelationshipId = data.EntityRelationRelationshipId,
                };
            
            return new ResponseWrapper<GetDataSourceRelationDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateDataSourceRelationModel> CreateDataSourceRelation(CreateDataSourceRelationInputModel model)
        {
            var newEntity = new DataSourceRelation
            {
                UseChildEntity = model.UseChildEntity,
                RecursiveRelationDataSourceRelationId = model.RecursiveRelationDataSourceRelationId,
                EntityRelationRelationshipId = model.EntityRelationRelationshipId,
            };
            
            context
                .DataSourceRelations
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateDataSourceRelationModel
            {
                DataSourceRelationId = newEntity.DataSourceRelationId,
                UseChildEntity = newEntity.UseChildEntity,
                RecursiveRelationDataSourceRelationId = newEntity.RecursiveRelationDataSourceRelationId,
                EntityRelationRelationshipId = newEntity.EntityRelationRelationshipId,
            };
            
            return new ResponseWrapper<CreateDataSourceRelationModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditDataSourceRelationModel> EditDataSourceRelation(int datasourcerelationId, EditDataSourceRelationInputModel model)
        {
            var entity = context
                .DataSourceRelations
                .Single(x => 
                    x.DataSourceRelationId == datasourcerelationId
                );
            
            entity.UseChildEntity = model.UseChildEntity;
            entity.RecursiveRelationDataSourceRelationId = model.RecursiveRelationDataSourceRelationId;
            entity.EntityRelationRelationshipId = model.EntityRelationRelationshipId;
            context.SaveChanges();
            var response = new EditDataSourceRelationModel
            {
                DataSourceRelationId = entity.DataSourceRelationId,
                UseChildEntity = entity.UseChildEntity,
                RecursiveRelationDataSourceRelationId = entity.RecursiveRelationDataSourceRelationId,
                EntityRelationRelationshipId = entity.EntityRelationRelationshipId,
            };
            
            return new ResponseWrapper<EditDataSourceRelationModel>(_validationDictionary, response);
        }
    }
}