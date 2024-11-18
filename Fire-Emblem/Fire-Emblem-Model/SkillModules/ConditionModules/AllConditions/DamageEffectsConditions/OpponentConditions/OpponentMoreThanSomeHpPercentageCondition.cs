namespace Fire_Emblem_Model;

public class OpponentMoreThanSomeHpPercentageCondition : Condition
{
    private readonly double _targetHp;
    public OpponentMoreThanSomeHpPercentageCondition(double targetHp)
    {
        _targetHp = targetHp;
    }
    
    public override bool DoesItHold(Unit unit)
    {
        return false;
    }
    
    public override bool DoesItHoldAfterStatsEffectsApplied(Unit unit)
    {
        return Math.Round(Convert.ToDouble(unit.Opponent.HP) / Convert.ToDouble(unit.Opponent.MaxHP), 2) >= _targetHp;
    }
}