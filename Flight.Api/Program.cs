using Microsoft.AspNetCore.Builder;
using Flight.Application.Applications;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Scalar.AspNetCore;
using Flight.Application.Concrete;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Flight.Infrastructure.Auth;


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

ConfigManager config = new ();

var jwtTokenConfig = config.AppSetting.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
builder.Services.AddJwtService(jwtTokenConfig);

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll",
		builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseHsts();
    app.MapScalarApiReference(options =>
            options.WithTheme(ScalarTheme.Solarized)
                .WithTitle("ASP.NET REST Web Api for ANgular Flight Application.")
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
    );
}

app.UseHttpsRedirection();

app.UseCors();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

await app.RunAsync();