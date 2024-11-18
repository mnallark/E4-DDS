namespace Fire_Emblem_Model;

public class ChaosCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        return unit.StartsCombat && HasWeaponChaos(unit);
    }

    private bool HasWeaponChaos(Unit unit)
    {
        return AreWeaponsChaotic(unit.Weapon, unit.Opponent.Weapon);
    }

    private bool AreWeaponsChaotic(string weapon1, string weapon2)
    {
        bool isWeapon1Magic = weapon1 == "Magic";
        bool isWeapon2Magic = weapon2 == "Magic";
        return isWeapon1Magic != isWeapon2Magic;
    }
}