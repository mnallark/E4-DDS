namespace Fire_Emblem_Model;

public class MoreThanSomeHpCondition : Condition
{
    private readonly double _targetHp;
    public MoreThanSomeHpCondition(double targetHp)
    {
        _targetHp = targetHp;
    }
    
    public override bool DoesItHold(Unit unit)
    {
        return unit.HP >= unit.Opponent.HP + _targetHp;
    }
}