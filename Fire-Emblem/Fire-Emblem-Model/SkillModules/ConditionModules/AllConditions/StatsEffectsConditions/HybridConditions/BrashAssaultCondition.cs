namespace Fire_Emblem_Model;

public class BrashAssaultCondition : Condition
{
    private const double _hpTargetPercentage = 0.99;
    public override bool DoesItHoldAfterStatsEffectsApplied(Unit unit)
    {
        if (unit.StartsCombat)
        {
            if (CheckUnitHpTarget(unit) || unit.Opponent.HP == unit.Opponent.MaxHP)
                return true;
        }

        return false;
    }

    private bool CheckUnitHpTarget(Unit unit)
    {
        return Math.Round(Convert.ToDouble(unit.HP) / Convert.ToDouble(unit.MaxHP), 2) <= _hpTargetPercentage;
    }
}