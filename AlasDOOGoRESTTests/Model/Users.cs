using Newtonsoft.Json;

namespace AlasDOOGoRESTTests.Model
{
    public class Users
    {
        [JsonProperty("id")]
        public int UserID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

    }


}
