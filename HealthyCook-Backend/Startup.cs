using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.IServices;
using HealthyCook_Backend.Persistence.Context;
using HealthyCook_Backend.Persistence.Repositories;
using HealthyCook_Backend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HealthyCook_Backend
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
            services.AddDbContext<AplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Conexion")));

            // Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRecipeDetailsService, RecipeDetailsService>();
            services.AddScoped<IRestaurantOwnerService, RestaurantOwnerService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IRecipeRatingService, RecipeRatingService>();
            services.AddScoped<IRecipesSavedService, RecipesSavedService>();
            services.AddScoped<IIngredientTypeService, IngredientTypeService>();
            services.AddScoped<IExcludedIngredientsService, ExcludedIngredientsService>();
            // Repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeDetailsRepository, RecipeDetailsRepository>();
            services.AddScoped<IRestaurantOwnerRepository, RestaurantOwnerRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IRecipeRatingRepository, RecipeRatingRepository>();
            services.AddScoped<IRecipesSavedRepository, RecipesSavedRepository>();
            services.AddScoped<IIngredientTypeRepository, IngredientTypeRepository>();
            services.AddScoped<IExcludedIngredientsRepository, ExcludedIngredientsRepository>();
            // Cors
            services.AddCors(options => options.AddPolicy("AllowWebapp",
                             builder => builder.AllowAnyOrigin().
                                                AllowAnyHeader().
                                                AllowAnyMethod()));

            services.AddControllers().AddNewtonsoftJson(options =>
                                                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //AddSwagger
            AddSwagger(services);
            // ^^^^^^^^
        }
        //AddSwagger
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Ecc {groupName}",
                    Version = groupName,
                    Description = "ECC API",
                    Contact = new OpenApiContact
                    {
                        Name = "EveryCanCook Company",
                        Email = string.Empty,
                        Url = new Uri("https://everycancook.github.io/Landing-Page-EveryCanCook/"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }
        // ^^^^^^^^

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecc API V1");
            });


            // ^^^^^^^^
            app.UseCors("AllowWebapp");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
