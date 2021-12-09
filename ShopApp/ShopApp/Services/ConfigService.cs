using System.IO;
using Newtonsoft.Json;
using ShopApp.Configs;
using ShopApp.Services.Abstractions;

namespace ShopApp.Services
{
    public class ConfigService : IConfigService
    {
        public Config DeserializeConfig()
        {
            var configFile = File.ReadAllText("Configs/config.json");
            var config = JsonConvert.DeserializeObject<Config>(configFile, new JsonSerializerSettings());
            return config;
        }
    }
}
