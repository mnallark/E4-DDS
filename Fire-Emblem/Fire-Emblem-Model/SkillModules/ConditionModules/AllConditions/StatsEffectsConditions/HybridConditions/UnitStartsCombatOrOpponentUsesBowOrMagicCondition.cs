namespace Fire_Emblem_Model;

public class UnitStartsCombatOrOpponentUsesBowOrMagicCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        if (unit.StartsCombat)
            return true;

        if (unit.Opponent.Weapon == "Bow" || unit.Opponent.Weapon == "Magic")
            return true;
        
        return false;
    }
}