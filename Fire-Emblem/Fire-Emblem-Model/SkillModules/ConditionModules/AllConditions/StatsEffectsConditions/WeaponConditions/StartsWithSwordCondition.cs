namespace Fire_Emblem_Model;

public class StartsWithSwordCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        if (unit.StartsCombat)
            return unit.Weapon == "Sword";
        return false;
    }
}