using Carea.Entities;
using Carea.Interfaces;
using Carea.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carea.Controllers
{
    [Authorize(Roles = "Admin")]

    public class PrivacyPolicyController : Controller
    {
        private readonly IPrivacyPolicyService _doc;

        private readonly IMapper mapper;

        public PrivacyPolicyController(IMapper mapper, IPrivacyPolicyService doc)
        {
            this.mapper = mapper;
            this._doc = doc;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<PrivacyPolicyVM>>(data);
            return View(result);

        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public  IActionResult Create(PrivacyPolicyVM obj)
        {
            try
            {
                var data = mapper.Map<PrivacyPolicy>(obj);
                _doc.Create(data);
                return RedirectToAction("Index");
            }
            catch (Exception )
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<PrivacyPolicyVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(PrivacyPolicyVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<PrivacyPolicyVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(PrivacyPolicyVM model)

        {
            var data = mapper.Map<PrivacyPolicy>(model);
            _doc.Edit(data);
            return RedirectToAction("Index");
        }

    }

}
