namespace Fire_Emblem_Model;

public class StartsCombatAgainstFullHpOpponentCondition : Condition
{
    
    public override bool DoesItHold(Unit unit)
    {
        return false;
    }
    
    public override bool DoesItHoldAfterStatsEffectsApplied(Unit unit)
    {
        return unit.StartsCombat && unit.Opponent.HP == unit.Opponent.MaxHP;
    }
}