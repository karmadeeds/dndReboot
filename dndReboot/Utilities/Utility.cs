using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using dndReboot.Utilities;
using dndReboot.View;
using dndReboot.Model;
using dndReboot.Model.Classes;

namespace dndReboot.Utilities
{

    public static class Utility 
    {

        static Utility()
        {
            
        }

        public static void EnumVisual(Visual myVisual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
                //MessageBox.Show(childVisual.GetType().ToString());
                if (childVisual.GetType() == typeof(AbilityBonusView))
                {
                    
                }
                else if (childVisual.GetType() == typeof(ListBoxItem))
                {
                    (childVisual as ListBoxItem).IsEnabled = true;
                }
                EnumVisual(childVisual);
            }

        }

        public static void AddRaceToDB(string Name, string AbilityBonus, string Size, int Speed, string Darkvision, 
            long WeaponProficiencies, long ToolProficiencies, 
            int Languages, string ParentRace, int SkillProficiencies, 
            int ArmorProficiencies)
        {
            SQLiteConnection sql_con = new SQLiteConnection(@"Data Source=FreeDataBase.sqlite;Version=3;");
            using (sql_con)
            {
                sql_con.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(sql_con))
                {
                    cmd.CommandText = "INSERT INTO Race(Name, AbilityBonus, Size, Speed, Darkvision, WeaponProficiencies, ToolProficiencies, Languages, ParentRace, SkillProficiencies, ArmorProficiencies) VALUES (@Name, @AbilityBonus, @Size, @Speed, @Darkvision, @WeaponProficiencies, @ToolProficiencies, @Languages, @ParentRace, @SkillProficiencies, @ArmorProficiencies)";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@AbilityBonus", AbilityBonus);
                    cmd.Parameters.AddWithValue("@Size", Size);
                    cmd.Parameters.AddWithValue("@Speed", Speed);
                    cmd.Parameters.AddWithValue("@Darkvision", Darkvision);
                    cmd.Parameters.AddWithValue("@WeaponProficiencies", WeaponProficiencies);
                    cmd.Parameters.AddWithValue("@ToolProficiencies", ToolProficiencies);
                    cmd.Parameters.AddWithValue("@Languages", Languages);
                    cmd.Parameters.AddWithValue("@ParentRace", ParentRace);
                    cmd.Parameters.AddWithValue("@SkillProficiencies", SkillProficiencies);
                    cmd.Parameters.AddWithValue("@ArmorProficiencies", ArmorProficiencies);
                    cmd.ExecuteNonQuery();
                }
                sql_con.Close();
            }
        }

        public static void AddRacialTraitToDB(string Race, string Name, string Explanation)
        {
            SQLiteConnection sql_con = new SQLiteConnection(@"Data Source=FreeDataBase.sqlite;Version=3;");
            using (sql_con)
            {
                sql_con.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(sql_con))
                {
                    cmd.CommandText = "INSERT INTO RacialTraits(Race, Name, Explanation) VALUES (@Race, @Name, @Explanation)";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@Race", Race);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Explanation", Explanation);
                    cmd.ExecuteNonQuery();
                }
                sql_con.Close();
            }
        }

        public static string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
        {
            var me = propertyLambda.Body as MemberExpression;
            if (me == null)
            {
                throw new ArgumentNullException(
                    "You must pass a lambda of the form: '() => Class.Property' or '() => object.Property");
            }
            return me.Member.Name;

        }        
        //Expression<Func<T>> () => cc.Strength;
        public static DataGridRow GetRow(DataGrid grid, int index)
        {
            DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            return row;
        }
        public static DataGridRow GetSelectedRow(DataGrid grid)
        {
            return (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem);
        }
        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
        public static DataGridCell GetCell(DataGrid grid, DataGridRow row, int column)
        {
            if (row != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
                if (presenter == null)
                {
                    grid.ScrollIntoView(row, grid.Columns[column]);
                    presenter = GetVisualChild<DataGridCellsPresenter>(row);
                }

                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                return cell;
            }
            return null;
        }

        public static IEnumerable<Enum> GetFlags(Enum input)
        {
            return Enum.GetValues(input.GetType()).Cast<Enum>().Where(input.HasFlag);
        }

        public static IEnumerable<SkillProficiency> GetUniqueFlags(this SkillProficiency flags)
        {
            var flag = 1ul;
            foreach (var value in Enum.GetValues(flags.GetType()).Cast<SkillProficiency>())
            {
                var bits = Convert.ToUInt64(value);
                while (flag < bits)
                {
                    flag <<= 1;
                }

                if (flag == bits && flags.HasFlag(value))
                {
                    yield return value;
                }
            }
        }

        public static IEnumerable<Language> GetUniqueFlags(this Language flags)
        {
            var flag = 1ul;
            foreach (var value in Enum.GetValues(flags.GetType()).Cast<Language>())
            {
                var bits = Convert.ToUInt64(value);
                while (flag < bits)
                {
                    flag <<= 1;
                }

                if (flag == bits && flags.HasFlag(value))
                {
                    yield return value;
                }
            }
        }

        public static IEnumerable<WeaponProficiency> GetUniqueFlags(this WeaponProficiency flags)
        {
            var flag = 1L;
            foreach (var value in Enum.GetValues(flags.GetType()).Cast<WeaponProficiency>())
            {
                var bits = Convert.ToInt64(value); 
                while (flag < bits)
                {
                    flag <<= 1;
                }

                if (flag == bits && flags.HasFlag(value))
                {
                    yield return value;
                }
            }
        }
        public static IEnumerable<ToolProficiency> GetUniqueFlags(this ToolProficiency flags)
        {
            var flag = 1L;
            foreach (var value in Enum.GetValues(flags.GetType()).Cast<ToolProficiency>())
            {
                var bits = Convert.ToInt64(value);
                while (flag < bits)
                {
                    flag <<= 1;
                }

                if (flag == bits && flags.HasFlag(value))
                {
                    yield return value;
                }
            }
        }
        public static IEnumerable<ArmorProficiency> GetUniqueFlags(this ArmorProficiency flags)
        {
            var flag = 1L;
            foreach (var value in Enum.GetValues(flags.GetType()).Cast<ArmorProficiency>())
            {
                var bits = Convert.ToInt64(value);
                while (flag < bits)
                {
                    flag <<= 1;
                }

                if (flag == bits && flags.HasFlag(value))
                {
                    yield return value;
                }
            }
        }



        public static void AbilityBonus(this RaceEnum race, Character c)
        {
            switch (race)
            {
                case RaceEnum.None:
                    break;
                case RaceEnum.HillDwarf:
                    c.Con.Value += 2;
                    c.Wis.Value += 1;
                    break;
                case RaceEnum.MountainDwarf:
                    c.Str.Value += 2;
                    c.Con.Value += 2;
                    break;
                case RaceEnum.HighElf:
                    c.Dex.Value += 2;
                    c.Int.Value += 1;
                    break;
                case RaceEnum.WoodElf:
                    c.Dex.Value += 2;
                    c.Wis.Value += 1;
                    break;
                case RaceEnum.LightfootHalfling:
                    c.Dex.Value += 2;
                    c.Chr.Value += 1;
                    break;
                case RaceEnum.StoutHalfling:
                    c.Dex.Value += 2;
                    c.Con.Value += 1;
                    break;
                case RaceEnum.Human:
                    foreach (Ability vv in c.Abilities)
                    {
                        vv.Value += 1;
                    }
                    break;
            }
        }
        public static void AbilityDeBonus(this RaceEnum race, Character c)
        {
            switch (race)
            {
                case RaceEnum.None:
                    break;
                case RaceEnum.HillDwarf:
                    c.Con.Value -= 2;
                    c.Wis.Value -= 1;
                    break;
                case RaceEnum.MountainDwarf:
                    c.Str.Value -= 2;
                    c.Con.Value -= 2;
                    break;
                case RaceEnum.HighElf:
                    c.Dex.Value -= 2;
                    c.Int.Value -= 1;
                    break;
                case RaceEnum.WoodElf:
                    c.Dex.Value -= 2;
                    c.Wis.Value -= 1;
                    break;
                case RaceEnum.LightfootHalfling:
                    c.Dex.Value -= 2;
                    c.Chr.Value -= 1;
                    break;
                case RaceEnum.StoutHalfling:
                    c.Dex.Value -= 2;
                    c.Con.Value -= 1;
                    break;
                case RaceEnum.Human:
                    foreach (Ability vv in c.Abilities)
                    {
                        vv.Value -= 1;
                    }
                    break;
            }
        }


        public static T ParseEnum<T>(string value)
        {
            return (T) Enum.Parse(typeof (T), value, true);
        }

        //Static Enumlists for binding comboboxes across app
        //public static IEnumerable<ValueDescription> AlignmentList
        //{
        //    get { return EnumHelper.GetAllValuesAndDescriptions<Alignment>(); }
        //}
        //public static IEnumerable<ValueDescription> AbilityList
        //{
        //    get { return EnumHelper.GetAllValuesAndDescriptions<AbilityEnums>(); }
        //}
        //public static IEnumerable<ValueDescription> SizeList
        //{
        //    get { return EnumHelper.GetAllValuesAndDescriptions<Size>(); }
        //}

        //public static List<int> SpeedList = new List<int> {5, 10, 15, 20, 25, 30, 35, 40, 45, 50};
        //public static List<string> DarkvisionList = new List<string> {"None", "30 feet", "60 feet", "120 feet"};

        //public static IEnumerable<ValueDescription> WeaponProficiencyList
        //{
        //    get { return EnumHelper.GetAllValuesAndDescriptions<WeaponProficiency>(); }
        //}
        //public static IEnumerable<ValueDescription> ArmorProficiencyList
        //{
        //    get { return EnumHelper.GetAllValuesAndDescriptions<ArmorProficiency>(); }
        //}
        //public static IEnumerable<ValueDescription> LanguageList
        //{
        //    get { return EnumHelper.GetAllValuesAndDescriptions<Language>(); }
        //}
        //public static IEnumerable<ValueDescription> ToolProficiencyList
        //{
        //    get { return EnumHelper.GetAllValuesAndDescriptions<ToolProficiency>(); }
        //}
        //public static IEnumerable<ValueDescription> SkillProficiencyList
        //{
        //    get { return EnumHelper.GetAllValuesAndDescriptions<SkillProficiency>(); }
        //}

    }

    public enum Size
    {
        [Description("Choose a Size")]
        None,
        [Description("Tiny")]
        Tiny,
        [Description("Small")]
        Small,
        [Description("Medium")]
        Medium,
        [Description("Large")]
        Large,
        [Description("Huge")]
        Huge,
        [Description("Gargantuan")]
        Gargantuan,
    }

    public enum WeaponProperty
    {
        Ammunition,
        Finesse,
        Heavy,
        Light,
        Loading,
        Range,
        Reach,
        Special,
        Thrown,
        TwoHanded,
        Versatile
    }
    public enum DraconicAncestry
    {
        Black,
        Blue,
        Brass,
        Bronze,
        Copper,
        Gold,
        Green,
        Red,
        Silver,
        White
    }
    public enum Dice
    {
        d4,
        d6,
        d8,
        d10,
        d12
    }
    public enum FeatureType
    {
        Active,
        Passive,
        Triggered,
        Other
    }
    public enum CastingTime
    {
        Action,
        BonusAction,
        Reaction,
        Other
    }
    public enum Targets
    {
        Single,
        Multiple,
        Other
    }
    public enum AreaofEffect
    {
        Self,
        Line,
        Cone,
        Cube,
        Sphere,
        Cylinder,
        Friendly,
        Hostile,
        Party,
        Other
    }
    public enum Recovery
    {
        Short,
        Long,
        Daily,
        Other
    }
    public enum Cost
    {
        KiPoints,
        SorceryPoints,
        Rage,
        Spellslot
    }


    [Flags]
    public enum Language
    {
        None,
        AnyOne = 1<<0, // 1
        AnyTwo = 1<<1, // 2
        Common = 1<<2, // 4
        Elvish = 1<<3, // 8
        Dwarvish = 1<<4, // 16
        Giant = 1<<5, // 32
        Gnomish = 1<<6, // 64
        Goblin = 1<<7, // 128
        Halfling = 1<<8, // 256
        Orc = 1<<9, // 512
        Abyssal = 1<<10, // 1024
        Celestial = 1<<11, // 2048
        Draconic = 1<<12, // 4096
        DeepSpeech = 1<<13, // 8192
        Infernal = 1<<14, // 16384
        Primordial = 1<<15, // 32768
        Sylvan = 1<<16, // 65536
        Undercommon = 1<<17, // 131072
        Aarakocra = 1<<18, // 262144
        Auran = 1<<19, // 524288
    }
    [Flags]
    public enum ToolProficiency : long
    {
        None = (long)0,
        AnyOne = (long)1<<0,
        AnyTwo = (long)1<<1,
        
        Alchemist = (long)1<<2,
        Brewer = (long)1<<3,
        Calligrapher = (long)1<<4,
        Carpenter  = (long)1<<5,
        Cartographer = (long)1<<6,
        Cobbler  = (long)1<<7,
        Cook = (long)1<<8,
        Glassblower = (long)1<<9,
        Jewler = (long)1<<10,
        Leatherworker = (long)1<<11,
        Mason = (long)1<<12,
        Painter = (long)1<<13,
        Potter = (long)1<<14,
        Smith = (long)1<<15,
        Tinker = (long)1<<16,
        Weaver = (long)1<<17,
        Woodcarver = (long)1<<18,
        
        Disguise = (long)1<<19,
        Forgery = (long)1<<20,
        
        Dice = (long)1<<21,
        Dragonchess = (long)1<<22,
        PlayingCard = (long)1<<23,
        ThreeDragon = (long)1<<24,
       
        Herbalism = (long)1<<25,
        
        Bagpipes = (long)1<<26,
        Drum = (long)1<<27,
        Dulcimer = (long)1<<28,
        Flute = (long)1<<29,
        Lute = (long)1<<30,
        Lyre = (long)1<<31,
        Horn = (long)1<<32,
        PanFlute = (long)1<<33,
        Shawm = (long)1<<34,
        Viol = (long)1<<35,
        
        Navigator = (long)1<<36,
        Poisoner = (long)1<<37,
        Thieves = (long)1<<38,
        
        LandVehicles = (long)1<<39,
        WaterVehicles = (long)1<<40,
        
        ArtisansTools = Alchemist | Brewer | Calligrapher | Carpenter | Cartographer | Cobbler | Cook | Glassblower | Jewler | Leatherworker | 
            Mason | Painter | Potter | Smith | Tinker | Weaver | Woodcarver,
        GamingSet = Dice | Dragonchess | PlayingCard | ThreeDragon, 
        MusicalInstrument = Bagpipes | Drum | Dulcimer | Flute | Lute | Lyre | Horn | PanFlute | Shawm | Viol,

    }
    [Flags]
    public enum WeaponProficiency : long
    {
        None = 0L,
        //0-1 Types
        Simple = (long)1 << 0,
        Martial = (long)1 << 1,
        //2-12 Simple Melee
        Club = (long)1 << 2,
        Dagger = (long)1 << 3,
        Greatclub = (long)1 << 4,
        Handaxe = (long)1 << 5,
        Javelin = (long)1 << 6,
        [Description("Throwing Hammer")]
        LightHammer = (long)1 << 7,
        Mace = (long)1 << 8,
        Quarterstaff = (long)1 << 9,
        Sickle = (long)1 << 10,
        Spear = (long)1 << 11,
        [Description("Unarmed Strike")]
        UnarmedStrike = (long)1 << 12,
        //13-16 Simple Ranged
        [Description("Light Crossbow")]
        LightCrossbow = (long)1 << 13,
        Dart = (long)1 << 14,
        Shortbow = (long)1 << 15,
        Sling = (long)1 << 16,
        //17-34 Martial Melee
        Battleaxe = (long)1 << 17,
        Flail = (long)1 << 18,
        Glaive = (long)1 << 19,
        Greataxe = (long)1 << 20,
        Greatsword = (long)1 << 21,
        Halberd = (long)1 << 22,
        Lance = (long)1 << 23,
        Longsword = (long)1 << 24,
        Maul = (long)1 << 25,
        Morningstar = (long)1 << 26,
        Pike = (long)1 << 27,
        Rapier = (long)1 << 28,
        Scimitar = (long)1 << 29,
        Shortsword = (long)1 << 30,
        Trident = (long)1 << 31,
        Warpick = (long)1 << 32,
        Warhammer = (long)1 << 33,
        Whip = (long)1 << 34,
        //34-39 Ranged Martial
        Blowgun = (long)1 << 35,
        [Description("Hand Crossbow")]
        HandCrossbow = (long)1 << 36,
        [Description("Heavy Crossbow")]
        HeavyCrossbow = (long)1 << 37,
        Longbow = (long)1 << 38,
        Net = (long)1 << 39,
        Something = Simple | Martial,
    }
    [Flags]
    public enum ArmorProficiency
    {
        None = 0,
        Light = 1<<0,
        Medium = 1<<1,
        Heavy = 1<<2,
        Shield = 1<<3,
    }
    [Flags]
    public enum SkillProficiency
    {
        [Description("None")]
        None = 0,
        [Description("Strength Saving Throw")]
        StrengthST = 1 << 0,
        [Description("Dexterity Saving Throw")]
        DexterityST = 1 << 1,
        [Description("Constitution Saving Throw")]
        ConstitutionST = 1 << 2,
        [Description("Intelligence Saving Throw")]
        IntelligenceST = 1 << 3,
        [Description("Wisdom Saving Throw")]
        WisdomST = 1 << 4,
        [Description("Charisma Saving Throw")]
        CharismaST = 1 << 5,
        [Description("Acrobatics")]
        Acrobatics = 1 << 6,
        [Description("Animal Handling")]
        AnimalHandling = 1 << 7,
        [Description("Arcana")]
        Arcana = 1 << 8,
        [Description("Athletics")]
        Athletics = 1 << 9,
        [Description("Deception")]
        Deception = 1 << 10,
        [Description("History")]
        History = 1 << 11,
        [Description("Insight")]
        Insight = 1 << 12,
        [Description("Intimidation")]
        Intimidation = 1 << 13,
        [Description("Investigation")]
        Investigation = 1 << 14,
        [Description("Medicine")]
        Medicine = 1 << 15,
        [Description("Nature")]
        Nature = 1 << 16,
        [Description("Perception")]
        Perception = 1 << 17,
        [Description("Performance")]
        Performance = 1 << 18,
        [Description("Persuasion")]
        Persuasion = 1 << 19,
        [Description("Religion")]
        Religion = 1 << 20,
        [Description("Sleight of Hand")]
        SleightofHand = 1 << 21,
        [Description("Stealth")]
        Stealth = 1 << 22,
        [Description("Survival")]
        Survival = 1 << 23,
        Strength = StrengthST | Athletics,
        Dexterity = DexterityST | Acrobatics | SleightofHand | Stealth,
        Constitution = ConstitutionST,
        Intelligence = IntelligenceST | Arcana | History | Investigation | Nature | Religion,
        Wisdom = WisdomST | AnimalHandling | Insight | Medicine | Perception | Survival,
        Charisma = CharismaST | Deception | Performance | Persuasion,
    }

    [Flags]
    public enum RaceEnum : ulong
    {
        None = 0,
        [Description("Hill Dwarf")]
        HillDwarf = (ulong)1 << 0, // 1
        [Description("Mountain Dwarf")]
        MountainDwarf = (ulong)1 << 1, // 2
        [Description("High Elf")]
        HighElf = (ulong)1 << 2, // 4
        [Description("Wood Elf")]
        WoodElf = (ulong)1 << 3, // 8
        [Description("Lightfoot Halfling")]
        LightfootHalfling = (ulong)1 << 4, // 16
        [Description("Stout Halfling")]
        StoutHalfling = (ulong)1 << 5, // 32
        Human = (ulong)1 << 6, // 64
        Aarakocra = (ulong)1 << 7, // 128
        Minotaur = (ulong)1 << 8, //256
        [Description("Deep Gnome")]
        DeepGnome = (ulong)1 << 9,
        [Description("Air Genasi")]
        AirGenasi = (ulong)1 << 10,
        [Description("Earth Genasi")]
        EarthGenasi = (ulong)1 << 11,
        [Description("Fire Genasi")]
        FireGenasi = (ulong)1 << 12,
        [Description("Water Genasi")]
        WaterGenasi = (ulong)1 << 13,
        Goliath = (ulong)1 << 14,
        Changling = (ulong)1 << 15,
        [Description("Beasthide Shifter")]
        BeasthideShifter = (ulong)1 << 16,
        [Description("Cliffwalk Shifter")]
        CliffwalkShifter = (ulong)1 << 17,
        [Description("Longstride Shifter")]
        LongstrideShifter = (ulong)1 << 18,
        [Description("Longtooth Shifter")]
        LongtoothShifter = (ulong)1 << 19,
        [Description("Razorclaw Shifter")]
        RazorclawShifter = (ulong)1 << 20,
        [Description("Wildhunt Shifter")]
        WildhuntShifter = (ulong)1<<21,
        Warforged = (ulong)1<<22,
        
    }
    
    
    public enum BardCollege
    {
        //[Description("")]
        //NOT_SET = 0,
        [Description("College of Lore")]
        Lore,
        [Description("College of Valor")]
        Valor
    }
    public enum PrimalPath
    {
        Berserker,
        TotemWarrior
    }
    public enum Domain
    {
        Knowledge,
        Life,
        Light,
        Nature,
        Tempest,
        Trickery,
        War
    }
    public enum Circle
    {
        Land,
        Moon
    }
    public enum FighterArchetype
    {
        Champion,
        Battlemaster,
        EldritchKnight
    }
    public enum MonasticTradition
    {
        OpenHand,
        Shadow,
        Elements
    }
    public enum Oath
    {
        Devotion,
        Ancients,
        Vengeance
    }
    public enum RangerArchetype
    {
        Hunter,
        BeastMaster
    }
    public enum RoguishArchetype
    {
        Thief,
        Assassin,
        Arcane
    }
    public enum SorcerousOrigin
    {
        Draconic,
        Wild
    }
    public enum OtherworldlyPatron
    {
        Archfey,
        Fiend,
        OldOne
    }
    public enum PactBoon
    {
        ChainPact,
        BladePact,
        TomePact
    }
    public enum ArcaneTradition
    {
        Abjuration,
        Conjuration,
        Divination,
        Enchantment,
        Evocation,
        Illusion,
        Necromancy,
        Transmutation
    }
    public enum Archetype
    {
        Berserker,
        TotemWarrior,
        Knowledge,
        Life,
        Light,
        Nature,
        Tempest,
        Trickery,
        War,
        Land,
        Moon,
        Champion,
        Battlemaster,
        EldritchKnight,
        OpenHand,
        Shadow,
        Elements,
        Devotion,
        Ancients,
        Vengeance,
        Hunter,
        BeastMaster,
        Thief,
        Assassin,
        Arcane,
        Draconic,
        Wild,
        Archfey,
        Fiend,
        OldOne,
        ChainPact,
        BladePact,
        TomePact,
        Abjuration,
        Conjuration,
        Divination,
        Enchantment,
        Evocation,
        Illusion,
        Necromancy,
        Transmutation
    }
    public enum Alignment
    {
        [Description("Lawful Good")]
        LawfulGood,
        [Description("Lawful Neutral")]
        LawfulNeutral,
        [Description("Lawful Evil")]
        LawfulEvil,
        [Description("Neutral Good")]
        NeutralGood,
        [Description("Neutral")]
        Neutral,
        [Description("Neutral Evil")]
        NeurtalEvil,
        [Description("Chaotic Good")]
        ChaoticGood,
        [Description("Chaotic Neutral")]
        ChaoticNeutral,
        [Description("Chaotic Evil")]
        ChaoticEvil

    }

    public enum Background
    {
        [Description("Acolyte")]
        Acolyte,
        [Description("Criminal")]
        Criminal,
        [Description("Folk Hero")]
        FolkHero,
        [Description("Sage")]
        Sage,
        [Description("Soldier")]
        Soldier,

    }

    public enum AbilityEnums
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma,
        All,
    }



    public static class EnumHelper
    {
        /// <summary>
        /// Gets the description of a specific enum value.
        /// </summary>
        public static string Description(this Enum eValue)
        {
            var nAttributes = eValue.GetType().GetField(eValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);

            // If no description is found, best guess is to generate it by replacing underscores with spaces
            if (!nAttributes.Any())
            {
                TextInfo oTI = CultureInfo.CurrentCulture.TextInfo;
                return oTI.ToTitleCase(oTI.ToLower(eValue.ToString().Replace("_", " ")));
            }

            return (nAttributes.First() as DescriptionAttribute).Description;
        }

        /// <summary>
        /// Returns an enumerable collection of all values and descriptions for an enum type.
        /// </summary>




        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof (T)).Cast<T>();
        }

        public static IEnumerable<EnumBase> GetAllEnumsOfType<TEnum>()
            where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if(!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an Enumeration type");
            return
                Enum.GetValues(typeof (TEnum))
                    .Cast<Enum>()
                    .Select((e) => new EnumBase() {Value = e, Description = e.Description()})
                    .ToList();
            
        }
       


    }


}
