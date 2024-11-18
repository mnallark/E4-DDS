namespace Fire_Emblem_Model;

public class IgnisEffect : Effect
{
    private const double _effectMultiplier = 0.5;

    public IgnisEffect(StatType targetStat)
    {
        TargetStat = targetStat;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.BonusOnFirstAttack;
    }

    public override double GetChangeAmount(Unit unit)
    {
        ChangeAmount = Convert.ToInt32(Math.Floor(unit.BaseAtk * _effectMultiplier));
        return ChangeAmount;
    }
}