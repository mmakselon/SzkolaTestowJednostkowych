using Newtonsoft.Json;
using System.IO;

namespace SzkolaTestowJednostkowych.Mocking
{
    public class ConfigHelper
    {
        public string GetConnectionString()
        {
            var configFromFile = File.ReadAllText("config.txt");
            var config = JsonConvert.DeserializeObject<Config>(configFromFile);
            return config.ConnectionString;            
        }
    }
}
