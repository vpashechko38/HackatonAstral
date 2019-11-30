using System;
using Hakaton.Data;
using Hakaton.Data.Interface;
using Hakaton.Data.Repository;
using Hakaton.Domain;
using Hakaton.Domain.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Hakaton
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["Connection:ConnectionString"];
            AddContext(services, connectionString);

            AddCors(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IServiceRepository, ServiceRepository>();

            services.AddScoped<IServiceStorage, ServiceStorage>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserStorage, UserStorage>();

            services.AddScoped<IAuthorizationLogic, AuthorizationLogic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceScopeFactory scopeFactory, IServiceProvider serviceProvider)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DataContext>();
                context.Database.Migrate();
            }

            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc(routes =>
                {
                    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                }
            );
        }

        /// <summary>
        /// Регистрация корсов
        /// </summary>
        private static void AddCors(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:80", "http://localhost:5000", "http://booking.astralnalog.ru:80")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        /// <summary>
        /// Регистрация контекста БД
        /// </summary>
        private static void AddContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(
                options => options.UseNpgsql(connectionString,
                    npgSqlOptions =>
                    {
                        npgSqlOptions.MigrationsAssembly(typeof(DataContext).Assembly.GetName()
                            .Name);
                    }));
        }
    }
}
