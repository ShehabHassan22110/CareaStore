using Carea.API.Models;
using Carea.Api_s.Interfaces;
using Carea.Api_s.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carea.Api_s.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandApiController : ControllerBase
    {
        private readonly IBrandApiRep _cont;

        public BrandApiController(IBrandApiRep cont)
        {
            this._cont = cont;
        }



        [HttpGet]
        [Route("/api/GetAll_Brand")]
        public IActionResult Get()
        {
            try
            {
                var data = _cont.GetAllBrands();

                BrandCustomResponse Cusotm = new BrandCustomResponse
                {

                    Records = data,
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
        [HttpPost]
        [Route("/api/Get_BrandbyId/{id}")]
        public IActionResult GetbyId(int id)
        {
            try
            {
                var data = _cont.GetById(id);
                if (data != null)
                {
                    BrandCustomResponse Cusotm = new BrandCustomResponse
                    {
                        Record = data,
                        Code = "200",
                        Message = "Data Returned",
                        Status = "Done"
                    };
                    return Ok(Cusotm);
                }
                return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid id" });
            }
            catch (Exception)
            {
                return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data Annotation" });
            }

        }

    }
}
