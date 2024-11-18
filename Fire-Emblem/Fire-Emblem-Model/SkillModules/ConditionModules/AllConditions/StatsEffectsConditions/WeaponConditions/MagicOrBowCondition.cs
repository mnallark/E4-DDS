namespace Fire_Emblem_Model;

public class MagicOrBowCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        return unit.Opponent.StartsCombat && IsWeaponMagicOrBow(unit);
    }

    private bool IsWeaponMagicOrBow(Unit unit)
    {
        return unit.Opponent.Weapon == "Magic" | unit.Opponent.Weapon == "Bow";
    }
}