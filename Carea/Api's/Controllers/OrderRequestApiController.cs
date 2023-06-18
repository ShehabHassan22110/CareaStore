using Carea.API.Models;
using Carea.Api_s.Interfaces;
using Carea.Api_s.Models;
using Carea.BLL.Interface;
using Carea.Extend;
using Carea.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Carea.Api_s.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderRequestApiController : ControllerBase
    {
        private readonly IOrderRequestApiRep _cont;
        private UserManager<ApplicationUser> _userManger;

        public OrderRequestApiController(IOrderRequestApiRep cont, UserManager<ApplicationUser> userManger)
        {
            this._cont = cont;
            _userManger = userManger;
        }


        //Create Order Request

        [HttpPost]
        [Route("/api/Create_orderRequest")]
        public async Task<IActionResult> CreateRequest(OrderRequestVM obj)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    obj.Statues = 0;

                    var data = _cont.Creat(obj);

                    CustomResponse Cusotm = new CustomResponse
                    {

                        Code = "200",
                        Message = "Request Created",
                        Status = "Done"

                    };
                    return Ok(Cusotm);
                }
                return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data Annotation DD" });

            }
            catch (Exception ex)
            {

                return StatusCode(400, new CustomResponse { Code = "400", Message = ex.Message });
            }

        }

        //Get Bu User Id
        [HttpPost]
        [Route("/api/GetOrderRequest_ByUserId/{UserId}")]
        public async Task<IActionResult> Get(string UserId)
        {
            try
            {
                   var data =await _cont.GetbyUserId(UserId);
                if (data!=null && data.Count()!=0)
                {
                    OrderRequestCustomResponse Cusotm = new OrderRequestCustomResponse
                    {

                        Records = data,
                        Code = "200",
                        Message = "Data Returned",
                        Status = "Done"

                    };
                    return Ok(Cusotm);
                }


                return NotFound(new CustomResponse
                {
                    Code = "400",
                    Message = "Invalid Id",
                    Status = "Faild"
                });
            }
            catch (Exception ex)
            {
                return NotFound(new CustomResponse
                {
                    Code = "400",
                    Message = ex.Message,
                    Status = "Faild"
                });

            }
        }
         //Get Bu User Id And Car Id
        [HttpPost]
        [Route("/api/GetOrderRequest_ByUserAndCarId")]
        public IActionResult GetByUserAndCarId(string UserId , int CarId)
        {
            try
            {
                   var data = _cont.GetbycarUserId(CarId,UserId);
                    OrderRequestCustomResponse Cusotm = new OrderRequestCustomResponse
                    {

                        Record = data,
                        Code = "200",
                        Message = "Data Returned",
                        Status = "Done"

                    };
                    return Ok(Cusotm);


            }
            catch (Exception ex)
            {
                return NotFound(new CustomResponse
                {
                    Code = "400",
                    Message = ex.Message,
                    Status = "Faild"
                });

            }
        }


    }
}
