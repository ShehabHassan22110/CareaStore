using AutoMapper;
using Carea.BLL.Interface;
using Carea.Models;
using Carea.ViewModels;
using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carea.Controllers
	{
    [Authorize(Roles = "Admin")]

    public class OffersController : Controller
		{
		private readonly IOffersRep _Ident;
		private readonly IMapper mapper;

		public OffersController(IMapper mapper, IOffersRep ident) {
			this.mapper = mapper;
			this._Ident = ident;
		}

		public IActionResult Index() {
			var data = _Ident.Get();
			var result = mapper.Map<IEnumerable<OffersVM>>(data);
			return View(result);

		}



		[HttpGet]

		public IActionResult Create() {
			return View();
		}
		[HttpPost]

		public async Task<IActionResult> Create(OffersVM obj)
		{
			try {
				var data = mapper.Map<Offers>(obj);
				_Ident.Creat(data);
				return RedirectToAction("Index");
			}
			catch (Exception ex) {
				return View();
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var data = _Ident.GetById(id);
			var result = mapper.Map<OffersVM>(data);
			return View(result);
		}
		[HttpPost]
		public IActionResult Delete(OffersVM model)
		{
			var olddata = _Ident.GetById(model.Id);
			_Ident.Delete(olddata);
			return RedirectToAction("Index");
		}



		[HttpGet]
		public IActionResult Edit(int id)
		{
			var data = _Ident.GetById(id);
			var result = mapper.Map<OffersVM>(data);
			return View(result);
		}
		[HttpPost]

		public IActionResult Edit(OffersVM model)
		{
				var data = mapper.Map<Offers>(model);
				_Ident.Edit(data);
				return RedirectToAction("Index");
			
			

		}
		public IActionResult Details(int id) {
			var data = _Ident.GetById(id);
			var result = mapper.Map<OffersVM>(data);
			return View(result);
		}
	}
}
