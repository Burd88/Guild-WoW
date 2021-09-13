using System.Collections.Generic;

namespace Notes.Models
{
    public class Root_RealmSelf
    {
        public string href { get; set; }
    }

    public class Root_RealmLinks
    {
        public Root_RealmSelf self { get; set; }
    }

    public class Root_RealmKey
    {
        public string href { get; set; }
    }

    public class Root_RealmRealm
    {
        public Root_RealmKey key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
    }

    public class Root_Realm
    {
        public Root_RealmLinks _links { get; set; }
        public List<Root_RealmRealm> realms { get; set; }
    }

    public class Realm
    {
        public string Name { get; set; }
        public string Slug { get; set; }
    }




    public class RootRealmlocalSelf
    {
        public string href { get; set; }
    }

    public class RootRealmlocalLinks
    {
        public RootRealmlocalSelf self { get; set; }
    }

    public class RootRealmlocalKey
    {
        public string href { get; set; }
    }

    public class RootRealmlocalRegion
    {
        public RootRealmlocalKey key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class RootRealmlocalConnectedRealm
    {
        public string href { get; set; }
    }

    public class RootRealmlocalType
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class RootRealmlocal
    {
        public RootRealmlocalLinks _links { get; set; }
        public int id { get; set; }
        public RootRealmlocalRegion region { get; set; }
        public RootRealmlocalConnectedRealm connected_realm { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string locale { get; set; }
        public string timezone { get; set; }
        public RootRealmlocalType type { get; set; }
        public bool is_tournament { get; set; }
        public string slug { get; set; }
    }



    public class Allrealm_Key
    {
        public string href { get; set; }
    }

    public class Allrealm_Name
    {
        public string it_IT { get; set; }
        public string ru_RU { get; set; }
        public string en_GB { get; set; }
        public string zh_TW { get; set; }
        public string ko_KR { get; set; }
        public string en_US { get; set; }
        public string es_MX { get; set; }
        public string pt_BR { get; set; }
        public string es_ES { get; set; }
        public string zh_CN { get; set; }
        public string fr_FR { get; set; }
        public string de_DE { get; set; }
    }

    public class Allrealm_Region
    {
        public Allrealm_Name name { get; set; }
        public int id { get; set; }
    }

    public class Allrealm_Category
    {
        public string it_IT { get; set; }
        public string ru_RU { get; set; }
        public string en_GB { get; set; }
        public string zh_TW { get; set; }
        public string ko_KR { get; set; }
        public string en_US { get; set; }
        public string es_MX { get; set; }
        public string pt_BR { get; set; }
        public string es_ES { get; set; }
        public string zh_CN { get; set; }
        public string fr_FR { get; set; }
        public string de_DE { get; set; }
    }

    public class Allrealm_Type
    {
        public Allrealm_Name name { get; set; }
        public string type { get; set; }
    }

    public class Allrealm_Data
    {
        public bool is_tournament { get; set; }
        public string timezone { get; set; }
        public Allrealm_Name name { get; set; }
        public int id { get; set; }
        public Allrealm_Region region { get; set; }
        public Allrealm_Category category { get; set; }
        public string locale { get; set; }
        public Allrealm_Type type { get; set; }
        public string slug { get; set; }
    }

    public class Allrealm_Result
    {
        public Allrealm_Key key { get; set; }
        public Allrealm_Data data { get; set; }
    }

    public class Allrealm_
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int maxPageSize { get; set; }
        public int pageCount { get; set; }
        public List<Allrealm_Result> results { get; set; }
    }



}
