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
    
    public interface IDataSourceOrchestrator
    {
        ResponseWrapper<List<GetAllDataSourceModel>> GetAllDataSources();
        
        ResponseWrapper<GetDataSourceDetailsModel> GetDataSourceDetails(int datasourceId);
        
        ResponseWrapper<CreateDataSourceModel> CreateDataSource(CreateDataSourceInputModel model);
        
        ResponseWrapper<EditDataSourceModel> EditDataSource(int datasourceId,EditDataSourceInputModel model);
    }
    
    
    public class DataSourceOrchestrator : IDataSourceOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public DataSourceOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllDataSourceModel>> GetAllDataSources()
        {
            var response = context
                .DataSources
                    .Select(x =>
                        new GetAllDataSourceModel
                        {
                            DataSourceId = x.DataSourceId,
                            EntityPropertyPropertyId = x.EntityPropertyPropertyId,
                            DataSourceRelationId = x.DataSourceRelationId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllDataSourceModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetDataSourceDetailsModel> GetDataSourceDetails(int datasourceId)
        {
            var data = context
                .DataSources
                .Single(x => 
                    x.DataSourceId == datasourceId
                );
            
            var response = 
                new GetDataSourceDetailsModel
                {
                    DataSourceId = data.DataSourceId,
                    EntityPropertyPropertyId = data.EntityPropertyPropertyId,
                    DataSourceRelationId = data.DataSourceRelationId,
                };
            
            return new ResponseWrapper<GetDataSourceDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateDataSourceModel> CreateDataSource(CreateDataSourceInputModel model)
        {
            var newEntity = new DataSource
            {
                EntityPropertyPropertyId = model.EntityPropertyPropertyId,
                DataSourceRelationId = model.DataSourceRelationId,
            };
            
            context
                .DataSources
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateDataSourceModel
            {
                DataSourceId = newEntity.DataSourceId,
                EntityPropertyPropertyId = newEntity.EntityPropertyPropertyId,
                DataSourceRelationId = newEntity.DataSourceRelationId,
            };
            
            return new ResponseWrapper<CreateDataSourceModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditDataSourceModel> EditDataSource(int datasourceId, EditDataSourceInputModel model)
        {
            var entity = context
                .DataSources
                .Single(x => 
                    x.DataSourceId == datasourceId
                );
            
            entity.EntityPropertyPropertyId = model.EntityPropertyPropertyId;
            entity.DataSourceRelationId = model.DataSourceRelationId;
            context.SaveChanges();
            var response = new EditDataSourceModel
            {
                DataSourceId = entity.DataSourceId,
                EntityPropertyPropertyId = entity.EntityPropertyPropertyId,
                DataSourceRelationId = entity.DataSourceRelationId,
            };
            
            return new ResponseWrapper<EditDataSourceModel>(_validationDictionary, response);
        }
    }
}