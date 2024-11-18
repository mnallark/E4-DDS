namespace Fire_Emblem_Model;

public class HasNotPlayedBeforeCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        return unit.IsFirstCombatAsInitiator &&  unit.IsFirstCombatAsDefender;
    }
}