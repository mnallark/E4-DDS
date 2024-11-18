namespace Fire_Emblem_Model;

public class StartsWithWeaponAndOpponentUsesSameWeaponCondition : Condition
{
    private readonly string _weapon;
    
    public StartsWithWeaponAndOpponentUsesSameWeaponCondition(string weapon)
    {
        _weapon = weapon;
    }
    
    public override bool DoesItHold(Unit unit)
    {
        if (unit.StartsCombat)
            return unit.Weapon == _weapon && unit.Opponent.Weapon == _weapon;
        return false;
    }
}