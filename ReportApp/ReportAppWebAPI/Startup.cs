using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ReportApp.DAL.Context;
using ReportApp.DAL.Interfaces;
using ReportApp.DAL.Repositories;
using ReportApp.DAL.UnitOfWork;
using ReportApp.BLL.Mapper;
using ReportApp.BLL.Interfaces;
using ReportApp.BLL.Services;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;

namespace ReportApp.ReportAppWebAPI
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
            services.AddDbContext<ReportContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TaskMapperProfile());
                mc.AddProfile(new ReportMapperProfile());
                mc.AddProfile(new EmployeeMapperProfile());
                mc.AddProfile(new CommentMapperProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ITaskServices, TaskServices>();
            services.AddTransient<IReportServices, ReportServices>();
            services.AddTransient<IEmployeeServices, EmployeeServices>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentServices, CommentServices>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReportApp", Version = "v1" });
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReportApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
