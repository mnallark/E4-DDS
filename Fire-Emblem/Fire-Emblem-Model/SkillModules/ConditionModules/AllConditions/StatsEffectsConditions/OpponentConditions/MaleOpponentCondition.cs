namespace Fire_Emblem_Model;

public class MaleOpponentCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        return unit.Opponent.Gender == "Male";
    }
}