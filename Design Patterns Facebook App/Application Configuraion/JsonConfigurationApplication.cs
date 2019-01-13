using Newtonsoft.Json;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns_Facebook_App
{
    public static class JsonApplicationConfiguration
    {
        private const string m_ConfigExtension = ".json";
        private const string m_SchemaExtension = ".schema.json";

        public static T Load<T>(string i_FileNameWithoutExtension)
            where T : new()
        {
            var configPath = i_FileNameWithoutExtension + m_ConfigExtension;

            CreateSchemaFile<T>(i_FileNameWithoutExtension);

            if (!File.Exists(configPath))
            {
                return CreateDefaultConfigurationFile<T>(i_FileNameWithoutExtension);
            }

            string content = File.ReadAllText(configPath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static void Save<T>(string i_FileNameWithoutExtension, T configuration)
            where T : new()
        {
            CreateSchemaFile<T>(i_FileNameWithoutExtension);

            var configPath = i_FileNameWithoutExtension + m_ConfigExtension;
            string content = JsonConvert.SerializeObject(configuration);

            File.WriteAllText(configPath, content, Encoding.UTF8);
        }

        private static T CreateDefaultConfigurationFile<T>(string i_FileNameWithoutExtension)
            where T : new()
        {
            var config = new T();
            var configData = JsonConvert.SerializeObject(config);
            var configPath = i_FileNameWithoutExtension + m_ConfigExtension;

            File.WriteAllText(configPath, configData, Encoding.UTF8);

            return config;
        }

        private static void CreateSchemaFile<T>(string i_FileNameWithoutExtension)
            where T : new()
        {
            var schemaPath = i_FileNameWithoutExtension + m_SchemaExtension;
            var schema = Task.Run(async () => await JsonSchema4.FromTypeAsync<T>()).GetAwaiter().GetResult();

            File.WriteAllText(schemaPath, schema.ToJson(), Encoding.UTF8);
        }
    }
}
