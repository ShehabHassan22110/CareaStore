using AutoMapper;
using Carea.BLL.Interface;
using Carea.Models;
using Carea.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carea.Controllers {
    [Authorize(Roles = "Admin")]

    public class CreateOrderController : Controller {

		private readonly ICreateOrderRep _Ident;
		//private readonly ICreateOrderServive _orders;
		private readonly IMapper mapper;

		public CreateOrderController( IMapper mapper,ICreateOrderRep ident ) {
			this.mapper = mapper;
			this._Ident = ident;
		}

		public IActionResult Index() {
			var data = _Ident.Get();
			var result = mapper.Map<IEnumerable<CreateOrderVM>>(data);
			return View(result);

		}



		[HttpGet]

		public IActionResult Create() {
			return View();
		}
		[HttpPost]

		public async Task<IActionResult> Create( CreateOrderVM obj ) {
			try {
				var data = mapper.Map<CreateOrder>(obj);
				_Ident.Create(data);
				return RedirectToAction("Index");
			}
			catch (Exception ex) {
				return View();
			}
		}

		[HttpGet]
		public IActionResult Delete( int id ) {
			var data = _Ident.GetById(id);
			var result = mapper.Map<CreateOrderVM>(data);
			return View(result);
		}
		[HttpPost]
		public IActionResult Delete( CreateOrderVM model ) {
			var olddata = _Ident.GetById(model.Id);
			_Ident.Delete(olddata);
			return RedirectToAction("Index");
		}



		[HttpGet]
		public IActionResult Edit( int id ) {
			var data = _Ident.GetById(id);
			var result = mapper.Map<CreateOrderVM>(data);
			return View(result);
		}
		[HttpPost]
		public IActionResult Edit( CreateOrderVM model ) {
			var olddata = _Ident.GetById(model.Id);
			olddata.Status = 1;



			CreateOrderVM orderObj = new CreateOrderVM {
				CarsId = olddata.CarsId,
				ApplicationUser = model.ApplicationUser,
			};

			_Ident.Edit(olddata);
			return RedirectToAction("Index");

		}
		[HttpGet]
		public IActionResult receive( int id ) {
			var data = _Ident.GetById(id);
			var result = mapper.Map<CreateOrderVM>(data);
			return View(result);
		}
		[HttpPost]
		public IActionResult receive( CreateOrderVM model ) {


			var olddata = _Ident.GetById(model.Id);
			olddata.Status = 2;

			//var data = mapper.Map<CreateOrdert>(model);
			//data.Statues = 1;
			_Ident.Edit(olddata);
			return RedirectToAction("Index");

		}
		public IActionResult Details( int id ) {
			var data = _Ident.GetById(id);
			var result = mapper.Map<CreateOrderVM>(data);
			return View(result);
		}
	}
}
