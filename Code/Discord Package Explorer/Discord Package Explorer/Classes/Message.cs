using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordDataPackageLoader.Classes
{
    public class Message
    {
        public ulong Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Contents { get; set; }
        public string Attachments { get; set; }
    }
}
