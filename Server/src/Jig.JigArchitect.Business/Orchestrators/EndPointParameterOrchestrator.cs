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
    
    public interface IEndPointParameterOrchestrator
    {
        ResponseWrapper<List<GetAllEndPointParameterModel>> GetAllEndPointParameters();
        
        ResponseWrapper<GetEndPointParameterDetailsModel> GetEndPointParameterDetails(int endpointparameterId);
        
        ResponseWrapper<CreateEndPointParameterModel> CreateEndPointParameter(CreateEndPointParameterInputModel model);
        
        ResponseWrapper<EditEndPointParameterModel> EditEndPointParameter(int endpointparameterId,EditEndPointParameterInputModel model);
    }
    
    
    public class EndPointParameterOrchestrator : IEndPointParameterOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public EndPointParameterOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllEndPointParameterModel>> GetAllEndPointParameters()
        {
            var response = context
                .EndPointParameters
                    .Select(x =>
                        new GetAllEndPointParameterModel
                        {
                            EndPointParameterId = x.EndPointParameterId,
                            DataType = x.DataType,
                            EndPointParameterName = x.EndPointParameterName,
                            ParametersEndPointId = x.ParametersEndPointId,
                            DataSourceId = x.DataSourceId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEndPointParameterModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEndPointParameterDetailsModel> GetEndPointParameterDetails(int endpointparameterId)
        {
            var data = context
                .EndPointParameters
                .Single(x => 
                    x.EndPointParameterId == endpointparameterId
                );
            
            var response = 
                new GetEndPointParameterDetailsModel
                {
                    EndPointParameterId = data.EndPointParameterId,
                    DataType = data.DataType,
                    EndPointParameterName = data.EndPointParameterName,
                    ParametersEndPointId = data.ParametersEndPointId,
                    DataSourceId = data.DataSourceId,
                };
            
            return new ResponseWrapper<GetEndPointParameterDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateEndPointParameterModel> CreateEndPointParameter(CreateEndPointParameterInputModel model)
        {
            var newEntity = new EndPointParameter
            {
                DataType = model.DataType,
                EndPointParameterName = model.EndPointParameterName,
                ParametersEndPointId = model.ParametersEndPointId,
                DataSourceId = model.DataSourceId,
            };
            
            context
                .EndPointParameters
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateEndPointParameterModel
            {
                EndPointParameterId = newEntity.EndPointParameterId,
                DataType = newEntity.DataType,
                EndPointParameterName = newEntity.EndPointParameterName,
                ParametersEndPointId = newEntity.ParametersEndPointId,
                DataSourceId = newEntity.DataSourceId,
            };
            
            return new ResponseWrapper<CreateEndPointParameterModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditEndPointParameterModel> EditEndPointParameter(int endpointparameterId, EditEndPointParameterInputModel model)
        {
            var entity = context
                .EndPointParameters
                .Single(x => 
                    x.EndPointParameterId == endpointparameterId
                );
            
            entity.DataType = model.DataType;
            entity.EndPointParameterName = model.EndPointParameterName;
            entity.ParametersEndPointId = model.ParametersEndPointId;
            entity.DataSourceId = model.DataSourceId;
            context.SaveChanges();
            var response = new EditEndPointParameterModel
            {
                EndPointParameterId = entity.EndPointParameterId,
                DataType = entity.DataType,
                EndPointParameterName = entity.EndPointParameterName,
                ParametersEndPointId = entity.ParametersEndPointId,
                DataSourceId = entity.DataSourceId,
            };
            
            return new ResponseWrapper<EditEndPointParameterModel>(_validationDictionary, response);
        }
    }
}