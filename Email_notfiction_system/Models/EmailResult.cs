using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_notfiction_system.Models
{
    public class EmailResult
    {
        public bool Success { get; set; }
        public string MessageId { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
