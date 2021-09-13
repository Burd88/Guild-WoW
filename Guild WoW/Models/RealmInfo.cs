using System.Collections.Generic;

namespace Notes.Models
{
    public class RealmInfoSelf
    {
        public string href { get; set; }
    }

    public class RealmInfoLinks
    {
        public RealmInfoSelf self { get; set; }
    }

    public class RealmInfoStatus
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class RealmInfoPopulation
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class RealmInfoKey
    {
        public string href { get; set; }
    }

    public class RealmInfoRegion
    {
        public RealmInfoKey key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class RealmInfoConnectedRealm
    {
        public string href { get; set; }
    }

    public class RealmInfoType
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class RealmInfoRealm
    {
        public int id { get; set; }
        public RealmInfoRegion region { get; set; }
        public RealmInfoConnectedRealm connected_realm { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string locale { get; set; }
        public string timezone { get; set; }
        public RealmInfoType type { get; set; }
        public bool is_tournament { get; set; }
        public string slug { get; set; }
    }

    public class RealmInfoMythicLeaderboards
    {
        public string href { get; set; }
    }

    public class RealmInfoAuctions
    {
        public string href { get; set; }
    }

    public class RealmInfo
    {
        public RealmInfoLinks _links { get; set; }
        public int id { get; set; }
        public bool has_queue { get; set; }
        public RealmInfoStatus status { get; set; }
        public RealmInfoPopulation population { get; set; }
        public List<RealmInfoRealm> realms { get; set; }
        public RealmInfoMythicLeaderboards mythic_leaderboards { get; set; }
        public RealmInfoAuctions auctions { get; set; }
    }
}
