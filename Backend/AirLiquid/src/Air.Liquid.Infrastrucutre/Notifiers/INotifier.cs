using System;
using System.Collections.Generic;
using System.Text;

namespace Air.Liquide.Infrastrucutre.Notifiers
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void SetNotification(Notification notification);
    }
}
