using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Models
{
    public class SelfSoulbinds
    {
        public string href { get; set; }
    }

    public class LinksSoulbinds
    {
        public SelfSoulbinds self { get; set; }
    }

    public class KeySoulbinds
    {
        public string href { get; set; }
    }

    public class RealmSoulbinds
    {
        public KeySoulbinds key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
    }

    public class CharacterSoulbinds
    {
        public KeySoulbinds key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public RealmSoulbinds realm { get; set; }
    }

    public class ChosenCovenantSoulbinds
    {
        public KeySoulbinds key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Soulbind2Soulbinds
    {
        public KeySoulbinds key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Trait2Soulbinds
    {
        public KeySoulbinds key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class TypeSoulbinds
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class ConduitSoulbinds
    {
        public KeySoulbinds key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class SocketSoulbinds
    {
        public ConduitSoulbinds conduit { get; set; }
        public int rank { get; set; }
    }

    public class ConduitSocketSoulbinds
    {
        public TypeSoulbinds type { get; set; }
        public SocketSoulbinds socket { get; set; }
    }

    public class TraitSoulbinds
    {
        public Trait2Soulbinds trait { get; set; }
        public int tier { get; set; }
        public int display_order { get; set; }
        public ConduitSocketSoulbinds conduit_socket { get; set; }
    }

    public class SoulbindSoulbinds
    {
        public Soulbind2Soulbinds soulbind { get; set; }
        public List<TraitSoulbinds> traits { get; set; }
        public bool? is_active { get; set; }
    }

    public class CharacterSoulbindsAll
    {
        public LinksSoulbinds _links { get; set; }
        public CharacterSoulbinds character { get; set; }
        public ChosenCovenantSoulbinds chosen_covenant { get; set; }
        public int renown_level { get; set; }
        public List<SoulbindSoulbinds> soulbinds { get; set; }
    }

  
}
