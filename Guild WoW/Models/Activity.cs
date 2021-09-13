
using System.Collections.Generic;

namespace Notes.Models
{
    class Activity
    {

        public string Name { get; set; }
        public string Mode { get; set; }
        public string Time { get; set; }
    }

    public class ActivityAllSelf
    {
        public string href { get; set; }
    }

    public class ActivityAllLinks
    {
        public ActivityAllSelf self { get; set; }
    }

    public class ActivityAllKey
    {
        public string href { get; set; }
    }

    public class ActivityAllRealm
    {
        public ActivityAllKey key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
    }

    public class ActivityAllFaction
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class ActivityAllGuild
    {
        public ActivityAllKey key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public ActivityAllRealm realm { get; set; }
        public ActivityAllFaction faction { get; set; }
    }

    public class ActivityAllEncounter
    {
        public ActivityAllKey_encou key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }
    public class ActivityAllKey_encou
    {
        public string href { get; set; }
    }
    public class ActivityAllMode
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class ActivityAllEncounterCompleted
    {
        public ActivityAllEncounter encounter { get; set; }
        public ActivityAllMode mode { get; set; }
    }

    public class ActivityAllActivity2
    {
        public string type { get; set; }
    }

    public class ActivityAllKey_charakter
    {
        public string href { get; set; }
    }
    public class ActivityAllCharacter
    {
        public ActivityAllKey_charakter key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public ActivityAllRealm_char realm { get; set; }
    }
    public class ActivityAllRealm_char
    {
        public ActivityAllKey_realm_achiv key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
    }
    public class ActivityAllKey_realm_achiv
    {
        public string href { get; set; }
    }
    public class ActivityAllKey_achiv
    {
        public string href { get; set; }
    }
    public class ActivityAllAchievement
    {
        public ActivityAllKey_achiv key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class ActivityAllCharacterAchievement
    {
        public ActivityAllCharacter character { get; set; }
        public ActivityAllAchievement achievement { get; set; }
    }

    public class ActivityAllActivity
    {
        public ActivityAllEncounterCompleted encounter_completed { get; set; }
        public ActivityAllActivity2 activity { get; set; }
        public string timestamp { get; set; }
        public ActivityAllCharacterAchievement character_achievement { get; set; }
    }

    public class ActivityAll
    {
        public ActivityAllLinks _links { get; set; }
        public ActivityAllGuild guild { get; set; }
        public List<ActivityAllActivity> activities { get; set; }
    }



}
