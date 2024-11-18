namespace Fire_Emblem_Model;

public class UnitHasLostSomeHpCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        return unit.MaxHP > unit.HP;
    }
}