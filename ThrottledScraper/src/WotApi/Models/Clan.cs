using System;
using System.Text.Json.Serialization;

namespace WotApi.Models
{
    public sealed class Clan
    {
        [JsonPropertyName("members_count")]
        public int MemberCount { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        public string Tag { get; set; }

        [JsonPropertyName("clan_id")]
        public int Id { get; set; }
    }
}
