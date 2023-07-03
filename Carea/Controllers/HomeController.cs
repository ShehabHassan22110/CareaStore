using Carea.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Carea.Extend;
using Carea.BLL.Interface;
using Carea.ViewModels;
using Carea.Interfaces;
using Carea.Entities;

namespace Carea.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICarsRep carsRep;
        private readonly IBrandRep brandRep;
        private readonly IOrderRequestRep orderRequestRep;
        private readonly ICreateOrderRep createOrderRep;
        private readonly IComplaints_SuggestionsService complaints_SuggestionsService;

        public HomeController(UserManager<ApplicationUser> userManager , ICarsRep carsRep , IBrandRep brandRep ,IOrderRequestRep orderRequestRep , ICreateOrderRep createOrderRep,IComplaints_SuggestionsService complaints_SuggestionsService )

        {
            this.userManager = userManager;
            this.carsRep = carsRep;
            this.brandRep = brandRep;
            this.orderRequestRep = orderRequestRep;
            this.createOrderRep = createOrderRep;
            this.complaints_SuggestionsService = complaints_SuggestionsService;
        }

        public IActionResult Index() {

            var DataUsers = userManager.Users;
            var DataComlains = complaints_SuggestionsService.Get();
            var dataRequest = orderRequestRep.Get();
            var dataOrder = createOrderRep.Get();
            var dataCar = carsRep.Get();
            var dataBrand = brandRep.Get();

            ReportsVM model = new ReportsVM() {
                UsersCount = DataUsers.Count(),
                ComplainsCount = DataComlains.Count(),
                OrderRequestCount = dataRequest.Count(),
                CreateOrderCount = dataOrder.Count(),
                CarCount = dataCar.Count(),
                BrandCount = dataBrand.Count()

            };


            return View(model);
        }

      
    }
}