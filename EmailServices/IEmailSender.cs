using System;
using System.Threading.Tasks;
namespace EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message, string id);
        Task SendEmailAsync(Message message, string id , string user);
        Task SendEmailAsync2(Message message, string email, string text2, string text);
        Task SendEmailAsync4(Message message, string email, string text2, string text);
        //Task SendEmailAsync3(Message message, string id, string user, TbRequest element);
        Task SendEmailAsyncToCustomerWithBookingDetails(Message message, Guid id);
        Task sendEmailForResetPassword(Message message, Guid id);
        Task SendEmailAsyncToCustomer(Message message);

        Task SendEmailAsyncToCustomerNotConfirmedBooking(Message message, string Comment, string CustomerEmail);
        Task SendEmailCareaAsync(string email, string v1, string v2);
    }
}
