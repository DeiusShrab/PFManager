using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PFManager.DBOModels;
using PFManager.Models;
using PFManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager
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
      services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));
      services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

      #region DBO Services

      services.AddSingleton<BestiaryDBOService>();
      services.AddSingleton<BestiaryDetailDBOService>();
      services.AddSingleton<BestiaryTypeDBOService>();
      services.AddSingleton<CampaignDBOService>();
      services.AddSingleton<CampaignDataDBOService>();
      services.AddSingleton<ChatMessageDBOService>();
      services.AddSingleton<ContinentDBOService>();
      services.AddSingleton<EnvironmentTerrainDBOService>();
      services.AddSingleton<MonsterSpawnDBOService>();
      services.AddSingleton<MonthDBOService>();
      services.AddSingleton<PermissionDBOService>();
      services.AddSingleton<PlaneDBOService>();
      services.AddSingleton<PlayerDBOService>();
      services.AddSingleton<SeasonDBOService>();
      services.AddSingleton<TimeDBOService>();
      services.AddSingleton<TrackedEventDBOService>();
      services.AddSingleton<WeatherDBOService>();
      services.AddSingleton<WeatherSpawnDBOService>();

      #endregion

      var mapperConfig = new MapperConfiguration(cfg =>
      {
        #region Mapper Configs

        cfg.CreateMap<BestiaryDBO, Messages.Models.Bestiary>();
        cfg.CreateMap<BestiaryDetailDBO, Messages.Models.BestiaryDetail>();
        cfg.CreateMap<BestiaryTypeDBO, Messages.Models.BestiaryType>();
        cfg.CreateMap<CampaignDBO, Messages.Models.Campaign>();
        cfg.CreateMap<CampaignDataDBO, Messages.Models.CampaignData>();
        cfg.CreateMap<ChatMessageDBO, Messages.Models.ChatMessage>();
        cfg.CreateMap<ContinentDBO, Messages.Models.Continent>();
        cfg.CreateMap<EnvironmentTerrainDBO, Messages.Models.EnvironmentTerrain>();
        cfg.CreateMap<MonsterSpawnDBO, Messages.Models.MonsterSpawn>();
        cfg.CreateMap<MonthDBO, Messages.Models.Month>();
        cfg.CreateMap<PermissionDBO, Messages.Models.Permission>();
        cfg.CreateMap<PlaneDBO, Messages.Models.Plane>();
        cfg.CreateMap<PlayerDBO, Messages.Models.Player>();
        cfg.CreateMap<SeasonDBO, Messages.Models.Season>();
        cfg.CreateMap<TimeDBO, Messages.Models.Time>();
        cfg.CreateMap<TrackedEventDBO, Messages.Models.TrackedEvent>();
        cfg.CreateMap<WeatherDBO, Messages.Models.Weather>();
        cfg.CreateMap<WeatherSpawnDBO, Messages.Models.WeatherSpawn>();

        #endregion
      });

      services.AddSingleton(mapperConfig.CreateMapper());

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "PFManager", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PFManager v1"));
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
