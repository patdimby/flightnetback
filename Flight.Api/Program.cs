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
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddEndpointsApiExplorer();
// change all routes in lower case.
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// builder.Services.AddOpenApi();

// avoid error : Could not resolve reference: Could not resolve pointer:
builder.Services.AddSwaggerGen(c =>  c.CustomSchemaIds(s => s.FullName.Replace("+", ".")));


builder.Services.AddRepoService();
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Flight Api"); });    
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();