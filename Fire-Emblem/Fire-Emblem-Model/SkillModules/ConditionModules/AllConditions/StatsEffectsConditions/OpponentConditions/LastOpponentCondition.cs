namespace Fire_Emblem_Model;

public class LastOpponentCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        return unit.LastOpponent == unit.Opponent;
    }
}