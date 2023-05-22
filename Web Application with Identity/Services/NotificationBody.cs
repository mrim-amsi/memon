using System.ComponentModel.DataAnnotations;

namespace Web_Application_with_Identity.Services
{
    public enum NotificationStatus
    {
        Success = 1,
        Info,
        Warning,
        Error,
        Custom
    }

    /// <summary>
    /// يتم استدعاء هذه الفئة حين عرض التنبيهات في الصفحة
    /// </summary>
    public struct NotificationBody
    {

        public string Message { get; set; }
        public NotificationStatus Status { get; set; }
        public string Icon { get; set; }

        /// <summary>
        /// الوسيطات المرسلة إجبارية
        /// </summary>
        /// <param name="message">الرسالة الظاهرة</param>
        /// <param name="status">شكل الرسالة</param>
        /// <param name="icon">الأيقونة اختيارية وهي تظهر في حالة Custom https://bulkit.cssninja.io/_components-icons-sl.html</param>
        public NotificationBody(string message, NotificationStatus status, string icon = "")
        {
            Message = message;
            Status = status;
            Icon = icon;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Icon))
                Icon = "bubbles";

            switch (Status)
            {
                case NotificationStatus.Success: return string.Format("notifysuccess('{0}');", Message);
                case NotificationStatus.Info: return string.Format("notifyinfo('{0}');", Message);
                case NotificationStatus.Warning: return string.Format("notifywarning('{0}');", Message);
                case NotificationStatus.Error: return string.Format("notifyerror('{0}');", Message);
                default: return string.Format("notifyshow('{0}','sl sl-icon-{1}');", Message, Icon);

            }


        }
    }
}
