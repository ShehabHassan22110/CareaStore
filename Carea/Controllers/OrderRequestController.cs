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

    public class OrderRequestController : Controller
    {
        private readonly IOrderRequestRep _Ident;
        //private readonly ICreateOrderServive _orders;
        private readonly IMapper mapper;

        public OrderRequestController(IMapper mapper, IOrderRequestRep ident)
        {
            this.mapper = mapper;
            this._Ident = ident;
        }

        public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<OrderRequestVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(OrderRequestVM obj)
        {
            try
            {
                var data = mapper.Map<OrderRequest>(obj);
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
            var result = mapper.Map<OrderRequestVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(OrderRequestVM model)
        {
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<OrderRequestVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(OrderRequestVM model)

        {
            var olddata = _Ident.GetById(model.Id);
            olddata.Statues = 1;



            CreateOrderVM orderObj = new CreateOrderVM
            {
                CarsId= olddata.CarId,
                ApplicationUser= model.ApplicationUser,
            };

                _Ident.Edit(olddata);
                return RedirectToAction("Index");

        } 
        [HttpGet]
        public IActionResult Reject(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<OrderRequestVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Reject(OrderRequestVM model)

        {


            var olddata = _Ident.GetById(model.Id);
            olddata.Statues = 2;

            //var data = mapper.Map<OrderRequest>(model);
            //data.Statues = 1;
            _Ident.Edit(olddata);
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<OrderRequestVM>(data);
            return View(result);
        }

    }

}

  