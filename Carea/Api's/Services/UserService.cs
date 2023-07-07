using Carea.Api.Models;
using Carea.API.Models;
using Carea.Extend;
using Carea.Helper;
using Carea.Interfaces;
using Carea.Models;
using Carea.Services.Interfaces;
using EmailService;
using Helper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using static Carea.Models.ResetPasswordModel;
using static EmailService.Message;

namespace Carea.Services
{
    public class UserService : IUserService
    {
        private UserManager<ApplicationUser> _userManger;
        private IConfiguration _configuration;
        IEmailSender _emailSender;
        private readonly IMailService _mailService;

        public UserService(UserManager<ApplicationUser> userManager, IConfiguration configuration, IEmailSender emailSender , IMailService mailService)
        {
            _userManger = userManager;
            _configuration = configuration;
          
            _emailSender=emailSender;
            _mailService = mailService;
        }



        public async Task<UserManagerResponse> RegisterUserAsync(RegisterModel model)
        {
            if (model == null)
                throw new NullReferenceException("Reigster Model is null");
               var user = new ApplicationUser

               {
                UserName = model.Email,
                Email = model.Email,
                   Nickname = model.Nickname,
                   FullName = model.FullName,
                   PhoneNumber=model.PhoneNumber,
                   BirthDate = model.BirthDate,
                   Gender = model.Gender,
                   PIN = model.PIN,
                   device_id = model.device_id
               };

            var result = await _userManger.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                #region Token
                var claims = new[]
            {
                new Claim("Id", user.Id),
                new Claim("FullName", user.FullName),
                new Claim("NickName", user.Nickname),
                new Claim("Email", model.Email),
                new Claim("PhoneNumber",$"{user.PhoneNumber}"),
                new Claim("Gender", $"{user.Gender}"),
                new Claim("pin",$"{user.PIN}"),
                new Claim("BirthDate",$"{user.BirthDate.ToShortDateString()}"),
                new Claim("imgurl",$"{user.imgUrl}"),
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
                    string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
                #endregion
                return new UserManagerResponse
                {
                    Message = "User created successfully!",
                    IsSuccess = true,
                    Token = tokenAsString
                };
            }

            return new UserManagerResponse
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }



        public async Task<UserManagerResponse> LoginUserAsync(LoginModel model)
        {
            var user = await _userManger.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that Email address",
                    IsSuccess = false,
                };
            }

