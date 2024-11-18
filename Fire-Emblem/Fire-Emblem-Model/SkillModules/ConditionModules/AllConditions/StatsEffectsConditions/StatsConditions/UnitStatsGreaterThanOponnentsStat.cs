namespace Fire_Emblem_Model;

public class UnitStatIsGreaterThanOponnentsStatCondition : Condition
{
    private readonly StatType _targetStat;
    private readonly int _targetAmount;
    public UnitStatIsGreaterThanOponnentsStatCondition(StatType statType, int Amount)
    {
        _targetStat = statType;
        _targetAmount = Amount;
    }
    
    public override bool DoesItHold(Unit unit)
    {
        if (_targetStat == StatType.Spd)
            return unit.Spd >= unit.Opponent.Spd + _targetAmount;

        return false;
    }
}