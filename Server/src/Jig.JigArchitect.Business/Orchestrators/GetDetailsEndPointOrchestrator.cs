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
    
    public interface IGetDetailsEndPointOrchestrator
    {
        ResponseWrapper<List<GetAllGetDetailsEndPointModel>> GetAllGetDetailsEndPoints();
        
        ResponseWrapper<GetGetDetailsEndPointDetailsModel> GetGetDetailsEndPointDetails(int getdetailsendpointId);
        
        ResponseWrapper<CreateGetDetailsEndPointModel> CreateGetDetailsEndPoint(CreateGetDetailsEndPointInputModel model);
        
        ResponseWrapper<EditGetDetailsEndPointModel> EditGetDetailsEndPoint(int getdetailsendpointId,EditGetDetailsEndPointInputModel model);
    }
    
    
    public class GetDetailsEndPointOrchestrator : IGetDetailsEndPointOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public GetDetailsEndPointOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllGetDetailsEndPointModel>> GetAllGetDetailsEndPoints()
        {
            var response = context
                .GetDetailsEndPoints
                    .Select(x =>
                        new GetAllGetDetailsEndPointModel
                        {
                            GetDetailsEndPointId = x.GetDetailsEndPointId,
                            EndPointId = x.EndPointId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllGetDetailsEndPointModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetGetDetailsEndPointDetailsModel> GetGetDetailsEndPointDetails(int getdetailsendpointId)
        {
            var data = context
                .GetDetailsEndPoints
                .Single(x => 
                    x.GetDetailsEndPointId == getdetailsendpointId
                );
            
            var response = 
                new GetGetDetailsEndPointDetailsModel
                {
                    GetDetailsEndPointId = data.GetDetailsEndPointId,
                    EndPointId = data.EndPointId,
                };
            
            return new ResponseWrapper<GetGetDetailsEndPointDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateGetDetailsEndPointModel> CreateGetDetailsEndPoint(CreateGetDetailsEndPointInputModel model)
        {
            var newEntity = new GetDetailsEndPoint
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
                .GetDetailsEndPoints
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateGetDetailsEndPointModel
            {
                GetDetailsEndPointId = newEntity.GetDetailsEndPointId,
                EndPointId = newEntity.EndPointId,
            };
            
            return new ResponseWrapper<CreateGetDetailsEndPointModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditGetDetailsEndPointModel> EditGetDetailsEndPoint(int getdetailsendpointId, EditGetDetailsEndPointInputModel model)
        {
            var entity = context
                .GetDetailsEndPoints
                .Single(x => 
                    x.GetDetailsEndPointId == getdetailsendpointId
                );
            
            entity.EndPointId = model.EndPointId;
            context.SaveChanges();
            var response = new EditGetDetailsEndPointModel
            {
                GetDetailsEndPointId = entity.GetDetailsEndPointId,
                EndPointId = entity.EndPointId,
            };
            
            return new ResponseWrapper<EditGetDetailsEndPointModel>(_validationDictionary, response);
        }
    }
}