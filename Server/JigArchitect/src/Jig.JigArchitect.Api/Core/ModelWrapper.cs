using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jig.JigArchitect.Business.Services;
using ModelStateDictionary = Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

// http://www.asp.net/mvc/overview/older-versions-1/models-data/validating-with-a-service-layer-cs
// Oldy but goldy?

namespace Jig.JigArchitect.Api.Services
{

    public class ModelStateWrapper : IValidationDictionary
    {

        private ModelStateDictionary _modelState;

        public ModelStateWrapper(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }

        #region IValidationDictionary Members

        public void AddError(string key, string errorMessage)
        {
            _modelState.AddModelError(key, errorMessage);
        }

        public bool IsValid
        {
            get { return _modelState.IsValid; }
        }

        public ResponseModel<List<PropertyErrorModel>> GetErrors()
        {
            if (_modelState.IsValid)
                new ResponseModel<List<PropertyErrorModel>> { Success = false, Response = null };

            var errors = _modelState
                .Where(x => x.Value.Errors.Any())
                .Select(x =>
                {
                    return new PropertyErrorModel
                    {
                        PropertyName = x.Key,
                        AttemptedValue = x.Value.AttemptedValue,
                        ErrorMessages = x.Value.Errors.Select(y => y.ErrorMessage).ToList()
                    };
                });
            return new ResponseModel<List<PropertyErrorModel>> { Success = false, Response = errors.ToList() };
        }

        #endregion
    }

}
