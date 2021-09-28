using System.Collections.Generic;

namespace Notes.Models
{

    public class SelfConduit
    {
        public string href { get; set; }
    }

    public class LinksConduit
    {
        public SelfConduit self { get; set; }
    }

    public class KeyConduit
    {
        public string href { get; set; }
    }

    public class ItemConduit
    {
        public KeyConduit key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class SocketTypeConduit
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class SpellConduit
    {
        public KeyConduit key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class SpellTooltipConduit
    {
        public SpellConduit spell { get; set; }
        public string description { get; set; }
        public string cast_time { get; set; }
    }

    public class RankConduit
    {
        public int id { get; set; }
        public int tier { get; set; }
        public SpellTooltipConduit spell_tooltip { get; set; }
    }

    public class Conduit
    {
        public LinksConduit _links { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public ItemConduit item { get; set; }
        public SocketTypeConduit socket_type { get; set; }
        public List<RankConduit> ranks { get; set; }
    }

}
