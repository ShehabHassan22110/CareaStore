using Carea.Api.Models;
using Carea.Helper;
using Carea.Models;
using static Carea.Models.ResetPasswordModel;

namespace Carea.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginModel model);
        Task<UserManagerResponse> ConfirmEmailAsync(string userId , string token);
        Task<UserManagerResponse> ForgetPasswordAsync(string Email);
        Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel model);
        Task<UserModel> GetAccount(string id);
        Task<EditeAccountCustomRespon> EditeProffile(EditeProfileModel model);
        Task<UserManagerResponse> EditePassword(EditePassword model);
    }
}
