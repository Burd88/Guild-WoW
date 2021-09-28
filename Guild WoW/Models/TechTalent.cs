using System.Collections.Generic;

namespace Notes.Models
{
    public class SelfTT
    {
        public string href { get; set; }
    }

    public class LinksTT
    {
        public SelfTT self { get; set; }
    }

    public class KeyTT
    {
        public string href { get; set; }
    }

    public class TalentTreeTT
    {
        public KeyTT key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class SpellTT
    {
        public KeyTT key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class SpellTooltipTT
    {
        public SpellTT spell { get; set; }
        public string description { get; set; }
        public string cast_time { get; set; }
    }

    public class PrerequisiteTalentTT
    {
        public KeyTT key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class MediaTT
    {
        public KeyTT key { get; set; }
        public int id { get; set; }
    }

    public class TechTalent
    {
        public LinksTT _links { get; set; }
        public int id { get; set; }
        public TalentTreeTT talent_tree { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public SpellTooltipTT spell_tooltip { get; set; }
        public int tier { get; set; }
        public int display_order { get; set; }
        public PrerequisiteTalentTT prerequisite_talent { get; set; }
        public MediaTT media { get; set; }
    }

    public class SelfTTMedia
    {
        public string href { get; set; }
    }

    public class LinksTTMedia
    {
        public SelfTTMedia self { get; set; }
    }

    public class AssetTTMedia
    {
        public string key { get; set; }
        public string value { get; set; }
        public int file_data_id { get; set; }
    }

    public class TechTalentMedia
    {
        public LinksTTMedia _links { get; set; }
        public List<AssetTTMedia> assets { get; set; }
    }


}
