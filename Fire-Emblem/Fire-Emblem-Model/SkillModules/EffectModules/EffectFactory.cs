namespace Fire_Emblem_Model;

public class EffectFactory
{
    private const int _bonus2 = 2;
    private const int _bonus3 = 3;
    private const int _bonus4 = 4;
    private const int _bonus5 = 5;
    private const int _bonus6 = 6;
    private const int _bonus7 = 7;
    private const int _bonus8 = 8;
    private const int _bonus10 = 10;
    private const int _bonus12 = 12;
    private const int _bonus15 = 15;
    private const int _bonus25 = 25;
    private const int _penalty1 = 1;
    private const int _penalty2 = 2;
    private const int _penalty3 = 3;
    private const int _penalty4 = 4;
    private const int _penalty5 = 5;
    private const int _penalty6 = 6;
    private const int _penalty7 = 7;
    private const int _penalty8 = 8;
    private const int _penalty10 = 10;
    private const int _percentageBonus20 = 20;
    private const int _percentageBonus25 = 25;
    private const int _percentageBonus30 = 30;
    private const int _percentageBonus50 = 50;
    private const int _percentagePenalty20 = 20;
    private const int _percentagePenalty30 = 30;
    private const int _percentagePenalty50 = 50;
    private const double _halfStatMultiplier = 0.5;
    private const double _percentageDecimalBonus0_15 = 0.15;
    private const double _percentageDecimalBonus0_3 = 0.3;
    private const double _percentageDecimalPenalty0_5 = 0.5;

    public List<Effect> Create(string skillName, Unit unit)
    {
        EffectsCollection effects = new();

        switch (skillName)
        {
            case "HP +15":
                effects.Append(new HpBonusEffect(StatType.HP, _bonus15));
                break;
            
            case "Attack +6":
            case "Fire Boost":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                break;
            
            case "Will to Win":
            case "Single-Minded":
            case "Death Blow":
                effects.Append(new BonusEffect(StatType.Atk, _bonus8));
                break;
            
            case "Chaos Style":
                effects.Append(new BonusEffect(StatType.Spd, _bonus3));
                break;
            
            case "Speed +5":
                effects.Append(new BonusEffect(StatType.Spd, _bonus5));
                break;

            case "Wind Boost":
                effects.Append(new BonusEffect(StatType.Spd, _bonus6));
                break;

            case "Darting Blow":
                effects.Append(new BonusEffect(StatType.Spd, _bonus8));
                break;

            case "Defense +5":
                effects.Append(new BonusEffect(StatType.Def, _bonus5));
                break;

            case "Earth Boost":
                effects.Append(new BonusEffect(StatType.Def, _bonus6));
                break;

            case "Armored Blow":
                effects.Append(new BonusEffect(StatType.Def, _bonus8));
                break;

            case "Resistance +5":
                effects.Append(new BonusEffect(StatType.Res, _bonus5));
                break;

            case "Water Boost":
                effects.Append(new BonusEffect(StatType.Res, _bonus6));
                break;

            case "Warding Blow":
                effects.Append(new BonusEffect(StatType.Res, _bonus8));
                break;

            case "Tome Precision":
            case "Swift Sparrow":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusEffect(StatType.Spd, _bonus6));
                break;

            case "Deadly Blade":
                effects.Append(new BonusEffect(StatType.Atk, _bonus8));
                effects.Append(new BonusEffect(StatType.Spd, _bonus8));
                break;

            case "Brazen Atk/Spd":
                effects.Append(new BonusEffect(StatType.Atk, _bonus10));
                effects.Append(new BonusEffect(StatType.Spd, _bonus10));
                break;

            case "Atk/Def +5":
                effects.Append(new BonusEffect(StatType.Atk, _bonus5));
                effects.Append(new BonusEffect(StatType.Def, _bonus5));
                break;

            case "Sturdy Blow":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusEffect(StatType.Def, _bonus6));
                break;

            case "Brazen Atk/Def":
                effects.Append(new BonusEffect(StatType.Atk, _bonus10));
                effects.Append(new BonusEffect(StatType.Def, _bonus10));
                break;

            case "Atk/Res +5":
                effects.Append(new BonusEffect(StatType.Atk, _bonus5));
                effects.Append(new BonusEffect(StatType.Res, _bonus5));
                break;

