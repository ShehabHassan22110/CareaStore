using Carea.Interfaces;
using Carea.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carea.Api_s.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivacyPolicyApiController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPrivacyPolicyService doc;
        #region
        public PrivacyPolicyApiController(IMapper mapper, IPrivacyPolicyService doc)
        {
            this.mapper = mapper;
            this.doc = doc;
        }
        #endregion

        #region Get All PrivacyPolicy
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = doc.Get();
            var result = mapper.Map<IEnumerable<PrivacyPolicyVM>>(data);
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
            var result = mapper.Map<PrivacyPolicyVM>(data);
            return Ok(data);


        }
        #endregion
    }
}
