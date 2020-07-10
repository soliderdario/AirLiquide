using System;
using System.Collections.Generic;
using System.Text;

namespace Air.Liquide.Infrastrucutre.Notifiers
{
    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }
        public string Message { get; }
    }
}
