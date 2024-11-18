namespace Fire_Emblem_Model;

public class SavvyFighterEffect : Effect
{
    private const int _speedThreshold = 4;
    private const double _damageReductionAmount = 30;

    public override EffectType GetEffectType()
    {
        return EffectType.PercentageDamageReductionOnFirstAttack;
    }

    public override double GetChangeAmount(Unit unit)
    {
        return CheckSpeedCondition(unit) ? _damageReductionAmount : 0;
    }

    private bool CheckSpeedCondition(Unit unit)
    {
        return unit.Spd >= unit.Opponent.Spd - _speedThreshold;
    }
}