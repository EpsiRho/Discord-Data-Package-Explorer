using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordDataPackageLoader.Classes
{
    public class FriendSourceFlags
    {
        public bool all { get; set; }
    }

    public class GuildFolder
    {
        public List<string> guild_ids { get; set; }
        public long? id { get; set; }
        public string name { get; set; }
        public int? color { get; set; }
    }

    public class CustomStatus
    {
        public string? text { get; set; }
        public object? expires_at { get; set; }
        public object? emoji_id { get; set; }
        public object? emoji_name { get; set; }
    }

    public class Settings
    {
        public string? locale { get; set; }
        public bool show_current_game { get; set; }
        public List<object>? restricted_guilds { get; set; }
        public bool default_guilds_restricted { get; set; }
        public bool inline_attachment_media { get; set; }
        public bool inline_embed_media { get; set; }
        public bool gif_auto_play { get; set; }
        public bool render_embeds { get; set; }
        public bool render_reactions { get; set; }
        public bool animate_emoji { get; set; }
        public bool enable_tts_command { get; set; }
        public bool message_display_compact { get; set; }
        public bool convert_emoticons { get; set; }
        public int explicit_content_filter { get; set; }
        public bool disable_games_tab { get; set; }
        public string? theme { get; set; }
        public bool developer_mode { get; set; }
        public List<string>? guild_positions { get; set; }
        public bool detect_platform_accounts { get; set; }
        public string? status { get; set; }
        public int afk_timeout { get; set; }
        public int timezone_offset { get; set; }
        public bool stream_notifications_enabled { get; set; }
        public bool allow_accessibility_detection { get; set; }
        public bool contact_sync_enabled { get; set; }
        public bool native_phone_integration_enabled { get; set; }
        public int animate_stickers { get; set; }
        public int friend_discovery_flags { get; set; }
        public FriendSourceFlags? friend_source_flags { get; set; }
        public List<GuildFolder>? guild_folders { get; set; }
        public CustomStatus? custom_status { get; set; }
    }

    public class Connection
    {
        public string? type { get; set; }
        public string? id { get; set; }
        public string? name { get; set; }
        public bool revoked { get; set; }
        public int visibility { get; set; }
        public bool friend_sync { get; set; }
        public bool show_activity { get; set; }
        public bool verified { get; set; }
    }

    public class ExternalFriendsList
    {
        public string? user_id { get; set; }
        public string? platform_type { get; set; }
        public string? name { get; set; }
        public string? id_hash { get; set; }
        public List<string>? friend_id_hashes { get; set; }
    }

    public class MfaSession
    {
        public string? user_id { get; set; }
        public int started { get; set; }
        public string? ip { get; set; }
        public string? e { get; set; }
        public string?  id { get; set; }
    }

    public class User
    {
        public string? username { get; set; }
        public string? avatar { get; set; }
        public string? discriminator { get; set; }
        public int public_flags { get; set; }
        public bool? bot { get; set; }
    }

    public class Relationship
    {
        public string? id { get; set; }
        public int type { get; set; }
        public object? nickname { get; set; }
        public User? user { get; set; }
    }

    public class Item
    {
        public string? id { get; set; }
        public string? plan_id { get; set; }
        public int quantity { get; set; }
    }

    public class Subscription
    {
        public string? id { get; set; }
        public int type { get; set; }
        public DateTime current_period_start { get; set; }
        public DateTime current_period_end { get; set; }
        public object? payment_gateway { get; set; }
        public string? payment_gateway_plan_id { get; set; }
        public string? currency { get; set; }
        public string? plan_id { get; set; }
        public List<Item>? items { get; set; }
    }

    public class BillingAddress
    {
        public string? name { get; set; }
        public string? line_1 { get; set; }
        public object? line_2 { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }
        public string? postal_code { get; set; }
    }

    public class PaymentSource
    {
        public string? id { get; set; }
        public int type { get; set; }
        public bool invalid { get; set; }
        public string? email { get; set; }
        public BillingAddress? billing_address { get; set; }
        public string? country { get; set; }
    }

    public class Payment
    {
        public string? id { get; set; }
        public DateTime created_at { get; set; }
        public string? currency { get; set; }
        public int tax { get; set; }
        public bool tax_inclusive { get; set; }
        public int amount { get; set; }
        public int amount_refunded { get; set; }
        public int status { get; set; }
        public string? description { get; set; }
        public int flags { get; set; }
        public Subscription? subscription { get; set; }
        public PaymentSource? payment_source { get; set; }
        public string? sku_id { get; set; }
        public int sku_price { get; set; }
        public string? sku_subscription_plan_id { get; set; }
    }

    public class PaymentSource2
    {
        public string? id { get; set; }
        public int type { get; set; }
        public bool invalid { get; set; }
        public string? email { get; set; }
        public BillingAddress? billing_address { get; set; }
        public string? country { get; set; }
    }

    public class MuteConfig
    {
        public DateTime? end_time { get; set; }
        public object? selected_time_window { get; set; }
    }

    public class ChannelOverride
    {
        public string? channel_id { get; set; }
        public int message_notifications { get; set; }
        public bool muted { get; set; }
        public MuteConfig? mute_config { get; set; }
        public bool collapsed { get; set; }
    }

    public class GuildSetting
    {
        public string? guild_id { get; set; }
        public bool suppress_everyone { get; set; }
        public bool suppress_roles { get; set; }
        public int message_notifications { get; set; }
        public bool mobile_push { get; set; }
        public bool muted { get; set; }
        public MuteConfig? mute_config { get; set; }
        public bool hide_muted_channels { get; set; }
        public List<ChannelOverride>? channel_overrides { get; set; }
        public int version { get; set; }
    }

    public class ThirdPartySku
    {
        public string? id { get; set; }
        public string? sku { get; set; }
        public string? distributor { get; set; }
    }

    public class Executable
    {
        public string? os { get; set; }
        public string? name { get; set; }
    }

    public class Publisher
    {
        public string? id { get; set; }
        public string? name { get; set; }
    }

    public class Developer
    {
        public string? id { get; set; }
        public string? name { get; set; }
    }

    public class Application
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? icon { get; set; }
        public string? description { get; set; }
        public string? summary { get; set; }
        public string? cover_image { get; set; }
        public string? splash { get; set; }
        public string? primary_sku_id { get; set; }
        public List<ThirdPartySku>? third_party_skus { get; set; }
        public bool hook { get; set; }
        public string? slug { get; set; }
        public string? guild_id { get; set; }
        public List<Executable>? executables { get; set; }
        public bool bot_public { get; set; }
        public bool bot_require_code_grant { get; set; }
        public string? verify_key { get; set; }
        public List<Publisher>? publishers { get; set; }
        public List<Developer>? developers { get; set; }
        public bool? overlay { get; set; }
        public List<string>? aliases { get; set; }
    }

    public class Sku
    {
        public string? id { get; set; }
        public int type { get; set; }
        public bool premium { get; set; }
        public object? preorder_release_at { get; set; }
        public object? preorder_approximate_release_date { get; set; }
    }

    public class Entitlement
    {
        public string? id { get; set; }
        public string? sku_id { get; set; }
        public string? application_id { get; set; }
        public string? user_id { get; set; }
        public int type { get; set; }
        public bool deleted { get; set; }
        public int gift_code_flags { get; set; }
        public bool consumed { get; set; }
        public string? gifter_user_id { get; set; }
        public SubscriptionPlan? subscription_plan { get; set; }
        public string? sku_name { get; set; }
    }

    public class LibraryApplication
    {
        public Application? application { get; set; }
        public string? branch_id { get; set; }
        public string? sku_id { get; set; }
        public Sku? sku { get; set; }
        public int flags { get; set; }
        public DateTime created_at { get; set; }
        public List<Entitlement>? entitlements { get; set; }
    }

    public class SubscriptionPlan
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public int interval { get; set; }
        public int interval_count { get; set; }
        public bool tax_inclusive { get; set; }
        public string? sku_id { get; set; }
    }

    public class UserActivityApplicationStatistic
    {
        public string? application_id { get; set; }
        public DateTime last_played_at { get; set; }
        public int total_duration { get; set; }
        public int total_discord_sku_duration { get; set; }
    }

    public class Notes
    {
        public string? _202630299824291840 { get; set; }
        public string? _229775416779341824 { get; set; }
    }

    public class Account
    {
        public string? id { get; set; }
        public string? username { get; set; }
        public int discriminator { get; set; }
        public string? email { get; set; }
        public bool verified { get; set; }
        public string? avatar_hash { get; set; }
        public bool has_mobile { get; set; }
        public bool needs_email_verification { get; set; }
        public object? premium_until { get; set; }
        public long flags { get; set; }
        public string? phone { get; set; }
        public object? temp_banned_until { get; set; }
        public string? ip { get; set; }
        public Settings? settings { get; set; }
        public List<Connection>? connections { get; set; }
        public List<ExternalFriendsList>? external_friends_lists { get; set; }
        public List<object>? friend_suggestions { get; set; }
        public List<MfaSession>? mfa_sessions { get; set; }
        public List<Relationship>? relationships { get; set; }
        public List<Payment>? payments { get; set; }
        public List<PaymentSource>? payment_sources { get; set; }
        public List<GuildSetting>? guild_settings { get; set; }
        public List<LibraryApplication>? library_applications { get; set; }
        public List<Entitlement>? entitlements { get; set; }
        public List<UserActivityApplicationStatistic>? user_activity_application_statistics { get; set; }
        public Notes? notes { get; set; }
    }

}
