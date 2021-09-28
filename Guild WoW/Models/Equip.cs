using System.Collections.Generic;
using Xamarin.Forms;

namespace Notes.Models
{
    class Equip
    {
        public ImageSource charMedia { get; set; }
        public ImageSource head { get; set; }
        public ImageSource hands { get; set; }


        public ImageSource neck { get; set; }
        public ImageSource waist { get; set; }


        public ImageSource shoulders { get; set; }
        public ImageSource legs { get; set; }

        public ImageSource back { get; set; }
        public ImageSource feet { get; set; }

        public ImageSource chest { get; set; }
        public ImageSource finger1 { get; set; }

        public ImageSource shirt { get; set; }
        public ImageSource finger2 { get; set; }

        public ImageSource tabard { get; set; }
        public ImageSource trinket1 { get; set; }


        public ImageSource wrist { get; set; }
        public ImageSource trinket2 { get; set; }


        public ImageSource main_hand { get; set; }
        public ImageSource off_hands { get; set; }
        public Color headRGBLVL { get; set; }
        public Color handsRGBLVL { get; set; }


        public Color neckRGBLVL { get; set; }
        public Color waistRGBLVL { get; set; }


        public Color shouldersRGBLVL { get; set; }
        public Color legsRGBLVL { get; set; }

        public Color backRGBLVL { get; set; }
        public Color feetRGBLVL { get; set; }

        public Color chestRGBLVL { get; set; }
        public Color finger1RGBLVL { get; set; }

        public Color shirtRGBLVL { get; set; }
        public Color finger2RGBLVL { get; set; }

        public Color tabardRGBLVL { get; set; }
        public Color trinket1RGBLVL { get; set; }


        public Color wristRGBLVL { get; set; }
        public Color trinket2RGBLVL { get; set; }


        public Color main_handRGBLVL { get; set; }
        public Color off_handsRGBLVL { get; set; }
        public string headLVL { get; set; }
        public string handsLVL { get; set; }


        public string neckLVL { get; set; }
        public string waistLVL { get; set; }


        public string shouldersLVL { get; set; }
        public string legsLVL { get; set; }

        public string backLVL { get; set; }
        public string feetLVL { get; set; }

        public string chestLVL { get; set; }
        public string finger1LVL { get; set; }

        public string shirtLVL { get; set; }
        public string finger2LVL { get; set; }

        public string tabardLVL { get; set; }
        public string trinket1LVL { get; set; }


        public string wristLVL { get; set; }
        public string trinket2LVL { get; set; }


        public string main_handLVL { get; set; }
        public string off_handsLVL { get; set; }
    }
    public class Equip_character_Self
    {
        public string href { get; set; }
    }

    public class Equip_character_Links
    {
        public Equip_character_Self self { get; set; }
    }

    public class Equip_character_Key
    {
        public string href { get; set; }
    }

    public class Equip_character_Realm
    {
        public Equip_character_Key key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
    }

    public class Equip_character_Character
    {
        public Equip_character_Key key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public Realm realm { get; set; }
    }

