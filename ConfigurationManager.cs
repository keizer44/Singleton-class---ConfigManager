using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;

namespace Singleton___ConfigurationManager
{
    public class MyConfigurationManager
    {
        private static MyConfigurationManager instance;
        private static readonly object _lock = new object();
        private string filePath; 

        public string Title { get; private set; }
        public string Version { get; private set; }
        public string BaseURL { get; private set; }
        public int UsersCapacity { get; private set; }

        public static MyConfigurationManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if(instance == null)
                    {
                        instance = new MyConfigurationManager();
                    }

                    return instance;
                }
            }
        }

        private MyConfigurationManager()
        {
            string json = File.ReadAllText(filePath);
            var config = JsonConvert.DeserializeObject<MyConfigurationManager>(json);
            Title = config.Title;
            Version = config.Version;
            BaseURL = config.BaseURL;
            UsersCapacity = config.UsersCapacity;
        }

        public void SetConfigFilePath(string path)
        {
            filePath = path;
        }
    }
}
