using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Jig.JigArchitect.Api.Models;
using Jig.JigArchitect.Api.Services;


//https://github.com/nbarbettini/SimpleTokenProvider/blob/master/src/SimpleTokenProvider/TokenProviderOptions.cs
namespace Jig.JigArchitect.Api
{
    public class Startup
    {
        const string TokenAudience = "RelyBuilderApiAudience";
        const string TokenIssuer = "RelyBuilderApiIssuer";
        private Microsoft.IdentityModel.Tokens.RsaSecurityKey key;
        private TokenOptionsModel tokenOptions;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // *** CHANGE THIS FOR PRODUCTION USE ***
            // Here, we're generating a random key to sign tokens - obviously this means
            // that each time the app is started the key will change, and multiple servers
            // all have different keys. This should be changed to load a key from a file
            // securely delivered to your application, controlled by configuration.
            //
            // See the RSAKeyUtils.GetKeyParameters method for an examle of loading from
            // a JSON file.
            RSAParameters keyParams = RsaKeyService.GetRandomKey();

            // Create the key, and a set of token options to record signing credentials
            // using that key, along with the other parameters we will need in the
            // token controlller.
            key = new Microsoft.IdentityModel.Tokens.RsaSecurityKey(keyParams);
            tokenOptions = new TokenOptionsModel()
            {
                Audience = TokenAudience,
                Issuer = TokenIssuer,
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.RsaSha256Signature)
            };

            // Save the token options into an instance so they're accessible to the
            // controller.
            services.AddSingleton<TokenOptionsModel>(tokenOptions);

            // Enable the use of an [Authorize("Bearer")] attribute on methods and classes to protect.
            services.AddAuthorization(auth =>
            {
                // inline policies
                //https://leastprivilege.com/2015/10/12/the-state-of-security-in-asp-net-5-and-mvc-6-authorization/
                auth.AddPolicy("Admin", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().RequireClaim("Admin").Build());

                // inline policies
                //https://leastprivilege.com/2015/10/12/the-state-of-security-in-asp-net-5-and-mvc-6-authorization/
                auth.AddPolicy("Manager", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().RequireClaim("Manager").Build());

                //https://github.com/mrsheepuk/ASPNETSelfCreatedTokenAuthExample
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build();
            });

            // CORS works but hosting can make things confusing
            // http://stackoverflow.com/questions/34212765/how-do-i-get-the-kestrel-web-server-to-listen-to-non-localhost-requests
            services.AddCors(o => o.AddPolicy("AnyOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("AnyOrigin");
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Register a simple error handler to catch token expiries and change them to a 401,
            // and return all other errors as a 500. This should almost certainly be improved for
            // a real application.
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;
                    // This should be much more intelligent - at the moment only expired
                    // security tokens are caught - might be worth checking other possible
                    // exceptions such as an invalid signature.
                    if (error != null && (error.Error is Microsoft.IdentityModel.Tokens.SecurityTokenExpiredException || error.Error is Microsoft.IdentityModel.Tokens.SecurityTokenInvalidSignatureException))
                    {
                        context.Response.StatusCode = 403;
                        // What you choose to return here is up to you, in this case a simple
                        // bit of JSON to say you're no longer authenticated.
                        context.Response.Headers["Access-Control-Allow-Origin"] = "*";
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(
                            JsonConvert.SerializeObject(
                                new { authenticated = false, tokenExpired = true }));
                    }
                    else if (error != null && error.Error != null)
                    {
                        context.Response.StatusCode = 500;
                        context.Response.Headers["Access-Control-Allow-Origin"] = "*";
                        context.Response.ContentType = "application/json";
                        // TODO: Shouldn't pass the exception message straight out, change this.
                        await context.Response.WriteAsync(
                            JsonConvert.SerializeObject
                            (new { Success = false, Response = error.Error.Message }));
                    }
                    // We're not trying to handle anything else so just let the default
                    // handler handle.
                    else await next();
                });
            });

            var tokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = "RelyBuilderApiIssuer",

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = "RelyBuilderApiAudience",

                // Validate the token expiry
                ValidateLifetime = true,

                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };

            var options = new JwtBearerOptions();

            options.TokenValidationParameters = tokenValidationParameters;
            options.Audience = tokenOptions.Audience;
            options.ClaimsIssuer = tokenOptions.Issuer;

            app.UseJwtBearerAuthentication(options);

            app.UseMvc();
        }
    }
}
