using Carea.Api_s.Interfaces;
using Carea.Helper;
using Carea.Interfaces;
using Carea.Services;
using Carea.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Carea.Models;

namespace Carea.BLL.Interface
{
    [Authorize(Roles = "Admin")]

    public class SavedOrdersController : Controller
    {
        private readonly IDynamicRep<CreateOrder> rep;
        private readonly IMapper mapper;

        public SavedOrdersController(IDynamicRep<CreateOrder> rep, IMapper mapper )
        {
            this.rep = rep;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = rep.Get();
            var result = mapper.Map<IEnumerable<CreateOrderVM>>(data);
            return View(result);

        }
        public IActionResult Details(int id)
        {
            var data = rep.GetById(id);
            var result = mapper.Map<CreateOrderVM>(data);
            return View(result);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = rep.GetById(id);
            var result = mapper.Map<CreateOrderVM>(data);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(CreateOrderVM model)
        {
            var olddata = rep.GetById(model.Id);
            rep.Delete(olddata);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) {
            var data = rep.GetById(id);
            var result = mapper.Map<CreateOrderVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(CreateOrderVM model) {
            var data = mapper.Map<CreateOrder>(model);
            rep.Edit(data);
            return RedirectToAction("Index");
        }



    }
}
