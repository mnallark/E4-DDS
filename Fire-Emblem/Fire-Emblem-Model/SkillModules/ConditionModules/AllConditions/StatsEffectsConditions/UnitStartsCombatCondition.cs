namespace Fire_Emblem_Model;

public class UnitStartsCombatCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        return unit.StartsCombat;
    }
}