namespace Fire_Emblem_Model;

public class FirstUnitAttackingCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        return unit.StartsCombat;
    }
}