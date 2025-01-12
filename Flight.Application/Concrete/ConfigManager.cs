using System.IO;
using Microsoft.Extensions.Configuration;

namespace Flight.Application.Concrete
{
    public class ConfigManager
	{
		public IConfiguration AppSetting { get; }
		public ConfigManager()
		{
			AppSetting = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json")
					.Build();
		}
	}
}
