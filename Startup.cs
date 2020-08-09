using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Consistrack.Data;
using Consistrack.Interface;
using Consistrack.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Consistrack
{
    public class Startup
    {
        private const string AllowAllOriginsPolicy = "AllowAllOriginsPolicy";
        public Startup(IConfiguration configuration)
        {
            
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
               var appSettingsection=Configuration.GetSection("AppSetting");
                services.Configure<AppSettings>(appSettingsection);
            //JWT Authentication
            var appSettings=appSettingsection.Get<AppSettings>();
            var Key=Encoding.ASCII.GetBytes(appSettings.Key);
               services.AddAuthentication(au =>{
au.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
au.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;


               }).AddJwtBearer(jwt =>{
jwt.RequireHttpsMetadata=false;
jwt.SaveToken=true;
jwt.TokenValidationParameters=new TokenValidationParameters{
    ValidateIssuerSigningKey=true,
    IssuerSigningKey=new SymmetricSecurityKey(Key),
    ValidateIssuer=false,
    ValidateAudience=false

};
 });
               
                 services.AddCors(options =>
    {
        options.AddPolicy(AllowAllOriginsPolicy, // I introduced a string constant just as a label "AllowAllOriginsPolicy"
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });
    });
            services.AddDbContext<ConsistrackContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("ConsistrckConnection")));
            services.AddControllers();
            services.AddScoped<ISimMasterRepo,SqlSimMasterRepo>();
            services.AddScoped<IGPSMasterRepo,SqlGPSMasterRepo>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
           services.AddScoped<IAuthenticateServiceRepo,AuthenticateServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();  // first
            // Shows UseCors with CorsPolicyBuilder.
            // global cors policy
            app.UseCors(AllowAllOriginsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
             
        }
    }
}
