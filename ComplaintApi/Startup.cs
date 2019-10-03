using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComplaintApi.Entities;
using ComplaintApi.Models;
using ComplaintApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ComplaintApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                setupAction.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = Configuration["connectionStrings:ApiDbConnectionString"];
            services.AddDbContext<ComplaintContext>(o => o.UseSqlServer(connectionString));

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CompanyMaster, CompanyMasterDto>();
                cfg.CreateMap<UserMaster, UserMasterDto>();
                cfg.CreateMap<ModuleMaster, ModuleMasterDto>();
                cfg.CreateMap<PriorityMaster, PriorityMasterDto>();
                cfg.CreateMap<ComplainsMaster, ComplainsMasterDto>();
                cfg.CreateMap<ComplainsHistory, ComplainsHistoryDto>();
                cfg.CreateMap<Models.CompanyMasterForUpdateDto, Entities.CompanyMaster>();
                cfg.CreateMap<Models.ModuleMasterForUpdateDto, Entities.ModuleMaster>();
                cfg.CreateMap<Models.PriorityMasterForUpdateDto, Entities.PriorityMaster>();
                cfg.CreateMap<Models.UserMasterForUpdateDto, Entities.UserMaster>();
                cfg.CreateMap<Models.ComplainsHistoryForUpdateDto,Entities.ComplainsMaster>();
                cfg.CreateMap<Models.ComplainsMasterForUpdateDto,Entities.ComplainsMaster>();
                cfg.CreateMap<Models.ComplainsHistoryForUpdateDto, Entities.ComplainsHistory>();
                cfg.CreateMap<Models.ComplainsHistoryForCreationDto, Entities.ComplainsHistory>();

            });

            services.AddScoped<IComplaintRepository, ComplaintRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Test_Api", Description = "Test Rest Api" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Test_Api");
            });
        }
    }
}
