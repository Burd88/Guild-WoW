using System.Collections.Generic;

namespace Notes.Models
{

    public class SelfItem
    {
        public string href { get; set; }
    }

    public class LinksItem
    {
        public SelfItem self { get; set; }
    }

    public class QualityItem
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class KeyItem
    {
        public string href { get; set; }
    }

    public class MediaItem
    {
        public KeyItem key { get; set; }
        public int id { get; set; }
    }

    public class ItemClassItem
    {
        public KeyItem key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class ItemSubclassItem
    {
        public KeyItem key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class InventoryTypeItem
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class ItemItem
    {
        public KeyItem key { get; set; }
        public int id { get; set; }
    }

    public class BindingItem
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Spell2Item
    {
        public KeyItem key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class SpellItem
    {
        public Spell2Item spell { get; set; }
        public string description { get; set; }
    }

    public class LevelItem
    {
        public int value { get; set; }
        public string display_string { get; set; }
    }

    public class PreviewItemItem
    {
        public ItemItem item { get; set; }
        public QualityItem quality { get; set; }
        public string name { get; set; }
        public MediaItem media { get; set; }
        public ItemClassItem item_class { get; set; }
        public ItemSubclassItem item_subclass { get; set; }
        public InventoryTypeItem inventory_type { get; set; }
        public BindingItem binding { get; set; }
        public List<SpellItem> spells { get; set; }
        public LevelItem level { get; set; }
        public bool is_subclass_hidden { get; set; }
    }

    public class GetItem
    {
        public LinksItem _links { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public QualityItem quality { get; set; }
        public int level { get; set; }
        public int required_level { get; set; }
        public MediaItem media { get; set; }
        public ItemClassItem item_class { get; set; }
        public ItemSubclassItem item_subclass { get; set; }
        public InventoryTypeItem inventory_type { get; set; }
        public int purchase_price { get; set; }
        public int sell_price { get; set; }
        public int max_count { get; set; }
        public bool is_equippable { get; set; }
        public bool is_stackable { get; set; }
        public PreviewItemItem preview_item { get; set; }
        public int purchase_quantity { get; set; }
    }

    public class SelfItemMedia
    {
        public string href { get; set; }
    }

    public class LinksItemMedia
    {
        public SelfItemMedia self { get; set; }
    }

    public class AssetItemMedia
    {
        public string key { get; set; }
        public string value { get; set; }
        public int file_data_id { get; set; }
    }

    public class ItemMedia
    {
        public LinksItemMedia _links { get; set; }
        public List<AssetItemMedia> assets { get; set; }
    }




}
