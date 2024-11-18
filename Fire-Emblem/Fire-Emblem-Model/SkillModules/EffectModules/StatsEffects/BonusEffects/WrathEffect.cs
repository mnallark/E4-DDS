namespace Fire_Emblem_Model;

public class WrathEffect : Effect
{
    private const double _maxChangeAmount = 30;

    public WrathEffect(StatType targetStat)
    {
        TargetStat = targetStat;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.Bonus;
    }

    public override double GetChangeAmount(Unit unit)
    {
        UpdateUnitState(unit);
        return CalculateChangeAmount(unit);
    }

    private void UpdateUnitState(Unit unit)
    {
        if (!unit.HasAttackedBefore)
        {
            unit.ChangePreCombatHpThatHasLossState();
        }
    }

    private double CalculateChangeAmount(Unit unit)
    {
        ChangeAmount = Math.Min(unit.PreCombatHpThatHasLoss, _maxChangeAmount);
        return ChangeAmount;
    }
}