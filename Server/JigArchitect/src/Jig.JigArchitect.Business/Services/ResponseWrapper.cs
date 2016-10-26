using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jig.JigArchitect.Business.Services
{
    public class PropertyErrorModel
    {
        public string PropertyName { get; set; }
        public object AttemptedValue { get; set; }
        public List<string> ErrorMessages { get; set; }
    }

    public interface IValidationDictionary
    {
        void AddError(string key, string errorMessage);
        bool IsValid { get; }
        ResponseModel<List<PropertyErrorModel>> GetErrors();
    }

    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public T Response { get; set; }
    }

    public interface IResponseWrapper<T>
    {
        ResponseModel<T> GetResponse();
        bool IsValid();
        ResponseModel<List<PropertyErrorModel>> GetErrors();
    }

    public class ResponseWrapper<T> : IResponseWrapper<T>
    {
        private readonly IValidationDictionary _validationDictionary;
        private readonly T _response;

        public ResponseWrapper(IValidationDictionary dictionary, T response = default(T))
        {
            _validationDictionary = dictionary;
            _response = response;
        }

        #region ResponseWrapper<T> Members

        public ResponseModel<T> GetResponse()
        {
            if (_validationDictionary.IsValid)
                return new ResponseModel<T> { Success = true, Response = _response };

            return new ResponseModel<T> { Success = false, Response = default(T) };
        }

        public bool IsValid()
        {
            return _validationDictionary.IsValid;
        }

        public ResponseModel<List<PropertyErrorModel>> GetErrors()
        {
            return _validationDictionary.GetErrors();
        }

        #endregion
    }
}
