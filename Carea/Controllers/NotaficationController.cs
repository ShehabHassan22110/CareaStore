using Carea.BLL.Interface;
using Carea.Extend;
using Carea.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Carea.Controllers {
	[Authorize]
	public class NotaficationController : Controller {

		private readonly INotificationService _notificationService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration _configuration;

        public NotaficationController( INotificationService notificationService , UserManager<ApplicationUser> userManager , IConfiguration configuration) {
			_notificationService = notificationService;
            this.userManager = userManager;
            this._configuration = configuration;
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
