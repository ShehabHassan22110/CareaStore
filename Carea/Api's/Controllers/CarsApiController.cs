using Carea.API.Models;
using Carea.Api_s.Interfaces;
using Carea.Api_s.Models;
using Carea.BLL.Interface;
using Carea.Extend;
using Carea.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Carea.Api_s.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsApiController : ControllerBase
    {
        private readonly ICarsApiRep _cont;
        private readonly ICarRateRep _carrate;
        private readonly ICar_RateApiRep _rate;
        private readonly IOffersApiRep _offer;
        private UserManager<ApplicationUser> _userManger;

        public CarsApiController(ICarsApiRep cont, ICar_RateApiRep rate, IOffersApiRep offer, UserManager<ApplicationUser> userManger , ICarRateRep carrate)
        {
            this._cont = cont;
            _rate = rate;
            _offer = offer;
            _userManger = userManger;   
            _carrate = carrate;
        }

        [HttpPost]
        [Route("/api/Filter_Cars")]
        public IActionResult FilterCars(FilterModel model)
        {
            try
            {
                var data = _cont.GetAllCars();

                if (!string.IsNullOrEmpty(model.CarName))
                {
                    data = data.Where(a => a.Car_Name.Contains(model.CarName));
                }
                 if (model.BrandId != 0) 
                {
                    data=data.Where(a=>a.Brand_Id==model.BrandId);
                }
                 if (model.BrandId != 0) 
                {
                    data=data.Where(a=>a.Brand_Id==model.BrandId);
                } 
                if (model.MinPrice != 0) 
                {
                    data=data.Where(a=>a.Car_Price >= model.MinPrice);
                }
                if (model.MaxPrice != 0) 
                {
                    data=data.Where(a=>a.Car_Price <= model.MaxPrice);
                }
                if (model.Rate!=0 && model.Rate<=5)
                {
                    data = data.Where(a => a.Rate == model.Rate);
                }
                if (model.SortBy==1)
                {
                    data = data.OrderBy(a => a.Id);
                }
                if (model.SortBy==2)
                {
                    data = data.OrderByDescending(a => a.Id);
                }
                if (model.SortBy == 3)
                {
                    data = data.OrderByDescending(a => a.Car_Price);
                }
                if (model.SortBy==4)
                {
                    data = data.OrderBy(a => a.Car_Price);
                }
                if (model.CarCondition==1)
                {
                    data = data.Where(a => a.Is_Used==false);

                } 
                if (model.CarCondition==2)
                {
                    data = data.Where(a => a.Is_Used==true);

                }
                CarsCustomResponse Cusotm = new CarsCustomResponse
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
        [Route("/api/GetAll_Cars/{Brand_Id}")]
        public IActionResult Get(int Brand_Id)
        {
            try
            {
                if (Brand_Id==0)
                {
                    var data = _cont.GetAllCars();
                    CarsCustomResponse Cusotm = new CarsCustomResponse
                    {

                        Records = data,
                        Code = "200",
                        Message = "Data Returned",
                        Status = "Done"

                    };
                    return Ok(Cusotm);

                }
                else
                {
                    var data = _cont.GetByBrandId(Brand_Id);
                    CarsCustomResponse Cusotm = new CarsCustomResponse
                    {

                        Records = data,
                        Code = "200",
                        Message = "Data Returned",
                        Status = "Done"

                    };
                    return Ok(Cusotm);
                }

                
              
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
        [Route("/api/GetSearch_Cars/{searchValue}")]
        public IActionResult SearchCars(string searchValue)
        {
            try
            {
                if (string.IsNullOrEmpty(searchValue) )
                {
                    var data = _cont.GetAllCars();
                    CarsCustomResponse Cusotm = new CarsCustomResponse
                    {

                        Records = data,
                        Code = "200",
                        Message = "Data Returned",
                        Status = "Done"

                    };
                    return Ok(Cusotm);

                }
                else
                {
                    var data = _cont.SearchCars(searchValue);

                    CarsCustomResponse Cusotm = new CarsCustomResponse
                    {

                        Records = data,
                        Code = "200",
                        Message = "Data Returned",
                        Status = "Done"

                    };
                    return Ok(Cusotm);
                }

                
              
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
        [Route("/api/Get_CarsbyId/{id}")]
        public IActionResult GetbyId(int id)
        {
            try
            {


                var data = _cont.GetById(id);
                if (data != null)
                {
                    CarsCustomResponse Cusotm = new CarsCustomResponse
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

        [HttpGet]
        [Route("/api/Get_TopCars")]
        public IActionResult GetTop()
        {
            try
            {


                var data = _cont.GetTopRated();
                if (data != null)
                {
                    CarsCustomResponse Cusotm = new CarsCustomResponse
                    {

                        Records = data,
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

        [HttpPost]
        [Route("/api/Get_TopCarsByBrandId/{BrandId}")]
        public IActionResult GetTopByBrand(int BrandId)
        {
            try
            {

                if (BrandId!=0)
                {
                    var data = _cont.GetTopRated();
                    var result = data.Where(a => a.Brand_Id == BrandId).ToList();
                    if (result != null&& result.Count()!=0)
                    {
                        CarsCustomResponse Cusotm = new CarsCustomResponse
                        {

                            Records = result,
                            Code = "200",
                            Message = "Data Returned",
                            Status = "Done"

                        };
                        return Ok(Cusotm);
                    }


                    return StatusCode(400, new CustomResponse { Code = "400", Status = "Faild", Message = "Invalid id" });

                }
                else  
                {
                    var data = _cont.GetTopRated();
                  
                        CarsCustomResponse Cusotm = new CarsCustomResponse
                        {

                            Records = data,
                            Code = "200",
                            Message = "Data Returned",
                            Status = "Done"

                        };
                        return Ok(Cusotm);
            
                    
                }

               



            }
            catch (Exception)
            {

                return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data Annotation" });
            }

        }


        #region Rate
        [HttpPost]
        [Route("/api/PostCar_Rate")]
        public async Task<IActionResult> PostServiceAsync(Car_RateVM obj)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    var user = await _userManger.FindByIdAsync(obj.UserId);
                   
                    var ExistingRaterate = _rate.GetbycarUserId(obj.CarId, obj.UserId);
                    if (ExistingRaterate != null) 
                    {
                        obj.Id=ExistingRaterate.Id;
                        _rate.Edite(obj);
                        CustomResponse CusotmResp = new CustomResponse
                        {

                            Code = "200",
                            Message = "Rate Updated",
                            Status = "Done"

                        };
                        return Ok(CusotmResp);
                    }
                   
                    var data = _rate.Creat(obj);

                    CustomResponse Cusotm = new CustomResponse
                    {

                        Code = "200",
                        Message = "Rate Created",
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


        [HttpPost]
        [Route("/api/Get_CarRateById/{id}")]
        public async Task<IActionResult> GetRatebyId(int id)
        {
            try
            {

                List<Car_RateVM> listrecords = new List<Car_RateVM>();
                var data =await _rate.GetbycarIdAsync(id);

                if (data != null)
                {
                    //foreach (var item in data)
                    //{
                    //    var user = await _userManger.FindByIdAsync(item.UserId);

                    //    if (user.imgUrl != null&&item.UserImg == null)
                    //    {
                           
                    //            item.UserImg = user.imgUrl;
                    //    }
                    //    listrecords.Add(item);
                    //}

                    CarRateCustomResponse Cusotm = new CarRateCustomResponse
                    {

                        Records = data,
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



        #endregion


        #region Offers
        [HttpGet]
        [Route("/api/GetAll_Offers")]
        public IActionResult GetOffers()
        {
            try
            {
                
               
                    var data = _offer.GetAllOfferss();
                    OffersCustomResponse Cusotm = new OffersCustomResponse
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
        [Route("/api/Get_OfferById/{OfferId}")]
        public IActionResult GetOfferById(int OfferId)
        {
            try
            {
                
                    var data = _offer.GetById(OfferId);
                if (data != null)
                {
                    OffersCustomResponse Cusotm = new OffersCustomResponse
                    {
                        Record = data,
                        Code = "200",
                        Message = "Data Returned",
                        Status = "Done"

                    };
                    return Ok(Cusotm);
                }
                else
                {
                    return NotFound(new CustomResponse
                    {
                        Code = "400",
                        Message = "Offer Id Is not valid",
                        Status = "Faild"
                    });
                }
                   

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
        #endregion
    }
}
