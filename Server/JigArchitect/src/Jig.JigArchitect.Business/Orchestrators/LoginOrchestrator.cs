using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jig.JigArchitect.Business.Services;
using Jig.JigArchitect.Business.Models;
using Jig.JigArchitect.Domain;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Business.Orchestrators
{
    public interface ILoginOrchestrator
    {
        ResponseWrapper<List<LoginModel>> GetLogins();
        ResponseWrapper<LoginModel> GetLogin(int id);
        ResponseWrapper<LoginModel> CreateLogin(LoginModel model);
        ResponseWrapper<LoginModel> SaveLogin(int id, LoginModel model);
        ResponseWrapper<string> DeleteLogin(int id, LoginModel model);
    }

    public class LoginOrchestrator : ILoginOrchestrator
    {
        protected IValidationDictionary _validationDictionary;

        public LoginOrchestrator(IValidationDictionary validationDictionary)
        {
            _validationDictionary = validationDictionary;
        }

        public ResponseWrapper<LoginModel> CreateLogin(LoginModel model)
        {
            if (!_validationDictionary.IsValid)
                return new ResponseWrapper<LoginModel>(_validationDictionary, null);

            using (var db = new DomainContext())
            {
                var login = new Login { Username = model.Username, Password = model.Password };
                db.Logins.Add(login);
                db.SaveChanges();

                var response = new LoginModel { LoginId = login.LoginId, Username = login.Username };
                return new ResponseWrapper<LoginModel>(_validationDictionary, response);
            }
        }

        public ResponseWrapper<string> DeleteLogin(int id, LoginModel model)
        {
            using (var db = new DomainContext())
            {
                var login = db.Logins.Where(x => x.LoginId == id && x.Username == model.Username).Single();
                db.Logins.Remove(login);
                db.SaveChanges();

                return new ResponseWrapper<string>(_validationDictionary, "Login removed");
            }
        }

        public ResponseWrapper<LoginModel> GetLogin(int id)
        {
            using (var db = new DomainContext())
            {
                var login = db.Logins.Where(x => x.LoginId == id).Single();
                var response = new LoginModel { LoginId = login.LoginId, Username = login.Username };

                return new ResponseWrapper<LoginModel>(_validationDictionary, response);
            }
        }

        public ResponseWrapper<List<LoginModel>> GetLogins()
        {
            using (var db = new DomainContext())
            {
                var logins = db.Logins.ToList();
                var response = logins
                    .Select(x =>
                        new LoginModel
                        {
                            LoginId = x.LoginId,
                            Username = x.Username
                        })
                    .ToList();

                return new ResponseWrapper<List<LoginModel>>(_validationDictionary, response);
            }
        }

        public ResponseWrapper<LoginModel> SaveLogin(int id, LoginModel model)
        {
            if (!_validationDictionary.IsValid)
                return new ResponseWrapper<LoginModel>(_validationDictionary, null);

            using (var db = new DomainContext())
            {
                var login = db.Logins.Where(x => x.LoginId == id).Single();
                login.Username = model.Username;
                login.Password = model.Password;
                db.SaveChanges();

                var response = new LoginModel { LoginId = login.LoginId, Username = login.Username };
                return new ResponseWrapper<LoginModel>(_validationDictionary, response);
            }
        }
    }
}
