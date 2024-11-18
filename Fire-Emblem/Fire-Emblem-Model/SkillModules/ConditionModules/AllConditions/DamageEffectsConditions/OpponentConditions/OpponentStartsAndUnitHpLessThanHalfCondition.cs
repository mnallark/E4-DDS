namespace Fire_Emblem_Model;

public class OpponentStartsAndUnitHpLessThanHalfCondition : Condition
{
    private const double _targetHp = 0.5;
    
    public override bool DoesItHold(Unit unit)
    {
        return false;
    }
    
    public override bool DoesItHoldAfterStatsEffectsApplied(Unit unit)
    {
        if (unit.Opponent.StartsCombat)
            if (unit.HP <= unit.MaxHP * _targetHp)
                return true;

        return false;
    }
}