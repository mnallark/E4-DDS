namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;

public class ConditionFactory
{
    private const int _moreThanHpConditionAmount = 3;
    private const double _lessThanHpConditionAmountWillToWin = 0.5;
    private const double _lessThanHpConditionAmountResolve = 0.75;
    private const double _lessThanHpConditionAmountBrazen = 0.8;
    private const int _weaponAdvantageConditionAmount = 5;
    private const double _statEffectUnitHpPercentageMoreThan = 0.25;
    private const double _damageEffectUnitHpPercentageMoreThan = 0.25;
    private const double _opponentMoreThanSomeHpPercentageConditionAmount = 0.5;
    private const double _opponentStartsCombatAndUnitHpPercentageMoreThanQuickRiposte = 0.6;
    private const double _damageEffectUnitHpPercentageMoreThanCondition = 0.5;

    public Condition Create(string skillName)
    {
        switch (skillName)
        {
            case "HP +15":
                return new HasNotPlayedBeforeCondition();

            case "Not *Quite*":
                return new OpponentStartsCombatCondition();

            case "Belief in Love":
                return new UnitStartsOrMaxHpCondition();

            case "Fire Boost":
            case "Wind Boost":
            case "Earth Boost":
            case "Water Boost":
                return new MoreThanSomeHpCondition(_moreThanHpConditionAmount);

            case "Single-Minded":
            case "Charmer":
                return new LastOpponentCondition();

            case "Deadly Blade":
                return new StartsWithSwordCondition();

            case "Stunning Smile":
            case "Disarming Sigh":
                return new MaleOpponentCondition();

            case "Chaos Style":
                return new ChaosCondition();

            case "Close Def":
                return new SwordLanceOrAxeCondition();

            case "Distant Def":
                return new MagicOrBowCondition();

            case "Dragonskin":
                return new UnitStartsOrMoreThanHpCondition();

            case "Tome Precision":
            case "Nosferatu":
                return new UnitWeaponCondition("Magic");

            case "Wrath":
                return new UnitHasLostSomeHpCondition();

            case "Ignis":
            case "Luna":
            case "Life and Death":
            case "Fort. Def/Res":
            case "Solid Ground":
            case "Still Water":
            case "Light and Dark":
            case "Beorc's Blessing":
            case "Sandstorm":
            case "Agnea's Arrow":
            case "Sol":
            case "Null C-Disrupt":
            case "Fury":
            case "Mystic Boost":
            case "Piercing Tribute":
            case "Mjölnir":
            case "Wyvern Flight":
            case "Null Follow-Up":
            case "Phys. Null Follow":
            case "Mag. Null Follow":
            case "Laguz Friend":
            case not null when skillName.Contains("+") || skillName.Contains("Lull"):
                return new EffectWithoutCondition();

            case "Fair Fight":
            case "Swift Sparrow":
            case "Perceptive":
            case "Blinding Flash":
                return new FirstUnitAttackingCondition();

            case not null when skillName.Contains("Strike") || skillName.Contains("Blow"):
                return new FirstUnitAttackingCondition();

            case "Will to Win":
                return new LessThanSomeHpCondition(_lessThanHpConditionAmountWillToWin);

            case "Resolve":
                return new LessThanSomeHpCondition(_lessThanHpConditionAmountResolve);

            case not null when skillName.Contains("Brazen"):
                return new LessThanSomeHpCondition(_lessThanHpConditionAmountBrazen);

            case not null when skillName.Contains("Agility") || skillName.Contains("Power") 
                                                             || skillName.Contains("Focus"):
                if (skillName.Contains("Sword"))
                    return new UnitWeaponCondition("Sword");
                if (skillName.Contains("Axe"))
                    return new UnitWeaponCondition("Axe");
                if (skillName.Contains("Lance"))
                    return new UnitWeaponCondition("Lance");
                if (skillName.Contains("Bow"))
                    return new UnitWeaponCondition("Bow");
                throw new ApplicationException($"The condition of '{skillName}' is not registered correctly");

            case "Soulblade":
                return new UnitWeaponCondition("Sword");

            case "Dragon Wall":
                return new MoreStatThanOpponentCondition(StatType.Res);

            case "Dodge":
                return new MoreStatThanOpponentCondition(StatType.Spd);

            case "Golden Lotus":
                return new OpponentDoesPhyisicalDamageCondition();

            case "Gentility":
            case "Bravery":
            case "Extra Chivalry":
            case "Blue Skies":
            case "Aegis Shield":
            case "Poetic Justice":
            case "Dragon's Wrath":
            case "Prescience":
            case "Guard Bearing":
            case "Bushido":
            case "Scendscale":
            case "Mastermind":
            case "True Dragon Wall":
            case "Pegasus Flight":
            case "New Divinity":
            case "Blue Lion Rule":
                return new DamageEffectWithoutCondition();

            case "Bow Guard":
                return new OpponenWeaponCondition("Bow");

            case "Magic Guard":
                return new OpponenWeaponCondition("Magic");

            case "Axe Guard":
                return new OpponenWeaponCondition("Axe");

            case "Lance Guard":
                return new OpponenWeaponCondition("Lance");

            case "Arms Shield":
                return new WeaponAdvantageCondition();

            case "Sympathetic":
                return new OpponentStartsAndUnitHpLessThanHalfCondition();

            case "Back at You":
            case "Steady Posture":
            case "Savvy Fighter":
                return new OpponentStartsCombatForDamageEffectCondition();

            case not null when skillName.Contains("Stance"):
                return new OpponentStartsCombatForDamageEffectCondition();

            case "Lunar Brace":
                return new StartsWithPhyisicalDamageCondition();

            case "Dragon's Ire":
            case "Black Eagle Rule":
            case "Sun-Twin Wing":
            case not null when skillName.Contains("Push"):
                return new StatEffectUnitHpPercentageMoreThanCondition(_statEffectUnitHpPercentageMoreThan);

            case "Moon-Twin Wing":
                return new DamageEffectUnitHpPercentageMoreThanCondition(_damageEffectUnitHpPercentageMoreThan);

            case "Divine Recreation":
                return new OpponentMoreThanSomeHpPercentageCondition(_opponentMoreThanSomeHpPercentageConditionAmount);

            case "Flow Feather":
            case "Flow Flight":
            case not null when skillName.Contains("Remote"):
                return new StartsCombatForDamageEffectCondition();

            case "Chivalry":
                return new StartsCombatAgainstFullHpOpponentCondition();

            case "Solar Brace":
            case "Laws of Sacae":
            case "Eclipse Brace":
            case "Flow Force":
            case "Flow Refresh":
            case not null when skillName.Contains("Impact"):
                return new UnitStartsCombatCondition();

            case "Windsweep":
                return new StartsWithWeaponAndOpponentUsesSameWeaponCondition("Sword");

            case "Surprise Attack":
                return new StartsWithWeaponAndOpponentUsesSameWeaponCondition("Bow");

            case "Hliðskjálf":
                return new StartsWithWeaponAndOpponentUsesSameWeaponCondition("Magic");

            case "Resonance":
                return new UnitUsesMagicAndHpMoreThan(2);

            case "Flare":
                return new UnitWeaponCondition("Magic");

            case "Bewitching Tome":
                return new UnitStartsCombatOrOpponentUsesBowOrMagicCondition();

            case "Quick Riposte":
                return new OpponentStartsCombatAndUnitHpPercentageMoreThanCondition(
                    _opponentStartsCombatAndUnitHpPercentageMoreThanQuickRiposte);

            case "Follow-Up Ring":
            case "Wary Fighter":
                return new DamageEffectUnitHpPercentageMoreThanCondition(
                    _damageEffectUnitHpPercentageMoreThanCondition);

            case "Brash Assault":
                return new BrashAssaultCondition();

            case "Melee Breaker":
                string[] meleeWeapons = { "Sword", "Lance", "Axe" };
                return new UnitHpPercentageMoreThanAndOpponentUsesWeaponCondition(
                    _damageEffectUnitHpPercentageMoreThanCondition, meleeWeapons);

            case "Range Breaker":
                string[] rangeWeapons = { "Magic", "Bow" };
                return new UnitHpPercentageMoreThanAndOpponentUsesWeaponCondition(
                    _damageEffectUnitHpPercentageMoreThanCondition, rangeWeapons);

            case "Slick Fighter":
            case "Wily Fighter":
                return new OpponentStartsCombatAndUnitHpPercentageMoreThanCondition(
                    _statEffectUnitHpPercentageMoreThan);

            case "Binding Shield":
                return new UnitStatIsGreaterThanOponnentsStatCondition(StatType.Spd, _weaponAdvantageConditionAmount);

            default:
                throw new ApplicationException($"No condition found for '{skillName}' in ConditionFactory");
        }
    }
}
