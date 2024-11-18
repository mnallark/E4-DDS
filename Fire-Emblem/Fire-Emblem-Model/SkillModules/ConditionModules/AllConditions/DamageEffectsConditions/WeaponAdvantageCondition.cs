namespace Fire_Emblem_Model;

public class WeaponAdvantageCondition : Condition
{
    private readonly WeaponTriangleBonusCollection _weaponTriangleBonus = new();
    public override bool DoesItHold(Unit unit)
    {
        return false;
    }
    
    public override bool DoesItHoldAfterStatsEffectsApplied(Unit unit)
    {
        string attackerWeapon = unit.Weapon;
        string defenderWeapon = unit.Opponent.Weapon;

        return _weaponTriangleBonus.AttackerWeaponHasAdvantage(attackerWeapon, defenderWeapon);
    }
}