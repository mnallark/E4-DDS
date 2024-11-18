namespace Fire_Emblem_Model;

public class StartsWithPhyisicalDamageCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        return false;
    }
    
    public override bool DoesItHoldAfterStatsEffectsApplied(Unit unit)
    {
        return unit.StartsCombat && unit.Weapon != "Magic";
    }
}