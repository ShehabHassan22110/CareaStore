using Carea.Api.Models;
using Carea.API.Models;
using Carea.Extend;
using Carea.Helper;
using Carea.Interfaces;
using Carea.Models;
using Carea.Services.Interfaces;
using EmailService;
using Helper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Carea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailSender _emailSender;
        private IConfiguration _configuration;
        private readonly IMailService _mailService;

        public AuthController(IUserService userService, IEmailSender emailSender, IConfiguration configuration,IMailService mailService)
        {

            _userService = userService;
            _emailSender = emailSender;
            _configuration = configuration;
            _mailService = mailService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    await _mailService.SendEmailAsync(model.Email, "New Register", "<h1>Hey!, Thank You to Register in our App </h1><p>New Register at " + DateTime.Now + "</p>");
                    return Ok(result);
                    
  

                }
                return BadRequest(result);
            }
            return BadRequest("Some Inputs are not valid !"); // status code 400
        }


        // /api/auth/login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                    await _mailService.SendEmailAsync(model.Email, "New login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " + DateTime.Now + "</p>");
                    return Ok(result);
     
                }
                
                return BadRequest(result);
            }

         
            return BadRequest("Some properties are not valid");
        }

        private string CreateToken(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }


        [HttpPost("ForgetPassword/{email}")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
                return NotFound();

            var result = await _userService.ForgetPasswordAsync(email);

            if (result.IsSuccess)
                return Ok(result); // 200

            return BadRequest(result); // 400
        }

        // api/auth/resetpassword
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordViewModel model )
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.ResetPasswordAsync(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }



        [HttpPost("GetAccountData/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var data = _userService.GetAccount(id);

            if (data != null)
            {
                UserAccountCustomRespons Cusotm = new UserAccountCustomRespons()

                {
                    Record = await data,
                    Code = "200",
                    Message = "Data Returned",
                    Status = "Done"

                };
                return Ok(Cusotm);

            }
            CustomResponse customResponse = new CustomResponse()
            {
                Code = "400",
                Message = "There Is No User With This Id",
                Status = "Faild"
            };
            return Ok(customResponse);

        }


        [HttpPost("EditeAccount/{id}")]
        public async Task<IActionResult> EditeAccount(string id, [FromForm] EditeProfileModel model)
        {

            if (ModelState.IsValid)
            {
                model.Id = id;
                var data = await _userService.EditeProffile(model);

                if (data.IsSuccess)

                {
                    return Ok(data);
                }

                return BadRequest(data);
            }

            return BadRequest("Some properties are not valid");


        }

        [HttpPost("EditePassword/{id}")]
        public async Task<IActionResult> EditePassword(string id, [FromBody] EditePassword model)
        {

            if (ModelState.IsValid)
            {
                model.Id = id;
                var data = await _userService.EditePassword(model);

                if (data.IsSuccess)

                {
                    return Ok(data);
                }

                return BadRequest(data);
            }

            return BadRequest("Some properties are not valid");


        }


    }



}
