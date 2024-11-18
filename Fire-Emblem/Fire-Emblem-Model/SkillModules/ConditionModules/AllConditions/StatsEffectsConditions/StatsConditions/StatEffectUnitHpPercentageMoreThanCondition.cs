namespace Fire_Emblem_Model;

public class StatEffectUnitHpPercentageMoreThanCondition : Condition
{
    private readonly double _targetHP;
    public StatEffectUnitHpPercentageMoreThanCondition(double targetHP)
    {
        _targetHP = targetHP;
    }
    
    public override bool DoesItHold(Unit unit)
    {
        return Math.Round(Convert.ToDouble(unit.HP) / Convert.ToDouble(unit.MaxHP), 2) >= _targetHP;
    }
}