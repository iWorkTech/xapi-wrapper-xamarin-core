using Newtonsoft.Json;

namespace xAPI.Standard
{
    public partial class InteractionComponent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }
    }

    public class Description
    {
    }

    public partial class InteractionComponent
    {
        public static InteractionComponent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<InteractionComponent>(json, Converter.SETTINGS);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this InteractionComponent self)
        {
            return JsonConvert.SerializeObject(self, Converter.SETTINGS);
        }
    }
}