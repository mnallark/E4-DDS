namespace Fire_Emblem_Model;

public class UnitStatIsStrictlyGreaterThanOponnentsStat : Condition
{
    private readonly StatType _targetStat;

    public UnitStatIsStrictlyGreaterThanOponnentsStat(StatType statType)
    {
        _targetStat = statType;
    }
    
    public override bool DoesItHold(Unit unit)
    {
        if (_targetStat == StatType.Def)
            return unit.Def > unit.Opponent.Def;

        return false;
    }
}