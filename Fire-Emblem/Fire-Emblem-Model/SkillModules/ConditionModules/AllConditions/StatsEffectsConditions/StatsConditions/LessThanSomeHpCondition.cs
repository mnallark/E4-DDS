namespace Fire_Emblem_Model;

public class LessThanSomeHpCondition : Condition
{
    private readonly double _targetHp;
    public LessThanSomeHpCondition(double targetHp)
    {
        _targetHp = targetHp;
    }
    
    public override bool DoesItHold(Unit unit)
    {
        return unit.HP <= unit.MaxHP * _targetHp;
    }
}