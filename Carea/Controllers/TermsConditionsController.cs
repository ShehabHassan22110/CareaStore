using Carea.Entities;
using Carea.Interfaces;
using Carea.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carea.Controllers
{
    //[Authorize(Roles = "Admin")]

    public class TermsConditionsController : Controller
    {
        private readonly ITerms_ConditionsSevice _doc;

        private readonly IMapper mapper;

        public TermsConditionsController(IMapper mapper, ITerms_ConditionsSevice doc)
        {
            this.mapper = mapper;
            this._doc = doc;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<Terms_ConditionsVM>>(data);
            return View(result);

        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public  IActionResult Create(Terms_ConditionsVM obj)
        {
            try
            {
                var data = mapper.Map<Terms_Conditions>(obj);
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
            var result = mapper.Map<Terms_ConditionsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Terms_ConditionsVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<Terms_ConditionsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Terms_ConditionsVM model)

        {
            var data = mapper.Map<Terms_Conditions>(model);
            _doc.Edit(data);
            return RedirectToAction("Index");
        }

    }

}
