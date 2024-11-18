namespace Fire_Emblem_Model;

public class PrescienceEffect : Effect
{       
    private const double _damageReductionAmount = 30;
    private const int _minChangeAmount = 0;

    public override EffectType GetEffectType()
    {
        return EffectType.PercentageDamageReductionOnFirstAttack;
    }

    public override double GetChangeAmount(Unit unit)
    {
        return CheckConditionTodApplyEffect(unit) ? _damageReductionAmount : _minChangeAmount;
    }

    private bool CheckConditionTodApplyEffect(Unit unit)
    {
        return unit.StartsCombat || WeaponConditionHolds(unit);
    }

    private bool WeaponConditionHolds(Unit unit)
    {
        return unit.Opponent.Weapon == "Magic" || unit.Opponent.Weapon == "Bow";
    }
}