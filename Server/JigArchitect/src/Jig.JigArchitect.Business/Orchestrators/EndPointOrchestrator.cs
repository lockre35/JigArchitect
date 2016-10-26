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
    
    public interface IEndPointOrchestrator
    {
        ResponseWrapper<List<GetAllEndPointModel>> GetAllEndPoints();
        
        ResponseWrapper<GetEndPointDetailsModel> GetEndPointDetails(int endpointId);
        
        ResponseWrapper<CreateEndPointModel> CreateEndPoint(CreateEndPointInputModel model);
        
        ResponseWrapper<EditEndPointModel> EditEndPoint(int endpointId,EditEndPointInputModel model);
        
        ResponseWrapper<GetEndPointGetAllEndPointModel> GetEndPointGetAllEndPoint(int endpointId);
        
        ResponseWrapper<GetEndPointDeleteEndPointModel> GetEndPointDeleteEndPoint(int endpointId);
        
        ResponseWrapper<GetEndPointPostEndPointModel> GetEndPointPostEndPoint(int endpointId);
        
        ResponseWrapper<GetEndPointPutEndPointModel> GetEndPointPutEndPoint(int endpointId);
        
        ResponseWrapper<GetEndPointGetDetailsEndPointModel> GetEndPointGetDetailsEndPoint(int endpointId);
        
        ResponseWrapper<List<GetAllEndPointEndPointParametersModel>> GetAllEndPointEndPointParameters(int endpointId);
    }
    
    
    public class EndPointOrchestrator : IEndPointOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public EndPointOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllEndPointModel>> GetAllEndPoints()
        {
            var response = context
                .EndPoints
                    .Select(x =>
                        new GetAllEndPointModel
                        {
                            EndPointId = x.EndPointId,
                            Name = x.Name,
                            Route = x.Route,
                            CustomEndPoint = x.CustomEndPoint,
                            EndPointType = x.EndPointType,
                            RootEntityEntityId = x.RootEntityEntityId,
                            EndPointModelId = x.EndPointModelId,
                            RootEndPointToRootEntityDataSourceId = x.RootEndPointToRootEntityDataSourceId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEndPointModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEndPointDetailsModel> GetEndPointDetails(int endpointId)
        {
            var data = context
                .EndPoints
                .Single(x => 
                    x.EndPointId == endpointId
                );
            
            var response = 
                new GetEndPointDetailsModel
                {
                    EndPointId = data.EndPointId,
                    Name = data.Name,
                    Route = data.Route,
                    CustomEndPoint = data.CustomEndPoint,
                    EndPointType = data.EndPointType,
                    RootEntityEntityId = data.RootEntityEntityId,
                    EndPointModelId = data.EndPointModelId,
                    RootEndPointToRootEntityDataSourceId = data.RootEndPointToRootEntityDataSourceId,
                };
            
            return new ResponseWrapper<GetEndPointDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateEndPointModel> CreateEndPoint(CreateEndPointInputModel model)
        {
            var newEntity = new EndPoint
            {
                Name = model.Name,
                Route = model.Route,
                CustomEndPoint = model.CustomEndPoint,
                EndPointType = model.EndPointType,
                RootEntityEntityId = model.RootEntityEntityId,
                EndPointModelId = model.EndPointModelId,
                RootEndPointToRootEntityDataSourceId = model.RootEndPointToRootEntityDataSourceId,
            };
            
            context
                .EndPoints
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateEndPointModel
            {
                EndPointId = newEntity.EndPointId,
                Name = newEntity.Name,
                Route = newEntity.Route,
                CustomEndPoint = newEntity.CustomEndPoint,
                EndPointType = newEntity.EndPointType,
                RootEntityEntityId = newEntity.RootEntityEntityId,
                EndPointModelId = newEntity.EndPointModelId,
                RootEndPointToRootEntityDataSourceId = newEntity.RootEndPointToRootEntityDataSourceId,
            };
            
            return new ResponseWrapper<CreateEndPointModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditEndPointModel> EditEndPoint(int endpointId, EditEndPointInputModel model)
        {
            var entity = context
                .EndPoints
                .Single(x => 
                    x.EndPointId == endpointId
                );
            
            entity.Name = model.Name;
            entity.Route = model.Route;
            entity.CustomEndPoint = model.CustomEndPoint;
            entity.EndPointType = model.EndPointType;
            entity.RootEntityEntityId = model.RootEntityEntityId;
            entity.EndPointModelId = model.EndPointModelId;
            entity.RootEndPointToRootEntityDataSourceId = model.RootEndPointToRootEntityDataSourceId;
            context.SaveChanges();
            var response = new EditEndPointModel
            {
                EndPointId = entity.EndPointId,
                Name = entity.Name,
                Route = entity.Route,
                CustomEndPoint = entity.CustomEndPoint,
                EndPointType = entity.EndPointType,
                RootEntityEntityId = entity.RootEntityEntityId,
                EndPointModelId = entity.EndPointModelId,
                RootEndPointToRootEntityDataSourceId = entity.RootEndPointToRootEntityDataSourceId,
            };
            
            return new ResponseWrapper<EditEndPointModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEndPointGetAllEndPointModel> GetEndPointGetAllEndPoint(int endpointId)
        {
            var data = context
                .EndPoints
                .Include(i => i.GetAllEndPoint)
                .Single(x => 
                    x.EndPointId == endpointId
                )
                .GetAllEndPoint;
            
            var response = 
                new GetEndPointGetAllEndPointModel
                {
                    GetAllEndPointId = data.GetAllEndPointId,
                    EndPointId = data.EndPointId,
                };
            
            return new ResponseWrapper<GetEndPointGetAllEndPointModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEndPointDeleteEndPointModel> GetEndPointDeleteEndPoint(int endpointId)
        {
            var data = context
                .EndPoints
                .Include(i => i.DeleteEndPoint)
                .Single(x => 
                    x.EndPointId == endpointId
                )
                .DeleteEndPoint;
            
            var response = 
                new GetEndPointDeleteEndPointModel
                {
                    DeleteEndPointId = data.DeleteEndPointId,
                    EndPointId = data.EndPointId,
                };
            
            return new ResponseWrapper<GetEndPointDeleteEndPointModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEndPointPostEndPointModel> GetEndPointPostEndPoint(int endpointId)
        {
            var data = context
                .EndPoints
                .Include(i => i.PostEndPoint)
                .Single(x => 
                    x.EndPointId == endpointId
                )
                .PostEndPoint;
            
            var response = 
                new GetEndPointPostEndPointModel
                {
                    PostEndPointId = data.PostEndPointId,
                    EndPointId = data.EndPointId,
                    InputModelEndPointModelId = data.InputModelEndPointModelId,
                };
            
            return new ResponseWrapper<GetEndPointPostEndPointModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEndPointPutEndPointModel> GetEndPointPutEndPoint(int endpointId)
        {
            var data = context
                .EndPoints
                .Include(i => i.PutEndPoint)
                .Single(x => 
                    x.EndPointId == endpointId
                )
                .PutEndPoint;
            
            var response = 
                new GetEndPointPutEndPointModel
                {
                    PutEndPointId = data.PutEndPointId,
                    EndPointId = data.EndPointId,
                    InputModelEndPointModelId = data.InputModelEndPointModelId,
                };
            
            return new ResponseWrapper<GetEndPointPutEndPointModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetEndPointGetDetailsEndPointModel> GetEndPointGetDetailsEndPoint(int endpointId)
        {
            var data = context
                .EndPoints
                .Include(i => i.GetDetailsEndPoint)
                .Single(x => 
                    x.EndPointId == endpointId
                )
                .GetDetailsEndPoint;
            
            var response = 
                new GetEndPointGetDetailsEndPointModel
                {
                    GetDetailsEndPointId = data.GetDetailsEndPointId,
                    EndPointId = data.EndPointId,
                };
            
            return new ResponseWrapper<GetEndPointGetDetailsEndPointModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<List<GetAllEndPointEndPointParametersModel>> GetAllEndPointEndPointParameters(int endpointId)
        {
            var response = context
                .EndPoints
                .Include(i => i.EndPointParameters)
                .Single(x => 
                    x.EndPointId == endpointId
                )
                .EndPointParameters
                    .Select(x =>
                        new GetAllEndPointEndPointParametersModel
                        {
                            EndPointParameterId = x.EndPointParameterId,
                            DataType = x.DataType,
                            EndPointParameterName = x.EndPointParameterName,
                            ParametersEndPointId = x.ParametersEndPointId,
                            DataSourceId = x.DataSourceId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllEndPointEndPointParametersModel>>(_validationDictionary, response);
        }
    }
}