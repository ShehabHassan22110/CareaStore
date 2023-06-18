using Carea.API.Models;

namespace Carea.Api.Models
{
    public class EditeAccountCustomRespon:CustomResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
    }
}
