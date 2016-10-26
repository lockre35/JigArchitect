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
    
    public interface IRelationshipOrchestrator
    {
        ResponseWrapper<List<GetAllRelationshipModel>> GetAllRelationships();
        
        ResponseWrapper<GetRelationshipDetailsModel> GetRelationshipDetails(int relationshipId);
        
        ResponseWrapper<CreateRelationshipModel> CreateRelationship(CreateRelationshipInputModel model);
        
        ResponseWrapper<EditRelationshipModel> EditRelationship(int relationshipId,EditRelationshipInputModel model);
    }
    
    
    public class RelationshipOrchestrator : IRelationshipOrchestrator
    {
        protected DomainContext context;
        protected IValidationDictionary _validationDictionary;
        public RelationshipOrchestrator(IValidationDictionary validationDictionary)
        {
            context = new DomainContext();
            _validationDictionary = validationDictionary;
        }
        
        public ResponseWrapper<List<GetAllRelationshipModel>> GetAllRelationships()
        {
            var response = context
                .Relationships
                    .Select(x =>
                        new GetAllRelationshipModel
                        {
                            RelationshipId = x.RelationshipId,
                            RelationshipType = x.RelationshipType,
                            ParentEntityEntityId = x.ParentEntityEntityId,
                            ChildEntityEntityId = x.ChildEntityEntityId,
                        }
                    ).ToList();
            
            return new ResponseWrapper<List<GetAllRelationshipModel>>(_validationDictionary, response);
        }
        
        public ResponseWrapper<GetRelationshipDetailsModel> GetRelationshipDetails(int relationshipId)
        {
            var data = context
                .Relationships
                .Single(x => 
                    x.RelationshipId == relationshipId
                );
            
            var response = 
                new GetRelationshipDetailsModel
                {
                    RelationshipId = data.RelationshipId,
                    RelationshipType = data.RelationshipType,
                    ParentEntityEntityId = data.ParentEntityEntityId,
                    ChildEntityEntityId = data.ChildEntityEntityId,
                };
            
            return new ResponseWrapper<GetRelationshipDetailsModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<CreateRelationshipModel> CreateRelationship(CreateRelationshipInputModel model)
        {
            var newEntity = new Relationship
            {
                RelationshipType = model.RelationshipType,
                ParentEntityEntityId = model.ParentEntityEntityId,
                ChildEntityEntityId = model.ChildEntityEntityId,
            };
            
            context
                .Relationships
                .Add(newEntity);
            
            context.SaveChanges();
            var response = new CreateRelationshipModel
            {
                RelationshipId = newEntity.RelationshipId,
                RelationshipType = newEntity.RelationshipType,
                ParentEntityEntityId = newEntity.ParentEntityEntityId,
                ChildEntityEntityId = newEntity.ChildEntityEntityId,
            };
            
            return new ResponseWrapper<CreateRelationshipModel>(_validationDictionary, response);
        }
        
        public ResponseWrapper<EditRelationshipModel> EditRelationship(int relationshipId, EditRelationshipInputModel model)
        {
            var entity = context
                .Relationships
                .Single(x => 
                    x.RelationshipId == relationshipId
                );
            
            entity.RelationshipType = model.RelationshipType;
            entity.ParentEntityEntityId = model.ParentEntityEntityId;
            entity.ChildEntityEntityId = model.ChildEntityEntityId;
            context.SaveChanges();
            var response = new EditRelationshipModel
            {
                RelationshipId = entity.RelationshipId,
                RelationshipType = entity.RelationshipType,
                ParentEntityEntityId = entity.ParentEntityEntityId,
                ChildEntityEntityId = entity.ChildEntityEntityId,
            };
            
            return new ResponseWrapper<EditRelationshipModel>(_validationDictionary, response);
        }
    }
}