    public class Equip_character_Item
    {
        public Equip_character_Key key { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Equip_character_Slot
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Equip_character_Quality
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Equip_character_Media
    {
        public Equip_character_Key key { get; set; }
        public int id { get; set; }
    }

    public class Equip_character_ItemClass
    {
        public Equip_character_Key key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Equip_character_ItemSubclass
    {
        public Equip_character_Key key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Equip_character_InventoryType
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Equip_character_Binding
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Equip_character_Color
    {
        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }
        public string a { get; set; }
    }
    public class Equip_character_Displey_Color
    {
        public string r { get; set; }
        public string g { get; set; }
        public string b { get; set; }
        public string a { get; set; }
    }
    public class Equip_character_Display
    {
        public string display_string { get; set; }
        public Equip_character_Displey_Color color { get; set; }
    }

    public class Equip_character_Armor
    {
        public int value { get; set; }
        public Equip_character_Display display { get; set; }
    }

    public class Equip_character_Type
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Equip_character_Stat
    {
        public Equip_character_Type type { get; set; }
        public int value { get; set; }
        public Equip_character_Display display { get; set; }
        public bool? is_negated { get; set; }
        public bool? is_equip_bonus { get; set; }
    }

    public class Equip_character_DisplayStrings
    {
        public string header { get; set; }
        public string gold { get; set; }
        public string silver { get; set; }
        public string copper { get; set; }
    }

    public class Equip_character_SellPrice
    {
        public int value { get; set; }
        public Equip_character_DisplayStrings display_strings { get; set; }
    }

    public class Equip_character_Level
    {
        public int value { get; set; }
        public string display_string { get; set; }
    }

    public class Equip_character_Requirements
    {
        public Equip_character_Level level { get; set; }
    }

    public class Equip_character_Transmog
    {
        public Equip_character_Item item { get; set; }
        public string display_string { get; set; }
        public int item_modified_appearance_id { get; set; }
    }

    public class Equip_character_Durability
    {
        public int value { get; set; }
        public string display_string { get; set; }
    }

    public class Equip_character_NameDescription
    {
        public string display_string { get; set; }
        public Equip_character_Color color { get; set; }
    }

    public class Equip_character_Spell2
    {
        public Equip_character_Key key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Equip_character_Spell
    {
        public Equip_character_Spell2 spell { get; set; }
        public string description { get; set; }
    }

    public class Equip_character_SourceItem
    {
        public Equip_character_Key key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Equip_character_EnchantmentSlot
    {
        public int id { get; set; }
        public string type { get; set; }
    }

    public class Equip_character_Enchantment
    {
        public string display_string { get; set; }
        public Equip_character_SourceItem source_item { get; set; }
        public int enchantment_id { get; set; }
        public Equip_character_EnchantmentSlot enchantment_slot { get; set; }
    }

    public class Equip_character_DamageClass
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Equip_character_Damage
    {
        public int min_value { get; set; }
        public int max_value { get; set; }
        public string display_string { get; set; }
        public Equip_character_DamageClass damage_class { get; set; }
    }

    public class Equip_character_AttackSpeed
    {
        public int value { get; set; }
        public string display_string { get; set; }
    }

    public class Equip_character_Dps
    {
        public double value { get; set; }
        public string display_string { get; set; }
    }

    public class Equip_character_Weapon
    {
        public Equip_character_Damage damage { get; set; }
        public Equip_character_AttackSpeed attack_speed { get; set; }
        public Equip_character_Dps dps { get; set; }
    }

    public class Equip_character_EquippedItem
    {
        public Equip_character_Item item { get; set; }
        public Equip_character_Slot slot { get; set; }
        public int quantity { get; set; }
        public int context { get; set; }
        public List<int> bonus_list { get; set; }
        public Equip_character_Quality quality { get; set; }
        public string name { get; set; }
        public int modified_appearance_id { get; set; }
        public Equip_character_Media media { get; set; }
        public Equip_character_ItemClass item_class { get; set; }
        public Equip_character_ItemSubclass item_subclass { get; set; }
        public Equip_character_InventoryType inventory_type { get; set; }
        public Equip_character_Binding binding { get; set; }
        public Equip_character_Armor armor { get; set; }
        public List<Equip_character_Stat> stats { get; set; }
        public Equip_character_SellPrice sell_price { get; set; }
        public Equip_character_Requirements requirements { get; set; }
        public Equip_character_Level level { get; set; }
        public Equip_character_Transmog transmog { get; set; }
        public Equip_character_Durability durability { get; set; }
        public Equip_character_NameDescription name_description { get; set; }
        public List<Equip_character_Spell> spells { get; set; }
        public string description { get; set; }
        public bool? is_subclass_hidden { get; set; }
        public string limit_category { get; set; }
        public List<Equip_character_Enchantment> enchantments { get; set; }
        public string unique_equipped { get; set; }
        public Equip_character_Weapon weapon { get; set; }
    }

    public class Equip_character_Root
    {
        public Equip_character_Links _links { get; set; }
        public Equip_character_Character character { get; set; }
        public List<Equip_character_EquippedItem> equipped_items { get; set; }
    }

    public class SelfEquipChar
    {
        public string href { get; set; }
    }

    public class LinksEquipChar
    {
        public SelfEquipChar self { get; set; }
    }

    public class QualityEquipChar
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class KeyEquipChar
    {
        public string href { get; set; }
    }

    public class MediaEquipChar
    {
        public KeyEquipChar key { get; set; }
        public int id { get; set; }
    }

    public class ItemClassEquipChar
    {
        public KeyEquipChar key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class ItemSubclassEquipChar
    {
        public KeyEquipChar key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class InventoryTypeEquipChar
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class ItemEquipChar
    {
        public KeyEquipChar key { get; set; }
        public int id { get; set; }
    }

    public class BindingEquipChar
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class ColorEquipChar
    {
        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }
        public double a { get; set; }
    }

    public class DisplayEquipChar
    {
        public string display_string { get; set; }
        public ColorEquipChar color { get; set; }
    }

    public class ArmorEquipChar
    {
        public int value { get; set; }
        public DisplayEquipChar display { get; set; }
    }

    public class TypeEquipChar
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class StatEquipChar
    {
        public TypeEquipChar type { get; set; }
        public int value { get; set; }
        public DisplayEquipChar display { get; set; }
        public bool? is_negated { get; set; }
        public bool? is_equip_bonus { get; set; }
    }

    public class DisplayStringsEquipChar
    {
        public string header { get; set; }
        public string gold { get; set; }
        public string silver { get; set; }
        public string copper { get; set; }
    }

    public class SellPriceEquipChar
    {
        public int value { get; set; }
        public DisplayStringsEquipChar display_strings { get; set; }
    }

    public class LevelEquipChar
    {
        public int value { get; set; }
        public string display_string { get; set; }
    }

    public class RequirementsEquipChar
    {
        public LevelEquipChar level { get; set; }
    }

    public class DurabilityEquipChar
    {
        public int value { get; set; }
        public string display_string { get; set; }
    }

    public class PreviewItemEquipChar
    {
        public ItemEquipChar item { get; set; }
        public QualityEquipChar quality { get; set; }
        public string name { get; set; }
        public MediaEquipChar media { get; set; }
        public ItemClassEquipChar item_class { get; set; }
        public ItemSubclassEquipChar item_subclass { get; set; }
        public InventoryTypeEquipChar inventory_type { get; set; }
        public BindingEquipChar binding { get; set; }
        public ArmorEquipChar armor { get; set; }
        public List<StatEquipChar> stats { get; set; }
        public SellPriceEquipChar sell_price { get; set; }
        public RequirementsEquipChar requirements { get; set; }
        public LevelEquipChar level { get; set; }
        public DurabilityEquipChar durability { get; set; }
    }

    public class GetItemEquipChar
    {
        public LinksEquipChar _links { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public QualityEquipChar quality { get; set; }
        public int level { get; set; }
        public int required_level { get; set; }
        public MediaEquipChar media { get; set; }
        public ItemClassEquipChar item_class { get; set; }
        public ItemSubclassEquipChar item_subclass { get; set; }
        public InventoryTypeEquipChar inventory_type { get; set; }
        public int purchase_price { get; set; }
        public int sell_price { get; set; }
        public int max_count { get; set; }
        public bool is_equippable { get; set; }
        public bool is_stackable { get; set; }
        public PreviewItemEquipChar preview_item { get; set; }
        public int purchase_quantity { get; set; }
    }

    public class SelfEquipMedia
    {
        public string href { get; set; }
    }

    public class LinksEquipMedia
    {
        public SelfEquipMedia self { get; set; }
    }

    public class AssetEquipMedia
    {
        public string key { get; set; }
        public string value { get; set; }
        public int file_data_id { get; set; }
    }

    public class GetItemEquipMedia
    {
        public LinksEquipMedia _links { get; set; }
        public List<AssetEquipMedia> assets { get; set; }
        public int id { get; set; }
    }
    #region Char Media
    public class SelfCM
    {
        public string href { get; set; }
    }

    public class LinksCM
    {
        public SelfCM self { get; set; }
    }

    public class KeyCM
    {
        public string href { get; set; }
    }

    public class RealmCM
    {
        public KeyCM key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
    }

    public class CharacterCM
    {
        public KeyCM key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public RealmCM realm { get; set; }
    }

    public class AssetCM
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class CharMedia
    {
        public LinksCM _links { get; set; }
        public CharacterCM character { get; set; }
        public List<AssetCM> assets { get; set; }
    }
    #endregion
}
