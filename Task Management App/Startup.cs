using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using Task_Management_System.Data;

namespace Task_Management_System
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
            services.AddDbContext<TaskManagementSystemContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddCors();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddSwaggerGen();
            //services.AddSwaggerGen(setupAction =>
            //{
            //    setupAction.SwaggerDoc("ExamRegistrationOpenApiSpecification",
            //        new Microsoft.OpenApi.Models.OpenApiInfo()
            //        {
            //            Title = "Student Exam Registration API",
            //            Version = "1",
            //            //Često treba da dodamo neke dodatne informacije
            //            Description = "Pomoću ovog API-ja može da se vrši prijava ispita, modifikacija prijava ispita kao i pregled kreiranih prijava ispita.",
            //            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            //            {
            //                Name = "Marko Marković",
            //                Email = "marko@mail.com",
            //                Url = new Uri("http://www.ftn.uns.ac.rs/")
            //            },
            //            License = new Microsoft.OpenApi.Models.OpenApiLicense
            //            {
            //                Name = "FTN licence",
            //                Url = new Uri("http://www.ftn.uns.ac.rs/")
            //            },
            //            TermsOfService = new Uri("http://www.ftn.uns.ac.rs/examRegistrationTermsOfService")
            //        });

            //    //Pomocu refleksije dobijamo ime XML fajla sa komentarima (ovako smo ga nazvali u Project -> Properties)
            //    var xmlComments = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";

            //    //Pravimo putanju do XML fajla sa komentarima
            //    var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

            //    //Govorimo swagger-u gde se nalazi dati xml fajl sa komentarima
            //    setupAction.IncludeXmlComments(xmlCommentsPath);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseCors(options => options
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod());


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=UserRoles}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
