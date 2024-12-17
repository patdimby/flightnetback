using Microsoft.AspNetCore.Builder;
using Flight.Application.Applications;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataContext();
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepoService();
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Flight.Api"); });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.UseAuthorization();



app.MapControllers();

await app.RunAsync();