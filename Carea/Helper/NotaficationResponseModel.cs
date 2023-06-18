using Newtonsoft.Json;

namespace Carea.Helper {
    public class NotaficationResponseModel
        {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
