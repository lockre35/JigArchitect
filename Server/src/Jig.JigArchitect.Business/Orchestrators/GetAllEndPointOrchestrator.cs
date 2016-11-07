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
    
    public interface IGetAllEndPointOrchestrator
    {
        ResponseWrapper<List<GetAllGetAllEndPointModel>> GetAllGetAllEndPoints();
        
        ResponseWrapper<GetGetAllEndPointDetailsModel> GetGetAllEndPointDetails(int getallendpointId);
        
        ResponseWrapper<CreateGetAllEndPointModel> CreateGetAllEndPoint(CreateGetAllEndPointInputModel model);
        
        ResponseWrapper<EditGetAllEndPointModel> EditGetAllEndPoint(int getallendpointId,EditGetAllEndPointInputModel model);
    }
    
    
    public class GetAllEndPointOrchestrator : IGetAllEndPointOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public GetAllEndPointOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllGetAllEndPointModel>> GetAllGetAllEndPoints()
        {
            var response = context
                .GetAllEndPoints
                    .Select(x =>
                        new GetAllGetAllEndPointModel
                        {
                            GetAllEndPointId = x.GetAllEndPointId,
                            EndPointId = x.EndPointId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllGetAllEndPointModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetGetAllEndPointDetailsModel> GetGetAllEndPointDetails(int getallendpointId)
        {
            var data = context
                .GetAllEndPoints
                .Single(x => 
                    x.GetAllEndPointId == getallendpointId
                );
            
            var response = 
                new GetGetAllEndPointDetailsModel
                {
                    GetAllEndPointId = data.GetAllEndPointId,
                    EndPointId = data.EndPointId,
                };
            
            return new ResponseWrapper<GetGetAllEndPointDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateGetAllEndPointModel> CreateGetAllEndPoint(CreateGetAllEndPointInputModel model)
        {
            var newEntity = new GetAllEndPoint
            {
                EndPointId = model.EndPointId,
                EndPoint = 
                        new EndPoint
                        {
                            Name = model.EndPoint.Name,
                            Route = model.EndPoint.Route,
                            CustomEndPoint = model.EndPoint.CustomEndPoint,
                            EndPointType = model.EndPoint.EndPointType,
                            RootEntityEntityId = model.EndPoint.RootEntityEntityId,
                            ServiceId = model.EndPoint.ServiceId,
                            EndPointModelId = model.EndPoint.EndPointModelId,
                            RootEndPointToRootEntityDataSourceId = model.EndPoint.RootEndPointToRootEntityDataSourceId,
                        },
            };
            
            context
                .GetAllEndPoints
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateGetAllEndPointModel
            {
                GetAllEndPointId = newEntity.GetAllEndPointId,
                EndPointId = newEntity.EndPointId,
            };
            
            return new ResponseWrapper<CreateGetAllEndPointModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditGetAllEndPointModel> EditGetAllEndPoint(int getallendpointId, EditGetAllEndPointInputModel model)
        {
            var entity = context
                .GetAllEndPoints
                .Single(x => 
                    x.GetAllEndPointId == getallendpointId
                );
            
            entity.EndPointId = model.EndPointId;
            context.SaveChanges();
            var response = new EditGetAllEndPointModel
            {
                GetAllEndPointId = entity.GetAllEndPointId,
                EndPointId = entity.EndPointId,
            };
            
            return new ResponseWrapper<EditGetAllEndPointModel>(_validationDictionary, response);
        }
    }
}