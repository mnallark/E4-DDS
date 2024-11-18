namespace Fire_Emblem_Model;

public class OpponentStartsCombatCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        return unit.Opponent.StartsCombat;
    }
}