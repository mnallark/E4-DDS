namespace Fire_Emblem_Model;

public class MoreStatThanOpponentCondition : Condition
{
    private readonly StatType _targetStat;

    public MoreStatThanOpponentCondition(StatType statType)
    {
        _targetStat = statType;
    }
    public override bool DoesItHold(Unit unit)
    {
        return false;
    }
    
    public override bool DoesItHoldAfterStatsEffectsApplied(Unit unit)
    {
        switch (_targetStat)
        {
            case StatType.Res:
                return unit.Res > unit.Opponent.Res;

            case StatType.Spd:
                return unit.Spd > unit.Opponent.Spd;
            
            default:
                throw new InvalidStatType();
        }
    }
}