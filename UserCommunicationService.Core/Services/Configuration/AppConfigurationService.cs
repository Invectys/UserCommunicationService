using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunicationService.Core.Services.Configuration
{
    public class AppConfigurationService
    {
        public AppConfigurationService()
        {

        }


        public Dictionary<string, string> Values { get; set; } = new Dictionary<string, string>();


        public string GetValue(string key, string def)
        {
            var containsKey = Values.ContainsKey(key);
            if(containsKey)
            {
                return Values[key];
            }

            return def;
        }
    }
}
