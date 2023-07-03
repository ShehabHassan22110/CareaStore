using Carea.BLL.Interface;
using Carea.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Carea.Controllers {
	[Authorize]
	public class NotaficationController : Controller {

		private readonly INotificationService _notificationService;
		public NotaficationController( INotificationService notificationService ) {
			_notificationService = notificationService;
		}

		public IActionResult Push() {
			//ViewBag.userId = User.FindFirst("Id").Value;
			return View();
		}

		public async Task<JsonResult> send( NotificationModel notificationModel ) {

			var result = await _notificationService.SendNotification(notificationModel);
			return Json(result);
		}
	}
}
