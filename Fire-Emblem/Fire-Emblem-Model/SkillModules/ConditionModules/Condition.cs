namespace Fire_Emblem_Model;

public abstract class Condition
{
    public virtual bool DoesItHold(Unit unit)
    {
        return false;
    }
    public virtual bool DoesItHoldAfterStatsEffectsApplied(Unit unit)
    {
        return false;
    }
}