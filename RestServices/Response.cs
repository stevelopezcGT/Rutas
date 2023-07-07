using Newtonsoft.Json;

namespace RestServices
{
    public class Response
    {
        [JsonProperty(PropertyName = "isError")]
        public bool IsError { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "result")]
        public object Result { get; set; }

    }
}
