using Carea.Api_s.Interfaces;
using Carea.Entities;
using Carea.Helper;
using Carea.Interfaces;
using Carea.Models;
using Carea.Services;
using Carea.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using System;

namespace Carea.Api_s.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Complaints_SuggestionsApiController : Controller
	{
        private readonly IMapper mapper;
        private readonly IComplaints_SuggestionsService doc;
        private readonly IDynamicRep<IComplaints_SuggestionsService> rep;
        private readonly ApplicationDbContext _context;

        #region
        public Complaints_SuggestionsApiController(IMapper mapper, IComplaints_SuggestionsService doc , IDynamicRep<IComplaints_SuggestionsService> rep , ApplicationDbContext context)
        {
            this.mapper = mapper;
            this.doc = doc;
            this.rep = rep;
            this._context = context;

        }
        #endregion

        #region Get All TermsConditions
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = doc.Get();
            var result = mapper.Map<IEnumerable<Complaints_SuggestionsVM>>(data);
            return Ok(data);
        }
        #endregion

        #region Get By Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = doc.GetById(id);
            if (data == null)
                return NotFound();
            var result = mapper.Map<Complaints_SuggestionsVM>(data);
            return Ok(data);


        }
        #endregion


        #region Complaints_Suggestions

        //[HttpPost("Create")]
        [HttpPost("Create")]
        public async Task<ActionResult<Complaints_Suggestions>> PostPost(Complaints_SuggestionsVM model) 
            {
            var map = new Complaints_Suggestions {
                Id = model.Id,
                Details = model.Details,


            }; var data = _context.Complaints_Suggestions.Add(map);
            await _context.SaveChangesAsync();

            if (data == null) {
                return NotFound(new ApiResponse<string> {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Done!",
                    Error = "Complaints & Suggestions Not Created"
                });
            }
            return Ok(new ApiResponse<Complaints_Suggestions> {
                Code = "200",
                Status = "OK",
                Message = "Complaints & Suggestions Created",
            });
        }

       
        #endregion

    }
}
