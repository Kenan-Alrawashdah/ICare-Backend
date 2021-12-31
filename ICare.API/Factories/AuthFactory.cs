using ICare.Core.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICare.API.Factories
{
    public static class AuthFactory 
    {

        public static void AddAuth(this IServiceCollection services,IConfiguration configuration )
        {
            services.AddAuthentication(
                 x =>
                 {
                     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 }
                  ).AddJwtBearer(y =>
                  {
                      y.RequireHttpsMetadata = false;
                      y.SaveToken = true;
                      y.TokenValidationParameters = new TokenValidationParameters
                      {
                          ValidateIssuerSigningKey = true,
                          IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("superSecretKey@345")),
                          ValidateIssuer = false,
                          ValidateAudience = false,
                          // Check Validate life time
                          ValidateLifetime = true,
                          ClockSkew = TimeSpan.Zero
                      };
                  });
        }

    }
}
