namespace Fire_Emblem_Model;

public class UnitUsesMagicAndHpMoreThan : Condition
{
    private readonly int _targetHp;
    public UnitUsesMagicAndHpMoreThan(int targetHp)
    {
        _targetHp = targetHp;
    }
    
    public override bool DoesItHold(Unit unit)
    {
        return unit.Weapon == "Magic" && unit.HP >= _targetHp;
    }
}