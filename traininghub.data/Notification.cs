using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Traininghub.Data
{
    /// <summary>
    /// One time notification to another User
    /// </summary>
    public class Notification
    {
        public int TargetUserId { get; set; }
        public int SenderId { get; set; }
        public NotificationType Type { get; set; }
        public string Text { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
