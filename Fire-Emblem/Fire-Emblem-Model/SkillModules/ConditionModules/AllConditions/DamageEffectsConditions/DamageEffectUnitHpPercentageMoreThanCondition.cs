namespace Fire_Emblem_Model;

public class DamageEffectUnitHpPercentageMoreThanCondition : Condition
{
    private readonly double _targetHp;
    public DamageEffectUnitHpPercentageMoreThanCondition(double targetHp)
    {
        _targetHp = targetHp;
    }
    
    public override bool DoesItHold(Unit unit)
    {
        return false;
    }
    
    public override bool DoesItHoldAfterStatsEffectsApplied(Unit unit)
    {
        return Math.Round(Convert.ToDouble(unit.HP) / Convert.ToDouble(unit.MaxHP), 2) >= _targetHp;
    }
}