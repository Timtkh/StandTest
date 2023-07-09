using Aquality.Selenium.Core.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExamTest.Framework.Utils
{
    public static class JsonUtils
    {
        public static T Deserialize<T>(string json)
        {
            Logger.Instance.Info("JsonUtils deserialize");
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static JObject Parse(string json)
        {
            Logger.Instance.Info("JsonUtils parse to JObject");
            return JObject.Parse(json);
        }
    }
}