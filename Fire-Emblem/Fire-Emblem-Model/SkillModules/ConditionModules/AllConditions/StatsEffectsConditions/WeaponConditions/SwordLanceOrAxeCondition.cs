namespace Fire_Emblem_Model;

public class SwordLanceOrAxeCondition : Condition
{
    private readonly WeaponsCollection _conditionWeapons = new();

    public SwordLanceOrAxeCondition()
    {
        _conditionWeapons.Append("Sword");
        _conditionWeapons.Append("Lance");
        _conditionWeapons.Append("Axe");
    }

    public override bool DoesItHold(Unit unit)
    {
        Unit opponent = unit.Opponent;
        
        return opponent.StartsCombat && _conditionWeapons.CheckWeaponCollectionContains(opponent.Weapon);
    }
}