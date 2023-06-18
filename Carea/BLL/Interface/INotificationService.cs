using Carea.Helper;
using Carea.ViewModels;

namespace Carea.BLL.Interface {
    public interface INotificationService {
        Task<NotaficationResponseModel> SendNotification( NotificationModel notificationModel );

    }
}