            var result = await _userManger.CheckPasswordAsync(user, model.Password);
            if (!result)
                return new UserManagerResponse
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                };
         
            var claims = new[]
            {
                new Claim("Id", user.Id),
                //new Claim("DeviceId", user.device_id),
                new Claim("FullName", user.FullName),
                new Claim("NickName", user.Nickname),
                new Claim("Email", model.Email),
                new Claim("PhoneNumber",$"{user.PhoneNumber}"),
                new Claim("Gender", $"{user.Gender}"),
                new Claim("pin",$"{user.PIN}"),
                new Claim("BirthDate",$"{user.BirthDate.ToShortDateString()}"),
                new Claim("imgurl",$"{user.imgUrl}"),
            };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
                string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = "User Login successfully!",
                IsSuccess = true,
                Token = tokenAsString
            };
        }

        public async Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManger.FindByIdAsync(userId);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "User not found"
                };

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);
            var result = await _userManger.ConfirmEmailAsync(user, normalToken);
            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Email confirmed successfully!",
                    IsSuccess = true,
                };
            return new UserManagerResponse
            {
                IsSuccess = false,
                Message = "Email did not confirm",
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<UserManagerResponse> ForgetPasswordAsync(string email)
        {
            var user = await _userManger.FindByEmailAsync(email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            var token = await _userManger.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}ResetPassword?email={email}&token={validToken}";

            await _mailService.SendEmailAsync(email, "Reset Password", "<h1>Follow the instructions to reset your password</h1>" +
                $"<p>To reset your password <a href='{url}'>Click here</a></p>");

            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Reset password URL has been sent to the email successfully!"
            };
        }

        public async Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            var user = await _userManger.FindByEmailAsync(model.Email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };
            if (model.NewPassword != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Password doesn't match its confirmation",
                };
            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);
            var result = await _userManger.ResetPasswordAsync(user, normalToken, model.NewPassword);
            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Password has been reset successfully!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }

        public async Task<UserModel> GetAccount(string id)
        {
            var data = await _userManger.FindByIdAsync(id);

            UserModel obj = new UserModel()
            {
                Name = data.FullName,
                Phone = data.PhoneNumber,
                ImgUrl = "/Uploads/Users/" + data.imgUrl,

                Gender = data.Gender,
                Email = data.Email,
                Id = data.Id,
                userNAme = data.UserName,

            };
            return obj;
        }

        public async Task<EditeAccountCustomRespon> EditeProffile(EditeProfileModel model)
        {
            var user = await _userManger.FindByIdAsync(model.Id);
            if (model.Email == null)
            {
                model.Email = user.Email;
            }

            if (model.FullName == null)
            {
                model.FullName = user.FullName;
            }

          if ( model.Gender == null)
            {
                model.Gender = user.Gender;
            }

        

            //chek user exist
            if (user == null)
            {
                EditeAccountCustomRespon custom = new EditeAccountCustomRespon()
                {
                    Code = "400",
                    Message = "User Not Found",
                    Status = "Faild",
                    IsSuccess = false,
                };
                return (custom);
            }

            //check user name and Email 
            var userWithSameEmail = await _userManger.FindByEmailAsync(model.Email);
            if (userWithSameEmail != null && userWithSameEmail.Id != model.Id)
            {

                EditeAccountCustomRespon custom = new EditeAccountCustomRespon()
                {
                    Code = "400",
                    Message = "Email is Used ",
                    Status = "Faild",
                    IsSuccess = false,
                };
                return (custom);
            }

            user.Email = model.Email;
            user.FullName = model.FullName;
            user.PhoneNumber = model.PhoneNumber;
            user.UserName = model.Email;
            user.Nickname = model.NickName;
            user.PIN = model.PIN;
            user.Gender = model.Gender;

            if (model.Photo != null)
            {
                var img = UploadCv.uploadFile("Uploads/Users", model.Photo);
                user.imgUrl = img;
            }





            var result = await _userManger.UpdateAsync(user);

            if (result.Succeeded)
            {
                var claims = new[]
      {
                new Claim("Id", user.Id),
                new Claim("FullName", user.FullName),
                new Claim("NickName", user.Nickname),
                new Claim("Email", model.Email),
                new Claim("PhoneNumber",$"{user.PhoneNumber}"),
                new Claim("Gender", $"{user.Gender}"),
                new Claim("pin",$"{user.PIN}"),
                new Claim("BirthDate",$"{user.BirthDate.ToShortDateString()}"),
                 new Claim("imgurl",$"{user.imgUrl}"),

            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

                string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
                EditeAccountCustomRespon custom = new EditeAccountCustomRespon()
                {
                    Message = "Account Updated Successfully",
                    Token = tokenAsString,
                    Code = "200",
                    Status = "succeed",
                    IsSuccess = true,


                };
                return (custom);
            }
            else
            {
                EditeAccountCustomRespon custom = new EditeAccountCustomRespon()
                {
                    Code = "400",
                    Message = "Something is wrong ",
                    Status = "Faild",
                    IsSuccess = false,
                };
                return (custom);
            }


        }


        public async Task<UserManagerResponse> EditePassword(EditePassword model)
        {
            var user = await _userManger.FindByIdAsync(model.UserId);

            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            //Check old Password
            var oldpasword = await _userManger.CheckPasswordAsync(user, model.OldPaassword);
            if (!oldpasword)
                return new UserManagerResponse
                {
                    Message = "Invalid Old password",
                    IsSuccess = false,
                };
            //Check Password Confirmation
            if (model.NewPassword != model.ConfirmNewPassword)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Password doesn't match its confirmation",
                };


            //Generate User Token
            var token = await _userManger.GeneratePasswordResetTokenAsync(user);

            //Edite Password

            var result = await _userManger.ResetPasswordAsync(user, token, model.NewPassword);
            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Password has been Updated Sucessfully!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }
    }
}
