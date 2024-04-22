using Flight.CrossCutting.Assemblies;
using Flight.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Flight.Api;

/// <summary>
///     The startup.
/// </summary>
public class Startup
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Startup" /> class.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    ///     Gets the configuration.
    /// </summary>
    private IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    /// <summary>
    ///     Configures the services.
    /// </summary>
    /// <param name="services">The services.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<FlightContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("SqlServerConnectionString")));

        services.AddControllers();

        //services.AddAutoMapper(AssemblyUtil.GetCurrentAssemblies());

        //services.AddScoped<IVehicleApplication, VehicleApplication>();

        //services.AddScoped<IRepository, VehicleRepository>();

        services.AddSingleton(typeof(IMemoryCache), typeof(MemoryCache));

        services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

        services.AddSwaggerGen();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    /// <summary>
    ///     Configures the.
    /// </summary>
    /// <param name="app">The app.</param>
    /// <param name="env">The env.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();

        app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Flight.Api"); });

        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}