using AutoMapper;
using Carea.BLL.Interface;
using Carea.Models;
using Carea.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Carea.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CarsController : Controller
    {
        private readonly ICarsRep _car;
        private readonly IBrandRep _brand;

        private readonly IMapper mapper;

        public CarsController(IMapper mapper, ICarsRep car, IBrandRep brand)
        {
            this.mapper = mapper;
            this._car = car;
            _brand = brand; 
        }

        public IActionResult Index()
        {
            var data = _car.Get();
            
            //var result = mapper.Map<IEnumerable<CarsVM>>(data);
            
            return View(data);

        }

        [HttpGet]

        public IActionResult Create()
        {
           
            var brands = _brand.Get();
            ViewBag.BrandList = new SelectList(brands, "Id", "BrandName");
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(CarsVM obj)
        {
            try
            {
                var data = mapper.Map<Cars>(obj);
                _car.Creat(data);
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
            var data = _car.GetById(id);
            var result = mapper.Map<CarsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(CarsVM model)
        {
            var olddata = _car.GetById(model.Id);
            _car.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            var brands = _brand.Get();
            ViewBag.BrandList = new SelectList(brands, "Id", "BrandName");
            var data = _car.GetById(id);
            var result = mapper.Map<CarsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(CarsVM model)

        {
            var data = mapper.Map<Cars>(model);
            _car.Edit(data);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var data = _car.GetById(id);
            var result = mapper.Map<CarsVM>(data);
            return View(result);
        }

        public IActionResult prediction() {

            return View();
        }
         public IActionResult predicPrie() {

            return View();
        }

    }

}
