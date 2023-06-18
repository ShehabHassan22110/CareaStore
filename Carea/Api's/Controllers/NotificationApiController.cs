using Carea.BLL.Interface;
using Carea.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carea.Api_s.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationApiController : ControllerBase {
        private readonly INotificationService _notificationService;
        public NotificationApiController( INotificationService notificationService ) {
            _notificationService = notificationService;
        }

        [Route("send")]
        [HttpPost]
        public async Task<IActionResult> SendNotification( NotificationModel notificationModel ) {
            var result = await _notificationService.SendNotification(notificationModel);
            return Ok(result);
        }
    }
}
