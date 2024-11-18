namespace Fire_Emblem_Model;

public class OpponentStartsCombatAndUnitHpPercentageMoreThanCondition : Condition
{
    private readonly double _targetHP;
    public OpponentStartsCombatAndUnitHpPercentageMoreThanCondition(double targetHP)
    {
        _targetHP = targetHP;
    }
    
    public override bool DoesItHold(Unit unit)
    {
        if (unit.Opponent.StartsCombat)
            return Math.Round(Convert.ToDouble(unit.HP) / Convert.ToDouble(unit.MaxHP), 2) >= _targetHP;

        return false;
    }
}