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

    public class PhotoColorController : Controller
    {
        private readonly ICar_Photo_ColorRep _Ident;
        private readonly ICarsRep _car;
        private readonly IMapper mapper;

        public PhotoColorController(IMapper mapper, ICar_Photo_ColorRep ident, ICarsRep car)
        {
            this.mapper = mapper;
            this._Ident = ident;
            _car = car;
        }

        public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<Car_Photo_ColorVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create(int id)
        {
            var car = _car.GetById(id);
            var result = mapper.Map<CarsVM>(car);
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Car_Photo_ColorVM obj,int id)
        {
            //try
            //{
                var img = UploadCv.uploadFile("Uploads/Cars", obj.Photo);
                var data = mapper.Map<Car_Photo_Color>(obj);
                data.imgUrl = img;
                data.Car_Id = id;
            Car_Photo_Color model = new Car_Photo_Color { Car_Id = id, imgUrl = img ,Color_Code=obj.Color_Code};

            _Ident.Creat(model);
                return RedirectToAction("Index");
            //}
            //catch (Exception ex)
            //{
            //    return View();
            //}
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<Car_Photo_ColorVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Car_Photo_ColorVM model)
        {
            UploadCv.RemoveFile("Uploads/Cars", model.imgUrl);
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index","Cars");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<Car_Photo_ColorVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Car_Photo_ColorVM model)

        {
            if (model.Photo == null)
            {
                var url = model.imgUrl;
                var data = mapper.Map<Car_Photo_Color>(model);
                data.imgUrl = url;
                _Ident.Edit(data);
                return RedirectToAction("Index", "Cars");
            }
            else
            {
                var IdentityImgUrl = UploadCv.uploadFile("Uploads/Cars", model.Photo);
                var data = mapper.Map<Car_Photo_Color>(model);
                data.imgUrl = IdentityImgUrl;
                _Ident.Edit(data);
                return RedirectToAction("Index", "Cars");
            }

        }
        public IActionResult Details(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<Car_Photo_ColorVM>(data);
            return View(result);
        }

    }

}
