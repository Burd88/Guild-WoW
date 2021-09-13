using SQLite;
using System.Collections.Generic;
namespace Notes.Models
{
    public class Guild
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Region { get; set; }
        public string Realm { get; set; }
        public string GuildName { get; set; }
        public string Local { get; set; }
        public string RealmSlug { get; set; }
        public string GuildSlug { get; set; }
        public string LocalSlug { get; set; }

    }


    public class GuildRosterMain
    {

        public int Level { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Name { get; set; }

    }
    #region Guild Members Info
    public class Self_guild
    {
        public string href { get; set; }
    }

    public class Links_guild
    {
        public Self_guild self { get; set; }
    }

    public class Key_guild
    {
        public string href { get; set; }
    }

    public class Realm_guild
    {
        public Key_guild key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
    }

    public class Faction_guild
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Guild_guild
    {
        public Key_guild key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public Realm_guild realm { get; set; }
        public Faction_guild faction { get; set; }
    }

    public class PlayableClass_guild
    {
        public Key_guild key { get; set; }
        public int id { get; set; }
    }

    public class PlayableRace_guild
    {
        public Key_guild key { get; set; }
        public int id { get; set; }
    }

    public class Character_guild
    {
        public Key_guild key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public Realm_guild realm { get; set; }
        public int level { get; set; }
        public PlayableClass_guild playable_class { get; set; }
        public PlayableRace_guild playable_race { get; set; }
    }

    public class Member_guild
    {
        public Character_guild character { get; set; }
        public int rank { get; set; }
    }

    public class MainGuild
    {
        public Links_guild _links { get; set; }
        public Guild_guild guild { get; set; }
        public List<Member_guild> members { get; set; }
    }
    #endregion



    #region Main Guild Info
    public class GuildMainSelf
    {
        public string href { get; set; }
    }

    public class GuildMainLinks
    {
        public GuildMainSelf self { get; set; }
    }

    public class GuildMainName
    {
        public string en_US { get; set; }
        public string es_MX { get; set; }
        public string pt_BR { get; set; }
        public string de_DE { get; set; }
        public string en_GB { get; set; }
        public string es_ES { get; set; }
        public string fr_FR { get; set; }
        public string it_IT { get; set; }
        public string ru_RU { get; set; }
        public string ko_KR { get; set; }
        public string zh_TW { get; set; }
        public string zh_CN { get; set; }
    }

    public class GuildMainFaction
    {
        public string type { get; set; }
        public GuildMainName name { get; set; }
    }

    public class GuildMainKey
    {
        public string href { get; set; }
    }

    public class GuildMainRealm
    {
        public GuildMainKey key { get; set; }
        public GuildMainName name { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
    }

    public class GuildMainMedia
    {
        public GuildMainKey key { get; set; }
        public int id { get; set; }
    }

    public class GuildMainRgba
    {
        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }
        public double a { get; set; }
    }

    public class GuildMainColor
    {
        public int id { get; set; }
        public GuildMainRgba rgba { get; set; }
    }

    public class GuildMainEmblem
    {
        public int id { get; set; }
        public GuildMainMedia media { get; set; }
        public GuildMainColor color { get; set; }
    }

    public class GuildMainBorder
    {
        public int id { get; set; }
        public GuildMainMedia media { get; set; }
        public GuildMainColor color { get; set; }
    }

    public class GuildMainBackground
    {
        public GuildMainColor color { get; set; }
    }

    public class GuildMainCrest
    {
        public GuildMainEmblem emblem { get; set; }
        public GuildMainBorder border { get; set; }
        public GuildMainBackground background { get; set; }
    }

    public class GuildMainRoster
    {
        public string href { get; set; }
    }

    public class GuildMainAchievements
    {
        public string href { get; set; }
    }

    public class GuildMainActivity
    {
        public string href { get; set; }
    }

    public class GuildMain
    {
        public GuildMainLinks _links { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public GuildMainFaction faction { get; set; }
        public int achievement_points { get; set; }
        public int member_count { get; set; }
        public GuildMainRealm realm { get; set; }
        public GuildMainCrest crest { get; set; }
        public GuildMainRoster roster { get; set; }
        public GuildMainAchievements achievements { get; set; }
        public long created_timestamp { get; set; }
        public GuildMainActivity activity { get; set; }
    }

    #endregion
}
