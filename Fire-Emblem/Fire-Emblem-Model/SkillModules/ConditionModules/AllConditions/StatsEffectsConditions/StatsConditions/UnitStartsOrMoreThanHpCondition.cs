namespace Fire_Emblem_Model;

public class UnitStartsOrMoreThanHpCondition : Condition
{
    private const double _targetHp = 0.75;
    public override bool DoesItHold(Unit unit)
    {
        double hpActualRival = unit.Opponent.HP;
        double hpTarget = unit.Opponent.MaxHP * _targetHp;
        
        return unit.Opponent.StartsCombat | hpActualRival >= hpTarget;
    }
}