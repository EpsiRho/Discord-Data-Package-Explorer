using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordDataPackageLoader.Classes
{
    public class DiscordEvent
    {
        public string event_type { get; set; }
        public string event_id { get; set; }
        public string user_id { get; set; }
        public string domain { get; set; }
        public string day { get; set; }
        public string client_send_timestamp { get; set; }
        public string client_track_timestamp { get; set; }
        public string timestamp { get; set; }
    }

}
