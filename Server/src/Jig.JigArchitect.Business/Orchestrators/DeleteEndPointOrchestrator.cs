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
    
    public interface IDeleteEndPointOrchestrator
    {
        ResponseWrapper<List<GetAllDeleteEndPointModel>> GetAllDeleteEndPoints();
        
        ResponseWrapper<GetDeleteEndPointDetailsModel> GetDeleteEndPointDetails(int deleteendpointId);
        
        ResponseWrapper<CreateDeleteEndPointModel> CreateDeleteEndPoint(CreateDeleteEndPointInputModel model);
        
        ResponseWrapper<EditDeleteEndPointModel> EditDeleteEndPoint(int deleteendpointId,EditDeleteEndPointInputModel model);
    }
    
    
    public class DeleteEndPointOrchestrator : IDeleteEndPointOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public DeleteEndPointOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllDeleteEndPointModel>> GetAllDeleteEndPoints()
        {
            var response = context
                .DeleteEndPoints
                    .Select(x =>
                        new GetAllDeleteEndPointModel
                        {
                            DeleteEndPointId = x.DeleteEndPointId,
                            EndPointId = x.EndPointId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllDeleteEndPointModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetDeleteEndPointDetailsModel> GetDeleteEndPointDetails(int deleteendpointId)
        {
            var data = context
                .DeleteEndPoints
                .Single(x => 
                    x.DeleteEndPointId == deleteendpointId
                );
            
            var response = 
                new GetDeleteEndPointDetailsModel
                {
                    DeleteEndPointId = data.DeleteEndPointId,
                    EndPointId = data.EndPointId,
                };
            
            return new ResponseWrapper<GetDeleteEndPointDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateDeleteEndPointModel> CreateDeleteEndPoint(CreateDeleteEndPointInputModel model)
        {
            var newEntity = new DeleteEndPoint
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
                .DeleteEndPoints
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateDeleteEndPointModel
            {
                DeleteEndPointId = newEntity.DeleteEndPointId,
                EndPointId = newEntity.EndPointId,
            };
            
            return new ResponseWrapper<CreateDeleteEndPointModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditDeleteEndPointModel> EditDeleteEndPoint(int deleteendpointId, EditDeleteEndPointInputModel model)
        {
            var entity = context
                .DeleteEndPoints
                .Single(x => 
                    x.DeleteEndPointId == deleteendpointId
                );
            
            entity.EndPointId = model.EndPointId;
            context.SaveChanges();
            var response = new EditDeleteEndPointModel
            {
                DeleteEndPointId = entity.DeleteEndPointId,
                EndPointId = entity.EndPointId,
            };
            
            return new ResponseWrapper<EditDeleteEndPointModel>(_validationDictionary, response);
        }
    }
}