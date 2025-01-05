using Microsoft.AspNetCore.Builder;
using Flight.Application.Applications;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataContext();

builder.Services.ConfigureCORS();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddEndpointsApiExplorer();
// change all routes in lower case.
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddOpenApi();

builder.Services.AddRepoService();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseHsts();
    app.MapScalarApiReference(options =>
            options.WithTheme(ScalarTheme.Solarized)
                .WithTitle("ASP.NET Minimal Web Api for Flight Application.")
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
        //.WithCustomCss("Stylesheets/bootstrap-5.3.3/css/bootstrap.css")
    );
}

app.UseHttpsRedirection();

app.UseCors();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();