            case "Mirror Strike":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusEffect(StatType.Res, _bonus6));
                break;

            case "Brazen Atk/Res":
                effects.Append(new BonusEffect(StatType.Atk, _bonus10));
                effects.Append(new BonusEffect(StatType.Res, _bonus10));
                break;

            case "Steady Blow":
                effects.Append(new BonusEffect(StatType.Spd, _bonus6));
                effects.Append(new BonusEffect(StatType.Def, _bonus6));
                break;

            case "Brazen Spd/Def":
                effects.Append(new BonusEffect(StatType.Spd, _bonus10));
                effects.Append(new BonusEffect(StatType.Def, _bonus10));
                break;

            case "Spd/Res +5":
                effects.Append(new BonusEffect(StatType.Spd, _bonus5));
                effects.Append(new BonusEffect(StatType.Res, _bonus5));
                break;

            case "Swift Strike":
                effects.Append(new BonusEffect(StatType.Spd, _bonus6));
                effects.Append(new BonusEffect(StatType.Res, _bonus6));
                break;

            case "Brazen Spd/Res":
                effects.Append(new BonusEffect(StatType.Spd, _bonus10));
                effects.Append(new BonusEffect(StatType.Res, _bonus10));
                break;

            case "Bracing Blow":
                effects.Append(new BonusEffect(StatType.Def, _bonus6));
                effects.Append(new BonusEffect(StatType.Res, _bonus6));
                break;

            case "Brazen Def/Res":
                effects.Append(new BonusEffect(StatType.Def, _bonus10));
                effects.Append(new BonusEffect(StatType.Res, _bonus10));
                break;

            case "Resolve":
                effects.Append(new BonusEffect(StatType.Def, _bonus7));
                effects.Append(new BonusEffect(StatType.Res, _bonus7));
                break;
            
            case "Perceptive":
                effects.Append(new PerceptiveEffect(StatType.Spd));
                break;
            
            case "Fair Fight":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusForOpponentEffect(StatType.Atk, _bonus6));
                break;
            
            case "Wrath":
                effects.Append(new WrathEffect(StatType.Atk));
                effects.Append(new WrathEffect(StatType.Spd));
                break;
            
            case "Ignis":
                effects.Append(new IgnisEffect(StatType.Atk));
                break;
            
            case "Not *Quite*":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty4));
                break;

            case "Disarming Sigh":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty8));
                break;

            case "Blinding Flash":
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty4));
                break;

            case "Stunning Smile":
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty8));
                break;

            case "Charmer":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty3));
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty3));
                break;

            case "Belief in Love":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty5));
                effects.Append(new PenaltyEffect(StatType.Def, _penalty5));
                break;

            case "Luna":
                effects.Append(new LunaEffect(StatType.Def));
                effects.Append(new LunaEffect(StatType.Res));
                break;

            case "Beorc's Blessing":
                effects.Append(new BonusNeutralizationEffect(StatType.Atk));
                effects.Append(new BonusNeutralizationEffect(StatType.Spd));
                effects.Append(new BonusNeutralizationEffect(StatType.Def));
                effects.Append(new BonusNeutralizationEffect(StatType.Res));
                break;

            case "Agnea's Arrow":
                effects.Append(new PenaltyNeutralizationEffect(StatType.Atk));
                effects.Append(new PenaltyNeutralizationEffect(StatType.Spd));
                effects.Append(new PenaltyNeutralizationEffect(StatType.Def));
                effects.Append(new PenaltyNeutralizationEffect(StatType.Res));
                break;

            case "Lance Power":
            case "Sword Power":
            case "Axe Power":
                effects.Append(new BonusEffect(StatType.Atk, _bonus10));
                effects.Append(new AgainstPenaltyEffect(StatType.Def, _penalty10));
                break;
            
            case "Sword Agility":
                effects.Append(new BonusEffect(StatType.Spd, _bonus12));
                effects.Append(new AgainstPenaltyEffect(StatType.Atk, _penalty6));
                break;

            case "Bow Focus":
            case "Sword Focus":
                effects.Append(new BonusEffect(StatType.Atk, _bonus10));
                effects.Append(new AgainstPenaltyEffect(StatType.Res, _penalty10));
                break;
            
            case "Lance Agility":
            case "Bow Agility":
                effects.Append(new BonusEffect(StatType.Spd, _bonus12));
                effects.Append(new AgainstPenaltyEffect(StatType.Atk, _penalty6));
                break;
            
            case "Close Def":
            case "Distant Def":
                effects.Append(new BonusEffect(StatType.Def, _bonus8));
                effects.Append(new BonusEffect(StatType.Res, _bonus8));
                effects.Append(new BonusNeutralizationEffect(StatType.Atk));
                effects.Append(new BonusNeutralizationEffect(StatType.Spd));
                effects.Append(new BonusNeutralizationEffect(StatType.Def));
                effects.Append(new BonusNeutralizationEffect(StatType.Res));
                break;
            
            case "Dragonskin":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusEffect(StatType.Spd, _bonus6));
                effects.Append(new BonusEffect(StatType.Def, _bonus6));
                effects.Append(new BonusEffect(StatType.Res, _bonus6));
                effects.Append(new BonusNeutralizationEffect(StatType.Atk));
                effects.Append(new BonusNeutralizationEffect(StatType.Spd));
                effects.Append(new BonusNeutralizationEffect(StatType.Def));
                effects.Append(new BonusNeutralizationEffect(StatType.Res));
                break;

            case "Fort. Def/Res":
                effects.Append(new BonusEffect(StatType.Def, _bonus6));
                effects.Append(new BonusEffect(StatType.Res, _bonus6));
                effects.Append(new AgainstPenaltyEffect(StatType.Atk, _penalty2));
                break;

            case "Life and Death":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusEffect(StatType.Spd, _bonus6));
                effects.Append(new AgainstPenaltyEffect(StatType.Def, _penalty5));
                effects.Append(new AgainstPenaltyEffect(StatType.Res, _penalty5));
                break;

            case "Solid Ground":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusEffect(StatType.Def, _bonus6));
                effects.Append(new AgainstPenaltyEffect(StatType.Res, _penalty5));
                break;
            
            case "Still Water":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusEffect(StatType.Res, _bonus6));
                effects.Append(new AgainstPenaltyEffect(StatType.Def, _penalty5));
                break;

            case "Light and Dark":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty5));
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty5));
                effects.Append(new PenaltyEffect(StatType.Def, _penalty5));
                effects.Append(new PenaltyEffect(StatType.Res, _penalty5));
                effects.Append(new PenaltyNeutralizationEffect(StatType.Atk));
                effects.Append(new PenaltyNeutralizationEffect(StatType.Spd));
                effects.Append(new PenaltyNeutralizationEffect(StatType.Def));
                effects.Append(new PenaltyNeutralizationEffect(StatType.Res));
                effects.Append(new BonusNeutralizationEffect(StatType.Atk));
                effects.Append(new BonusNeutralizationEffect(StatType.Spd));
                effects.Append(new BonusNeutralizationEffect(StatType.Def));
                effects.Append(new BonusNeutralizationEffect(StatType.Res));
                break;
            
            case "Lull Atk/Spd":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty3));
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty3));
                effects.Append(new BonusNeutralizationEffect(StatType.Atk));
                effects.Append(new BonusNeutralizationEffect(StatType.Spd));
                break;
            
            case "Lull Atk/Def":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty3));
                effects.Append(new PenaltyEffect(StatType.Def, _penalty3));
                effects.Append(new BonusNeutralizationEffect(StatType.Atk));
                effects.Append(new BonusNeutralizationEffect(StatType.Def));
                break;
            
            case "Lull Atk/Res":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty3));
                effects.Append(new PenaltyEffect(StatType.Res, _penalty3));
                effects.Append(new BonusNeutralizationEffect(StatType.Atk));
                effects.Append(new BonusNeutralizationEffect(StatType.Res));
                break;
            
            case "Lull Spd/Def":
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty3));
                effects.Append(new PenaltyEffect(StatType.Def, _penalty3));
                effects.Append(new BonusNeutralizationEffect(StatType.Spd));
                effects.Append(new BonusNeutralizationEffect(StatType.Def));
                break;
            
            case "Lull Spd/Res":
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty3));
                effects.Append(new PenaltyEffect(StatType.Res, _penalty3));
                effects.Append(new BonusNeutralizationEffect(StatType.Spd));
                effects.Append(new BonusNeutralizationEffect(StatType.Res));
                break;
            
            case "Lull Def/Res":
                effects.Append(new PenaltyEffect(StatType.Def, _penalty3));
                effects.Append(new PenaltyEffect(StatType.Res, _penalty3));
                effects.Append(new BonusNeutralizationEffect(StatType.Def));
                effects.Append(new BonusNeutralizationEffect(StatType.Res));
                break;
            
            case "Soulblade":
                SoulbladeFactory soulbladeEffectFactory = new();
                List<Effect> soulbladeEffects = soulbladeEffectFactory.Create(unit);
                effects.AppendRange(soulbladeEffects);
                break;

            
            case "Sandstorm":
                SandstormFactory sandstormEffectFactory = new();
                List<Effect> sandstormEffects = sandstormEffectFactory.Create(unit);
                effects.AppendRange(sandstormEffects);
                break;
                        
            case "Dragon Wall":
                effects.Append(new DragonWallEffect());
                break;
            
            case "Dodge":
                effects.Append(new DodgeEffect());
                break;
            
            case "Golden Lotus":
                effects.Append(new DamagePercentageReductionOnFirstAttackEffect(_percentagePenalty50));
                break;
            
            case "Gentility":
            case "Bow Guard":
            case "Axe Guard":
            case "Magic Guard":
            case "Lance Guard":
            case "Sympathetic":
                effects.Append(new DamageReductionEffect(_penalty5));
                break;
            
            case "Arms Shield":
                effects.Append(new DamageReductionEffect(_penalty7));
                break;
            
            case "Back at You":
                effects.Append(new BackAtYouEffect());
                break;
            
            case "Lunar Brace":
                effects.Append(new PercentageDamageExtraEffectByStat(StatType.Def, _percentageDecimalBonus0_3));
                break;

            case "Bravery":
                effects.Append(new DamageExtraEffect(_bonus5));
                break;
            
            case "Aegis Shield":
                effects.Append(new BonusEffect(StatType.Def, _bonus6));
                effects.Append(new BonusEffect(StatType.Res, _bonus3));
                effects.Append(new DamagePercentageReductionOnFirstAttackEffect(_percentagePenalty50));
                break;
            
            case "Blue Skies":
                effects.Append(new DamageExtraEffect(_bonus5));
                effects.Append(new DamageReductionEffect(_penalty5));
                break;
            
            case "Remote Sparrow":
                effects.Append(new BonusEffect(StatType.Atk, _bonus7));
                effects.Append(new BonusEffect(StatType.Spd, _bonus7));
                effects.Append(new DamagePercentageReductionOnFirstAttackEffect(_percentagePenalty30));
                break;
            
            case "Remote Mirror":
                effects.Append(new BonusEffect(StatType.Atk, _bonus7));
                effects.Append(new BonusEffect(StatType.Res, _bonus10));
                effects.Append(new DamagePercentageReductionOnFirstAttackEffect(_percentagePenalty30));
                break;    
            
            case "Remote Sturdy":
                effects.Append(new BonusEffect(StatType.Atk, _bonus7));
                effects.Append(new BonusEffect(StatType.Def, _bonus10));
                effects.Append(new DamagePercentageReductionOnFirstAttackEffect(_percentagePenalty30));
                break;
            
            case "Fierce Stance":
                effects.Append(new BonusEffect(StatType.Atk, _bonus8));
                effects.Append(new DamagePercentageReductionOnFollowUpEffect(_penalty10));
                break;
            
            case "Darting Stance":
                effects.Append(new BonusEffect(StatType.Spd, _bonus8));
                effects.Append(new DamagePercentageReductionOnFollowUpEffect(_penalty10));
                break;
            
            case "Steady Stance":
                effects.Append(new BonusEffect(StatType.Def, _bonus8));
                effects.Append(new DamagePercentageReductionOnFollowUpEffect(_penalty10));
                break;
            
            case "Warding Stance":
                effects.Append(new BonusEffect(StatType.Res, _bonus8));
                effects.Append(new DamagePercentageReductionOnFollowUpEffect(_penalty10));
                break;
            
            case "Kestrel Stance":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusEffect(StatType.Spd, _bonus6));
                effects.Append(new DamagePercentageReductionOnFollowUpEffect(_penalty10));
                break;
            
            case "Sturdy Stance":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusEffect(StatType.Def, _bonus6));
                effects.Append(new DamagePercentageReductionOnFollowUpEffect(_penalty10));
                break;
            
            case "Mirror Stance":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusEffect(StatType.Res, _bonus6));
                effects.Append(new DamagePercentageReductionOnFollowUpEffect(_penalty10));
                break;
            
            case "Steady Posture":
                effects.Append(new BonusEffect(StatType.Spd, _bonus6));
                effects.Append(new BonusEffect(StatType.Def, _bonus6));
                effects.Append(new DamagePercentageReductionOnFollowUpEffect(_penalty10));
                break;
            
            case "Swift Stance":
                effects.Append(new BonusEffect(StatType.Spd, _bonus6));
                effects.Append(new BonusEffect(StatType.Res, _bonus6));
                effects.Append(new DamagePercentageReductionOnFollowUpEffect(_penalty10));
                break;

            case "Bracing Stance":
                effects.Append(new BonusEffect(StatType.Def, _bonus6));
                effects.Append(new BonusEffect(StatType.Res, _bonus6));
                effects.Append(new DamagePercentageReductionOnFollowUpEffect(_penalty10));
                break;
            
            case "Prescience":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty5));
                effects.Append(new PenaltyEffect(StatType.Res, _penalty5));
                effects.Append(new PrescienceEffect());
                break;
            
            case "Poetic Justice":
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty4));
                effects.Append(new PercentageDamageExtraEffectByStat(StatType.Atk, _percentageDecimalBonus0_15));
                break;
            
            case "Chivalry":
                effects.Append(new DamageExtraEffect(_bonus2));
                effects.Append(new DamageReductionEffect(_penalty2));
                break;
            
            case "Laguz Friend":
                effects.Append(new DamagePercentageReductionEffect(_percentagePenalty50));
                effects.Append(new AgainstBonusNeutralizationEffect(StatType.Def));
                effects.Append(new AgainstBonusNeutralizationEffect(StatType.Res));
                int unitHalfBaseDef = Convert.ToInt32(Math.Floor(unit.BaseDef * _halfStatMultiplier));
                int unitHalfBaseRes = Convert.ToInt32(Math.Floor(unit.BaseRes * _halfStatMultiplier));

                effects.Append(new AgainstPenaltyEffect(StatType.Def, unitHalfBaseDef));
                effects.Append(new AgainstPenaltyEffect(StatType.Res, unitHalfBaseRes));
                break;
            
            case "Guard Bearing":
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty4));
                effects.Append(new PenaltyEffect(StatType.Def, _penalty4));
                effects.Append(new GuardBearingEffect());
                break;
            
            case "Bushido":
                effects.Append(new DamageExtraEffect(_bonus7));
                effects.Append(new DamageReductionWithStatCondition(StatType.Spd));
                break;
            
            case "Moon-Twin Wing":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty5));
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty5));
                effects.Append(new MoonTwinWingEffect());
                break;
            
            case "Divine Recreation":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty4));
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty4));
                effects.Append(new PenaltyEffect(StatType.Def, _penalty4));
                effects.Append(new PenaltyEffect(StatType.Res, _penalty4));
                effects.Append(new DamagePercentageReductionOnFirstAttackEffect(_percentagePenalty30));
                effects.Append(new PostApplicationEffect());
                break;
            
            case "Extra Chivalry":
                ExtraChivalryFactory extraChivalryEffectFactory = new();
                List<Effect> extraChivalryEffects = extraChivalryEffectFactory.Create(unit);
                effects.AppendRange(extraChivalryEffects);
                break;
            
            case "Dragon's Wrath":
                DragonsWrathFactory dragonsWrathEffectFactory = new();
                List<Effect> dragonsWrathEffects = dragonsWrathEffectFactory.Create(unit);
                effects.AppendRange(dragonsWrathEffects);
                break;
            
            case "Nosferatu":
            case "Solar Brace":
                effects.Append(new HpPercentageRecoveryEffect(_percentageBonus50));
                break;
            
            case "Sol":
                effects.Append(new HpPercentageRecoveryEffect(_bonus25));
                break;
            
            case "Mystic Boost":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty5));
                effects.Append(new HpRecoveryPostCombatEffect(_bonus10));
                break;
            
            case "Atk/Spd Push":
                effects.Append(new BonusEffect(StatType.Atk, _bonus7));
                effects.Append(new BonusEffect(StatType.Spd, _bonus7));
                effects.Append(new HpReductionPostCombatEffect(_penalty5));
                break;

            case "Atk/Def Push":
                effects.Append(new BonusEffect(StatType.Atk, _bonus7));
                effects.Append(new BonusEffect(StatType.Def, _bonus7));
                effects.Append(new HpReductionPostCombatEffect(_penalty5));
                break;

            case "Atk/Res Push":
                effects.Append(new BonusEffect(StatType.Atk, _bonus7));
                effects.Append(new BonusEffect(StatType.Res, _bonus7));
                effects.Append(new HpReductionPostCombatEffect(_penalty5));
                break;
            
            case "Spd/Def Push":
                effects.Append(new BonusEffect(StatType.Spd, _bonus7));
                effects.Append(new BonusEffect(StatType.Def, _bonus7));
                effects.Append(new HpReductionPostCombatEffect(_penalty5));
                break;
            
            case "Spd/Res Push":
                effects.Append(new BonusEffect(StatType.Spd, _bonus7));
                effects.Append(new BonusEffect(StatType.Res, _bonus7));
                effects.Append(new HpReductionPostCombatEffect(_penalty5));
                break;
                
            case "Def/Res Push":
                effects.Append(new BonusEffect(StatType.Def, _bonus7));
                effects.Append(new BonusEffect(StatType.Res, _bonus7));
                effects.Append(new HpReductionPostCombatEffect(_penalty5));
                break;
            
            case "Windsweep":
            case "Surprise Attack":
            case "Hliðskjálf":
                effects.Append(new CounterattackDenialEffect());
                break;
            
            case "Laws of Sacae":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusEffect(StatType.Spd, _bonus6));
                effects.Append(new BonusEffect(StatType.Def, _bonus6));
                effects.Append(new BonusEffect(StatType.Res, _bonus6));
                LawsOfSacaeFactory lawsOfSacaeFactory = new();
                List<Effect> lawsOfSacaeEffects = lawsOfSacaeFactory.Create(unit);
                effects.AppendRange(lawsOfSacaeEffects);  
                break;
            
            case "Null C-Disrupt":
                effects.Append(new CounterattackNegationDenialEffect());
                break;
            
            case "Resonance":
                effects.Append(new HpReductionPreCombatEffect(_penalty1));
                effects.Append(new DamageExtraEffect(_bonus3));
                break;
            
            case "Bewitching Tome":
                effects.Append(new BonusEffect(StatType.Atk, _bonus5));
                effects.Append(new BonusEffect(StatType.Spd, _bonus5));
                effects.Append(new BonusEffect(StatType.Def, _bonus5));
                effects.Append(new BonusEffect(StatType.Res, _bonus5));
                effects.Append(new PercentageBonusEffect(StatType.Atk, _percentageBonus20));
                effects.Append(new PercentageBonusEffect(StatType.Spd, _percentageBonus20));
                effects.Append(new DamagePercentageReductionOnFirstAttackEffect(_percentagePenalty30));
                effects.Append(new HpRecoveryPostCombatEffect(_bonus7));
                effects.Append(new PostApplicationEffect());
                break;
            
            case "Fury":
                effects.Append(new BonusEffect(StatType.Atk, _bonus4));
                effects.Append(new BonusEffect(StatType.Spd, _bonus4));
                effects.Append(new BonusEffect(StatType.Def, _bonus4));
                effects.Append(new BonusEffect(StatType.Res, _bonus4));
                effects.Append(new HpReductionPostCombatEffect(_penalty8));
                break;
            
            case "Scendscale":
                effects.Append(new PercentageDamageExtraEffectByStatEffect(StatType.Atk, _percentageBonus25));
                effects.Append(new HpReductionPostCombatEffect(_penalty7));
                break;
            
            case "True Dragon Wall":
                effects.Append(new HpRecoveryPostCombatWithAllyConditionEffect(_bonus7));
                TrueDragonWallFactory trueDragonWallFactory = new();
                List<Effect> trueDragonWallEffects = trueDragonWallFactory.Create(unit);
                effects.AppendRange(trueDragonWallEffects);  
                break;
            
            case "Flare":
                effects.Append(new PercentagePenaltyEffect(StatType.Res, _percentagePenalty20));
                effects.Append(new HpPercentageRecoveryEffect(_percentageBonus50));
                break;
            
            case "Eclipse Brace":
                effects.Append(new PercentageDamageExtraEffectByOpponentStatEffect(StatType.Def, _percentageBonus30));
                effects.Append(new HpPercentageRecoveryEffect(_percentageBonus50));
                break;
            
            case "Mastermind":
                MastermindFactory mastermindFactory = new();
                List<Effect> mastemindEffects = mastermindFactory.Create(unit);
                effects.AppendRange(mastemindEffects); 
                break;
            
            case "Quick Riposte":
            case "Follow-Up Ring":
                effects.Append(new FollowUpGuaranteedEffect());
                break;

            case "Wary Fighter":
                effects.Append(new FollowUpNeutralizationEffect());
                effects.Append(new FollowUpNeutralizationForOpponentEffect());
                break;
            
            case "Piercing Tribute":
                effects.Append(new NegationFollowUpGuaranteedEffectForOpponent());
                break;
            
            case "Mjölnir":
                effects.Append(new NegationFollowUpNeutralizationEffect());
                break;
            
            case "Brash Assault":
                effects.Append(new PenaltyEffect(StatType.Def, _penalty4));
                effects.Append(new PenaltyEffect(StatType.Res, _penalty4));
                effects.Append(new DamagePercentageReductionOnFirstAttackEffect(_percentagePenalty30));
                effects.Append(new FollowUpGuaranteedEffect());
                BrashAssaultFactory brashAssaultFactory = new();
                List<Effect> brashAssaultEffects = brashAssaultFactory.Create(unit);
                effects.AppendRange(brashAssaultEffects);  
                break;
            
            case "Melee Breaker":
                effects.Append(new FollowUpGuaranteedEffect());
                effects.Append(new FollowUpNeutralizationForOpponentEffect());
                break;
            
            case "Range Breaker":
                effects.Append(new FollowUpGuaranteedEffect());
                effects.Append(new FollowUpNeutralizationForOpponentEffect());
                break;
            
            case "Null Follow-Up":
                effects.Append(new NegationFollowUpNeutralizationEffect());
                effects.Append(new NegationFollowUpGuaranteedEffectForOpponent());
                break;
            
            case "Sturdy Impact":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusEffect(StatType.Def, _bonus10));
                effects.Append(new FollowUpNeutralizationForOpponentEffect());
                break;
            
            case "Mirror Impact":
                effects.Append(new BonusEffect(StatType.Atk, _bonus6));
                effects.Append(new BonusEffect(StatType.Res, _bonus10));
                effects.Append(new FollowUpNeutralizationForOpponentEffect());
                break;
            
            case "Swift Impact":
                effects.Append(new BonusEffect(StatType.Spd, _bonus6));
                effects.Append(new BonusEffect(StatType.Res, _bonus10));
                effects.Append(new FollowUpNeutralizationForOpponentEffect());
                break;
            
            case "Steady Impact":
                effects.Append(new BonusEffect(StatType.Spd, _bonus6));
                effects.Append(new BonusEffect(StatType.Def, _bonus10));
                effects.Append(new FollowUpNeutralizationForOpponentEffect());
                break;
            
            case "Slick Fighter":
                effects.Append(new PenaltyNeutralizationEffect(StatType.Atk));
                effects.Append(new PenaltyNeutralizationEffect(StatType.Spd));
                effects.Append(new PenaltyNeutralizationEffect(StatType.Def));
                effects.Append(new PenaltyNeutralizationEffect(StatType.Res));
                effects.Append(new FollowUpGuaranteedEffect());
                break;
            
            case "Wily Fighter":
                effects.Append(new BonusNeutralizationEffect(StatType.Atk));
                effects.Append(new BonusNeutralizationEffect(StatType.Spd));
                effects.Append(new BonusNeutralizationEffect(StatType.Def));
                effects.Append(new BonusNeutralizationEffect(StatType.Res));
                effects.Append(new FollowUpGuaranteedEffect());
                break;   
            
            case "Pegasus Flight":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty4));
                effects.Append(new PenaltyEffect(StatType.Def, _penalty4));
                PegasusFlightFactory pegasusFlightFactory = new();
                List<Effect> pegasusFlightEffects = pegasusFlightFactory.Create(unit);
                effects.AppendRange(pegasusFlightEffects);   
                break;
            
            case "Wyvern Flight":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty4));
                effects.Append(new PenaltyEffect(StatType.Def, _penalty4));
                WyvernFlightFactory wyvernFlightFactory = new();
                List<Effect> wyvernFlightEffects = wyvernFlightFactory.Create(unit);
                effects.AppendRange(wyvernFlightEffects);   
                break;
            
            case "Savvy Fighter":
                effects.Append(new NegationFollowUpNeutralizationEffect());
                effects.Append(new NegationFollowUpGuaranteedEffectForOpponent());
                effects.Append(new SavvyFighterEffect());
                break;
            
            case "Sun-Twin Wing":
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty5));
                effects.Append(new PenaltyEffect(StatType.Def, _penalty5));
                effects.Append(new NegationFollowUpNeutralizationEffect());
                effects.Append(new NegationFollowUpGuaranteedEffectForOpponent());
                break;
            
            case "New Divinity":
                NewDivinityFactory newDivinityFactory = new();
                List<Effect> newDivinityEffects = newDivinityFactory.Create(unit);
                effects.AppendRange(newDivinityEffects);   
                break;
            
            case "Blue Lion Rule":
                effects.Append(new DamageReductionWithStatCondition(StatType.Def));
                effects.Append(new BlueLionRuleFollowUpGuaranteedEffect());
                break;
            
            case "Black Eagle Rule":
                effects.Append(new FollowUpGuaranteedEffect());
                effects.Append(new BlackEagleRuleFollowUpGuaranteedEffect());
                break;
            
            case "Binding Shield":
                effects.Append(new FollowUpGuaranteedEffect());
                effects.Append(new FollowUpNeutralizationForOpponentEffect());
                BindingShieldFactory bindingShieldFactory= new();
                List<Effect> bindingShieldEffect = bindingShieldFactory.Create(unit);
                effects.AppendRange(bindingShieldEffect); 
                break;
            
            case "Flow Feather":
                effects.Append(new NegationFollowUpNeutralizationEffect());
                FlowEffectsFactory flowFeatherFactory = new(StatType.Res);
                List<Effect> flowFeatherEffects = flowFeatherFactory.Create(unit);
                effects.AppendRange(flowFeatherEffects); 
                break;
            
            case "Flow Flight":
                effects.Append(new NegationFollowUpNeutralizationEffect());
                FlowEffectsFactory flowFlightFactory = new(StatType.Def);
                List<Effect> flowFlightEffects = flowFlightFactory.Create(unit);
                effects.AppendRange(flowFlightEffects); 
                break;
            
            case "Flow Force":
                effects.Append(new NegationFollowUpNeutralizationEffect());
                effects.Append(new PenaltyNeutralizationEffect(StatType.Atk));
                effects.Append(new PenaltyNeutralizationEffect(StatType.Spd));
                break;
            
            case "Flow Refresh":
                effects.Append(new NegationFollowUpNeutralizationEffect());
                effects.Append(new HpRecoveryPostCombatEffect(_bonus10));
                break;
            
            case "Dragon's Ire":
                effects.Append(new PenaltyEffect(StatType.Atk, _penalty4));
                effects.Append(new PenaltyEffect(StatType.Res, _penalty4));
                effects.Append(new FollowUpGuaranteedEffect());
                DragonsIreFactory dragonsIreFactory= new();
                List<Effect> dragonsIreEffect = dragonsIreFactory.Create(unit);
                effects.AppendRange(dragonsIreEffect);
                break;
            
            case "Phys. Null Follow":
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty4));
                effects.Append(new PenaltyEffect(StatType.Def, _penalty4));
                effects.Append(new NegationFollowUpNeutralizationEffect());
                effects.Append(new NegationFollowUpGuaranteedEffectForOpponent());
                effects.Append(new ReductionPercentageDamageReduction(_percentageDecimalPenalty0_5));
                break;
            
            case "Mag. Null Follow":
                effects.Append(new PenaltyEffect(StatType.Spd, _penalty4));
                effects.Append(new PenaltyEffect(StatType.Res, _penalty4));
                effects.Append(new NegationFollowUpNeutralizationEffect());
                effects.Append(new NegationFollowUpGuaranteedEffectForOpponent());
                effects.Append(new ReductionPercentageDamageReduction(_percentageDecimalPenalty0_5));
                break;
            
            default:
                throw new ApplicationException($"No effect found for '{skillName}' in EffectFactory");
        }
        return effects.GetAllEffects();
    }
}