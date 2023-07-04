using AutoMapper;
using Carea.BLL.Interface;
using Carea.Extend;
using Carea.Models;
using Carea.ViewModels;
using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Carea.Controllers
{
    [Authorize(Roles = "Admin")]

    public class OrderRequestController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INotificationService _notificationService;
		private readonly IOrderRequestRep _Ident;
        private readonly IConfiguration _configuration;

        //private readonly ICreateOrderServive _orders;
        private readonly IMapper mapper;

        public OrderRequestController(IConfiguration configuration, UserManager<ApplicationUser> userManager, IMapper mapper, IOrderRequestRep ident,INotificationService notificationService )
        {
            this.mapper = mapper;
            this._Ident = ident;
			_notificationService = notificationService;
            userManager = userManager;
            _configuration = configuration;
        }

		public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<OrderRequestVM>>(data);
            return View(result);

        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(OrderRequestVM obj)
        {
            try
            {
                var data = mapper.Map<OrderRequest>(obj);
                _Ident.Creat(data);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<OrderRequestVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(OrderRequestVM model)
        {
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {

            var data = _Ident.GetById(id);
            var result = mapper.Map<OrderRequestVM>(data);




            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OrderRequestVM model)

        {



            var olddata = _Ident.GetById(model.Id);
            olddata.Statues = 1;

            NotificationModel notificationModel = new NotificationModel {
                DeviceId= "daBkZ98fT0iLzssohRrEov:APA91bHv6leXSVd3wzEnPRp5965IsBNni87dSfINAOct3XUg-ypP7IIDgJXeQW4IeG31xNwhukoWl5Rn53PTNxaJe5uXrbOMgneXpR5RKkfbMup9HV-K2Dw5B27fkbZUOD6JpjqXdFuQ",
				Title = "title order request",
                Body = "Body Test  order request"
			};

			CreateOrderVM orderObj = new CreateOrderVM
            {
                CarsId= olddata.CarId,
                ApplicationUser= model.ApplicationUser,
            };

                _Ident.Edit(olddata);
		//	var result = await _notificationService.SendNotification(notificationModel);

			return RedirectToAction("Index");

        } 
        [HttpGet]
        public IActionResult Reject(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<OrderRequestVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Reject(OrderRequestVM model)

        {


            var olddata = _Ident.GetById(model.Id);
            olddata.Statues = 2;

            //var data = mapper.Map<OrderRequest>(model);
            //data.Statues = 1;
            _Ident.Edit(olddata);
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<OrderRequestVM>(data);
            return View(result);
        }

    }

}

  