using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Text;
using Task_Management_System.Auth;
using Task_Management_System.CustomExceptionMiddleware;
using Task_Management_System.Data;
using Task_Management_System.Models;
using Task_Management_System.Repositories;
using Task_Management_System.Repositories.BlockRepository;
using Task_Management_System.Repositories.CommentRepository;
using Task_Management_System.Repositories.ContactRepository;
using Task_Management_System.Repositories.ProjectRepository;
using Task_Management_System.Repositories.TaskGroupRepository;
using Task_Management_System.Repositories.TaskRepository;
using Task_Management_System.Repositories.UserProjectRepository;
using Task_Management_System.Repositories.UserRepository;
using Task_Management_System.Repositories.UserRoleRepository;
using Task_Management_System.Repositories.UserTaskRepository;
using Task_Management_System.Services;
using Task_Management_System.Services.BlockService;
using Task_Management_System.Services.CommentService;
using Task_Management_System.Services.ContactService;
using Task_Management_System.Services.ImageService;
using Task_Management_System.Services.LabelService;
using Task_Management_System.Services.ProjectRoleService;
using Task_Management_System.Services.ProjectService;
using Task_Management_System.Services.ProPlanService;
using Task_Management_System.Services.SubtaskService;
using Task_Management_System.Services.TaskGroupService;
using Task_Management_System.Services.TaskRoleService;
using Task_Management_System.Services.TaskService;
using Task_Management_System.Services.UserProjectService;
using Task_Management_System.Services.UserRoleService;
using Task_Management_System.Services.UserService;
using Task_Management_System.Services.UserTaskService;
using Task_Management_System.Utils;

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
            services.AddIdentity<User, UserRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<TaskManagementSystemContext>();
            services.AddAuthentication()
                //.AddCookie(cfg => cfg.SlidingExpiration = true)
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = TMSJwtTokens.Issuer,
                        ValidAudience = TMSJwtTokens.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TMSJwtTokens.Key))
                    };
                });
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(new[] { JwtBearerDefaults.AuthenticationScheme })
                .RequireAuthenticatedUser()
                .Build();
            });
            //services.AddAuthorization();

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IBlockRepository, BlockRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskGroupRepository, TaskGroupRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserProjectRepository, UserProjectRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTaskRepository, UserTaskRepository>();

            services.AddScoped<IBlockService, BlockService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ILabelService, LabelService>();
            services.AddScoped<IProjectRoleService, ProjectRoleService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProPlanService, ProPlanService>();
            services.AddScoped<ISubtaskService, SubtaskService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITaskGroupService, TaskGroupService>();
            services.AddScoped<ITaskRoleService, TaskRoleService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserProjectService, UserProjectService>();
            services.AddScoped<IUserTaskService, UserTaskService>();

            services.AddScoped<AuthService, AuthService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddValidationServices();

            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSwagger();

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

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=UserRoles}/{action=Index}/{id?}");
            });

            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseReactDevelopmentServer(npmScript: "start");
            //    }
            //});
        }
    }
}
