using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordDataPackageLoader.Classes
{
    public class ReportingEvent
    {
        public string? event_type { get; set; }
        public string? event_id { get; set; }
        public string? event_source { get; set; }
        public string? user_id { get; set; }
        public string? domain { get; set; }
        public string? freight_hostname { get; set; }
        public string? ip { get; set; }
        public string? day { get; set; }
        public string? chosen_locale { get; set; }
        public string? detected_locale { get; set; }
        public string? browser { get; set; }
        public string? browser_version { get; set; }
        public string? device { get; set; }
        public string? cfduid { get; set; }
        public string? device_vendor_id { get; set; }
        public string? os { get; set; }
        public string? client_build_number { get; set; }
        public string? release_channel { get; set; }
        public string? client_version { get; set; }
        public string? city { get; set; }
        public string? country_code { get; set; }
        public string? region_code { get; set; }
        public string? time_zone { get; set; }
        public string? message_id { get; set; }
        public string? channel { get; set; }
        public string? channel_type { get; set; }
        public bool is_friend { get; set; }
        [JsonProperty("private")]
        public bool isprivate { get; set; }
        public string? num_attachments { get; set; }
        public string? max_attachment_size { get; set; }
        public string? length { get; set; }
        public string? word_count { get; set; }
        public bool mention_everyone { get; set; }
        public string? emoji_unicode { get; set; }
        public string? emoji_custom { get; set; }
        public string? emoji_custom_external { get; set; }
        public string? emoji_managed { get; set; }
        public string? emoji_managed_external { get; set; }
        public string? emoji_animated { get; set; }
        public bool emoji_only { get; set; }
        public string? num_embeds { get; set; }
        public List<object>? attachment_ids { get; set; }
        public List<object>? sticker_ids { get; set; }
        public List<object>? components { get; set; }
        public string? client_send_timestamp { get; set; }
        public string? client_track_timestamp { get; set; }
        public string? timestamp { get; set; }
    }

}
