using Carea.Entities;
using Carea.Interfaces;
using Carea.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carea.Controllers
{
   // [Authorize(Roles = "Admin")]

    public class Complaints_SuggestionsController : Controller
    {
        private readonly IComplaints_SuggestionsService _doc;

        private readonly IMapper mapper;

        public Complaints_SuggestionsController(IMapper mapper, IComplaints_SuggestionsService doc)
        {
            this.mapper = mapper;
            this._doc = doc;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<Complaints_SuggestionsVM>>(data);
            return View(result);

        }
        public IActionResult Details(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<Complaints_SuggestionsVM>(data);
            return View(result);
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<Complaints_SuggestionsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Complaints_SuggestionsVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<Complaints_SuggestionsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(Complaints_SuggestionsVM model)

        {
            var data = mapper.Map<Complaints_Suggestions>(model);
            _doc.Edit(data);
            return RedirectToAction("Index");
        }

    }

}
