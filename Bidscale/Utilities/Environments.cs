using System.Text;
using System.Reflection;
using Newtonsoft.Json;

namespace Bidscale.Utilities
{
#nullable disable warnings
    public class Config
    {
        [JsonRequired]
        public string Url { get; set; }
        [JsonRequired]
        public string Username { get; set; }
        [JsonRequired]
        public string Password { get; set; }

        public int Seed { get; set; }
    }
#nullable restore warnings

    public class Environments
    {
        static public string EnvironmentName {
            get {
                string? envVar = System.Environment.GetEnvironmentVariable("TestEnvironment");

                if (String.IsNullOrEmpty(envVar))
                {
                    return "qa1";
                }
                return envVar;
            }
        }

        static public Config Config
        {
            get {
                //Console.WriteLine(EnvironmentName);
                var assembly = Assembly.GetExecutingAssembly();
                var resourceStream = assembly.GetManifestResourceStream(
                    $"Bidscale.EnvironmentData.{EnvironmentName}.json"
                );

                if (resourceStream is null)
                {
                    throw new FileNotFoundException($"Embedded resource not found for {EnvironmentName}");
                }

                string json;
                
                using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
                {
                    json = reader.ReadToEnd();
                }

                var conf = JsonConvert.DeserializeObject<Config>(json);
                if (conf is not null)
                {
                    return conf;
                }

                throw new ArgumentException($"Configuration json for {EnvironmentName} cannot be deserialized");
            }
        }
    }
}
