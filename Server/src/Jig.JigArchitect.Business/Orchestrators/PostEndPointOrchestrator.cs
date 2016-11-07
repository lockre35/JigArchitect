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
    
    public interface IPostEndPointOrchestrator
    {
        ResponseWrapper<List<GetAllPostEndPointModel>> GetAllPostEndPoints();
        
        ResponseWrapper<GetPostEndPointDetailsModel> GetPostEndPointDetails(int postendpointId);
        
        ResponseWrapper<CreatePostEndPointModel> CreatePostEndPoint(CreatePostEndPointInputModel model);
        
        ResponseWrapper<EditPostEndPointModel> EditPostEndPoint(int postendpointId,EditPostEndPointInputModel model);
    }
    
    
    public class PostEndPointOrchestrator : IPostEndPointOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public PostEndPointOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllPostEndPointModel>> GetAllPostEndPoints()
        {
            var response = context
                .PostEndPoints
                    .Select(x =>
                        new GetAllPostEndPointModel
                        {
                            PostEndPointId = x.PostEndPointId,
                            EndPointId = x.EndPointId,
                            InputModelEndPointModelId = x.InputModelEndPointModelId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllPostEndPointModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetPostEndPointDetailsModel> GetPostEndPointDetails(int postendpointId)
        {
            var data = context
                .PostEndPoints
                .Single(x => 
                    x.PostEndPointId == postendpointId
                );
            
            var response = 
                new GetPostEndPointDetailsModel
                {
                    PostEndPointId = data.PostEndPointId,
                    EndPointId = data.EndPointId,
                    InputModelEndPointModelId = data.InputModelEndPointModelId,
                };
            
            return new ResponseWrapper<GetPostEndPointDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreatePostEndPointModel> CreatePostEndPoint(CreatePostEndPointInputModel model)
        {
            var newEntity = new PostEndPoint
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
                            ServiceId = model.EndPoint.ServiceId,
                            EndPointModelId = model.EndPoint.EndPointModelId,
                            RootEndPointToRootEntityDataSourceId = model.EndPoint.RootEndPointToRootEntityDataSourceId,
                        },
            };
            
            context
                .PostEndPoints
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreatePostEndPointModel
            {
                PostEndPointId = newEntity.PostEndPointId,
                EndPointId = newEntity.EndPointId,
                InputModelEndPointModelId = newEntity.InputModelEndPointModelId,
            };
            
            return new ResponseWrapper<CreatePostEndPointModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditPostEndPointModel> EditPostEndPoint(int postendpointId, EditPostEndPointInputModel model)
        {
            var entity = context
                .PostEndPoints
                .Single(x => 
                    x.PostEndPointId == postendpointId
                );
            
            entity.EndPointId = model.EndPointId;
            entity.InputModelEndPointModelId = model.InputModelEndPointModelId;
            context.SaveChanges();
            var response = new EditPostEndPointModel
            {
                PostEndPointId = entity.PostEndPointId,
                EndPointId = entity.EndPointId,
                InputModelEndPointModelId = entity.InputModelEndPointModelId,
            };
            
            return new ResponseWrapper<EditPostEndPointModel>(_validationDictionary, response);
        }
    }
}