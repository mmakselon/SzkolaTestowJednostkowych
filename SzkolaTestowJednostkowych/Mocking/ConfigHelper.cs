using Newtonsoft.Json;
using System.IO;

namespace SzkolaTestowJednostkowych.Mocking
{
    public class FileReader : IFileReader
    {
        public string Read(string filename)
        {
            return File.ReadAllText(filename);
        }
    }

    public class ConfigHelper
    {
        private IFileReader _fileReader;
        public ConfigHelper(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }
        public string GetConnectionString()
        {
            var configFromFile = _fileReader.Read("config.txt");
            var config = JsonConvert.DeserializeObject<Config>(configFromFile);

            if (config == null)
            {
                throw new System.Exception("Incorrect parsing config.");
            }

            return config.ConnectionString;            
        }
    }
}
