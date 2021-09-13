using Newtonsoft.Json;
using System;

namespace Notes.Models
{
    #region RaiderIo


    public class GuildNormal
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class GuildHeroic
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class GuildMythic
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class GuildCastleNathria
    {
        public GuildNormal normal { get; set; }
        public GuildHeroic heroic { get; set; }
        public GuildMythic mythic { get; set; }
        public string summary { get; set; }
        public int total_bosses { get; set; }
        public int normal_bosses_killed { get; set; }
        public int heroic_bosses_killed { get; set; }
        public int mythic_bosses_killed { get; set; }
    }

    public class GuildSanctumOfDomination
    {
        public GuildNormal normal { get; set; }
        public GuildHeroic heroic { get; set; }
        public GuildMythic mythic { get; set; }
        public string summary { get; set; }
        public int total_bosses { get; set; }
        public int normal_bosses_killed { get; set; }
        public int heroic_bosses_killed { get; set; }
        public int mythic_bosses_killed { get; set; }
    }

    public class GuildRaidRankings
    {
        [JsonProperty("castle-nathria")]
        public GuildCastleNathria CastleNathria { get; set; }

        [JsonProperty("sanctum-of-domination")]
        public GuildSanctumOfDomination SanctumOfDomination { get; set; }
    }

    public class GuildRaidProgression
    {
        [JsonProperty("castle-nathria")]
        public GuildCastleNathria CastleNathria { get; set; }

        [JsonProperty("sanctum-of-domination")]
        public GuildSanctumOfDomination SanctumOfDomination { get; set; }
    }

    public class GuildRaiderIO
    {
        public string name { get; set; }
        public string faction { get; set; }
        public string region { get; set; }
        public string realm { get; set; }
        public DateTime last_crawled_at { get; set; }
        public string profile_url { get; set; }
        public GuildRaidRankings raid_rankings { get; set; }
        public GuildRaidProgression raid_progression { get; set; }
    }
    #endregion
}
