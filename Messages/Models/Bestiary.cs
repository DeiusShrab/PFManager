﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFManager.Messages.Models
{
  public class Bestiary
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public int Cr { get; set; }
    public int Xp { get; set; }
    public string Race { get; set; }
    public string Class { get; set; }
    public string Alignment { get; set; }
    public string Size { get; set; }
    public string Type_Id { get; set; }
    public List<string> SubTypes { get; set; } = new List<string>();
    public int Init { get; set; }
    public string Senses { get; set; }
    public string Aura { get; set; }
    public int Ac { get; set; }
    public string Acmods { get; set; }
    public int Hp { get; set; }
    public string Hd { get; set; }
    public string Hpmods { get; set; }
    public int Fortitude { get; set; }
    public int Reflex { get; set; }
    public int Will { get; set; }
    public string SaveMods { get; set; }
    public string DefensiveAbilities { get; set; }
    public string Dr { get; set; }
    public string Immune { get; set; }
    public string Resist { get; set; }
    public int Sr { get; set; }
    public string Weaknesses { get; set; }
    public string Speed { get; set; }
    public string SpeedMod { get; set; }
    public string Melee { get; set; }
    public string Ranged { get; set; }
    public string Space { get; set; }
    public string Reach { get; set; }
    public string SpecialAttacks { get; set; }
    public string SpellLikeAbilities { get; set; }
    public string SpellsKnown { get; set; }
    public string SpellsPrepared { get; set; }
    public string SpellDomains { get; set; }
    public string AbilityScores { get; set; }
    public string AbilityScoreMods { get; set; }
    public int BaseAtk { get; set; }
    public int Cmb { get; set; }
    public int Cmd { get; set; }
    public string Feats { get; set; }
    public string Skills { get; set; }
    public string RacialMods { get; set; }
    public string Languages { get; set; }
    public string Sq { get; set; }
    public string Environment { get; set; }
    public string Organization { get; set; }
    public string Treasure { get; set; }
    public string DescriptionVisual { get; set; }
    public string Group { get; set; }
    public bool IsTemplate { get; set; }
    public string SpecialAbilities { get; set; }
    public string Gender { get; set; }
    public string Bloodline { get; set; }
    public string ProhibitedSchools { get; set; }
    public string BeforeCombat { get; set; }
    public string DuringCombat { get; set; }
    public string Morale { get; set; }
    public string Gear { get; set; }
    public string OtherGear { get; set; }
    public string Vulnerability { get; set; }
    public string Note { get; set; }
    public bool CharacterFlag { get; set; }
    public bool CompanionFlag { get; set; }
    public int Fly { get; set; }
    public int Climb { get; set; }
    public int Burrow { get; set; }
    public int Swim { get; set; }
    public int Land { get; set; }
    public string TemplatesApplied { get; set; }
    public string OffenseNote { get; set; }
    public string BaseStatistics { get; set; }
    public string ExtractsPrepared { get; set; }
    public string AgeCategory { get; set; }
    public bool DontUseRacialHd { get; set; }
    public string VariantParent { get; set; }
    public string Mystery { get; set; }
    public string ClassArchetypes { get; set; }
    public string Patron { get; set; }
    public string CompanionFamiliarLink { get; set; }
    public string FocusedSchool { get; set; }
    public string Traits { get; set; }
    public string AlternateNameForm { get; set; }
    public string StatisticsNote { get; set; }
    public string LinkText { get; set; }
    public bool UniqueMonster { get; set; }
    public int Mr { get; set; }
    public bool Mythic { get; set; }
    public int Mt { get; set; }
    public int Actouch { get; set; }
    public int Acflat { get; set; }
    public int Str { get; set; }
    public int Dex { get; set; }
    public int Con { get; set; }
    public int Wis { get; set; }
    public int Int { get; set; }
    public int Cha { get; set; }

    public string BestiaryDetail { get; set; }
    public string BestiaryType { get; set; }
    public List<string> BestiaryEnvironments { get; } = new List<string>();
    public List<string> BestiaryFeats { get; } = new List<string>();
    public List<string> BestiaryLanguages { get; } = new List<string>();
    public List<string> BestiaryMagics { get; } = new List<string>();
    public List<string> BestiarySkills { get; } = new List<string>();
    public List<string> BestiarySubTypes { get; } = new List<string>();
    public List<string> MonsterSpawns { get; } = new List<string>();
    public List<string> BestiaryRaces { get; } = new List<string>();
  }
}
