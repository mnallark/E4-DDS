namespace Fire_Emblem_Model;

public class WeaponTriangleBonusCollection
{
    private readonly Dictionary<string, string> _weaponTriangleBonus;

    public WeaponTriangleBonusCollection()
    {
        _weaponTriangleBonus = new Dictionary<string, string>
        {
            { "Sword", "Axe" },
            { "Axe", "Lance" },
            { "Lance", "Sword" }
        };
    }

    public bool AttackerWeaponHasAdvantage(string attackerWeapon, string defenderWeapon)
    {
        return _weaponTriangleBonus.ContainsKey(attackerWeapon) && 
               _weaponTriangleBonus[attackerWeapon] == defenderWeapon;
    }
}