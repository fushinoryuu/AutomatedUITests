using Newtonsoft.Json;

namespace Automation.IoCore.Utils
{
    public class TestsFromJson
    {
        [JsonProperty("testsuite")]
        public string TestSuite { get; set; }

        [JsonProperty("testname")]
        public string TestName { get; set; }

        [JsonProperty("description")]
        public string Decription { get; set; }
    }
}