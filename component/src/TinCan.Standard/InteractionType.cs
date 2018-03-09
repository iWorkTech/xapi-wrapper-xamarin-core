using System.Collections.Generic;
using Newtonsoft.Json;

namespace xAPI.Standard
{
    public class InteractionType
    {
        public static Dictionary<string, object> FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(json, Converter.SETTINGS);
        }
    }
}