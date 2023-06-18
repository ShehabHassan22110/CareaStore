using Carea.Api_s.Interfaces;
using Carea.Helper;
using Carea.Interfaces;
using Carea.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Carea.Models;
using Carea.API.Models;

namespace Carea.Api_s.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class CreateOrderApiController : ControllerBase
    {

		#region CTOR
		private readonly ICreateOrderService createOrderService;

		public CreateOrderApiController(ICreateOrderService createOrderService) {
			this.createOrderService = createOrderService;
		}
		#endregion

		#region CreateOrder
		[HttpPost("CreateOrder")]
		public IActionResult AddToCart(CreateOrderVM obj) {
			try {

				if (ModelState.IsValid) {

					createOrderService.Create(obj);

					CustomResponse Cusotm = new CustomResponse {

						Code = "200",
						Message = "Order Created Successfully ! ",
						Status = "Done"

					};
					return Ok(Cusotm);
				}
				return StatusCode(400, new CustomResponse { Code = "400", Message = "Faild" });

			}
			catch (Exception Ex) {
				return BadRequest("Exception Error");
			}
		}

		#endregion

		#region DeleteOrder
		[HttpDelete("DeleteOrder")]
		public IActionResult DeleteOrder(string ApplicationUserId, int CarsId) {
			try {

				if (ModelState.IsValid) {
					createOrderService.Delete(ApplicationUserId, CarsId);

					CustomResponse Cusotm = new CustomResponse {

						Code = "200",
						Message = "Order Deleted Successfully ! ",
						Status = "Done"

					};
					return Ok(Cusotm);

				}

				return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data Annotation" });

			}
			catch (Exception ex) {
				return NotFound(new CustomResponse {
					Code = "400",
					Message = ex.Message,
					Status = "Faild"
				});
			}
		}
		#endregion

		#region Get GetOrderByApplcationUserId
		[HttpPost("GetOrderByApplcationUserId")]
		public IActionResult GetOrderByApplcationUserId(string UserId) {
			try {

				var data = createOrderService.GetByApplcationUserId(UserId);
				if (data != null) {
					CreateOrderCustomResponse Cusotm = new CreateOrderCustomResponse {

						Code = "200",
						Message = "Data Returned",
						Status = "Done",
						OrderRecord = data


					};
					return Ok(Cusotm);

				}


				return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid id" });

			}
			catch (Exception) {
				return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data" });

			}

		}

		#endregion

		#region Get GetByOrderStatus
		[HttpPost("GetByOrderStatus")]
		public IActionResult GetByOrderStatus(string Status) {
			try {

				var data = createOrderService.GetByOrderStatus(Status);
				if (data != null) {
					CreateOrderCustomResponse Cusotm = new CreateOrderCustomResponse {

						Code = "200",
						Message = "Data Returned",
						Status = "Done",
						OrderRecord = data


					};
					return Ok(Cusotm);

				}


				return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid id" });

			}
			catch (Exception) {
				return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data" });

			}

		}

		#endregion
	}
}