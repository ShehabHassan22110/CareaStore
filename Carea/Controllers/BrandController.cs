using AutoMapper;
using Carea.BLL.Interface;
using Carea.Models;
using Carea.ViewModels;
using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace Carea.Controllers
{

    public class BrandController : Controller
    {
        private readonly IBrandRep _Ident;
        private readonly IMapper mapper;

        public BrandController(IMapper mapper, IBrandRep ident)
        {
            this.mapper = mapper;
            this._Ident = ident;
        }

        public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<BrandVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(BrandVM obj)
        {
            try
            {
                var img = UploadCv.uploadFile("Uploads/Brand", obj.Photo);
                var data = mapper.Map<Brand>(obj);
                data.LogoUrl = img;
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
            var result = mapper.Map<BrandVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(BrandVM model)
        {
            UploadCv.RemoveFile("Uploads/Brand", model.LogoUrl);
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<BrandVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(BrandVM model)

        {
            if (model.Photo == null)
            {
                var url = model.LogoUrl;
                var data = mapper.Map<Brand>(model);
                data.LogoUrl = url;
                _Ident.Edit(data);
                return RedirectToAction("Index");
            }
            else
            {
                var IdentityImgUrl = UploadCv.uploadFile("Uploads/Brand", model.Photo);
                var data = mapper.Map<Brand>(model);
                data.LogoUrl = IdentityImgUrl;
                _Ident.Edit(data);
                return RedirectToAction("Index");
            }

        }
        public IActionResult Details(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<BrandVM>(data);
            return View(result);
        }

    }

}
