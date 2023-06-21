using Carea.Interfaces;
using Carea.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carea.Api_s.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermsConditionsApiController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITerms_ConditionsSevice doc;
        #region
        public TermsConditionsApiController(IMapper mapper, ITerms_ConditionsSevice doc)
        {
            this.mapper = mapper;
            this.doc = doc;
        }
        #endregion

        #region Get All TermsConditions
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = doc.Get();
            var result = mapper.Map<IEnumerable<Terms_ConditionsVM>>(data);
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
            var result = mapper.Map<Terms_ConditionsVM>(data);
            return Ok(data);


        }
        #endregion
    }
}
