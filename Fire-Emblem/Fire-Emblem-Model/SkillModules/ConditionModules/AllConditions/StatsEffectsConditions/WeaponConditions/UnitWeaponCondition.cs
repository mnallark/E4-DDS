namespace Fire_Emblem_Model;

public class UnitWeaponCondition : Condition
{
    private readonly string _weapon;
    public UnitWeaponCondition(string weapon)
    {
        _weapon = weapon;
    }
    
    public override bool DoesItHold(Unit unit)
    {
        return unit.Weapon == _weapon;
    }
}