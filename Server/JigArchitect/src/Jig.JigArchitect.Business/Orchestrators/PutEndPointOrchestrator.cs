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
    
    public interface IPutEndPointOrchestrator
    {
        ResponseWrapper<List<GetAllPutEndPointModel>> GetAllPutEndPoints();
        
        ResponseWrapper<GetPutEndPointDetailsModel> GetPutEndPointDetails(int putendpointId);
        
        ResponseWrapper<CreatePutEndPointModel> CreatePutEndPoint(CreatePutEndPointInputModel model);
        
        ResponseWrapper<EditPutEndPointModel> EditPutEndPoint(int putendpointId,EditPutEndPointInputModel model);
    }
    
    
    public class PutEndPointOrchestrator : IPutEndPointOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public PutEndPointOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllPutEndPointModel>> GetAllPutEndPoints()
        {
            var response = context
                .PutEndPoints
                    .Select(x =>
                        new GetAllPutEndPointModel
                        {
                            PutEndPointId = x.PutEndPointId,
                            EndPointId = x.EndPointId,
                            InputModelEndPointModelId = x.InputModelEndPointModelId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllPutEndPointModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetPutEndPointDetailsModel> GetPutEndPointDetails(int putendpointId)
        {
            var data = context
                .PutEndPoints
                .Single(x => 
                    x.PutEndPointId == putendpointId
                );
            
            var response = 
                new GetPutEndPointDetailsModel
                {
                    PutEndPointId = data.PutEndPointId,
                    EndPointId = data.EndPointId,
                    InputModelEndPointModelId = data.InputModelEndPointModelId,
                };
            
            return new ResponseWrapper<GetPutEndPointDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreatePutEndPointModel> CreatePutEndPoint(CreatePutEndPointInputModel model)
        {
            var newEntity = new PutEndPoint
            {
                EndPointId = model.EndPointId,
                InputModelEndPointModelId = model.InputModelEndPointModelId,
                EndPoint = 
                        new EndPoint
                        {
                            Name = model.EndPoint.Name,
                            Route = model.EndPoint.Route,
                            CustomEndPoint = model.EndPoint.CustomEndPoint,
                            EndPointType = model.EndPoint.EndPointType,
                            RootEntityEntityId = model.EndPoint.RootEntityEntityId,
                            EndPointModelId = model.EndPoint.EndPointModelId,
                            RootEndPointToRootEntityDataSourceId = model.EndPoint.RootEndPointToRootEntityDataSourceId,
                        },
            };
            
            context
                .PutEndPoints
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreatePutEndPointModel
            {
                PutEndPointId = newEntity.PutEndPointId,
                EndPointId = newEntity.EndPointId,
                InputModelEndPointModelId = newEntity.InputModelEndPointModelId,
            };
            
            return new ResponseWrapper<CreatePutEndPointModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditPutEndPointModel> EditPutEndPoint(int putendpointId, EditPutEndPointInputModel model)
        {
            var entity = context
                .PutEndPoints
                .Single(x => 
                    x.PutEndPointId == putendpointId
                );
            
            entity.EndPointId = model.EndPointId;
            entity.InputModelEndPointModelId = model.InputModelEndPointModelId;
            context.SaveChanges();
            var response = new EditPutEndPointModel
            {
                PutEndPointId = entity.PutEndPointId,
                EndPointId = entity.EndPointId,
                InputModelEndPointModelId = entity.InputModelEndPointModelId,
            };
            
            return new ResponseWrapper<EditPutEndPointModel>(_validationDictionary, response);
        }
    }
}