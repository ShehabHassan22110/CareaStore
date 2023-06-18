
using Carea.ViewModels;

namespace Carea.Helper {
    public class CreateOrderCustomResponse
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public IEnumerable<CreateOrderVM> OrderRecord { get; set; }

    }
}
