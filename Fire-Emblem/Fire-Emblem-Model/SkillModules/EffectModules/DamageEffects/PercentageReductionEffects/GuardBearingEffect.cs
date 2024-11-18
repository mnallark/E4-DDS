namespace Fire_Emblem_Model;

public class GuardBearingEffect : Effect
{
    private const double _conditionMetReduction = 60;
    private const double _defaultReduction = 30;

    public override EffectType GetEffectType()
    {
        return EffectType.PercentageDamageReduction;
    }

    public override double GetChangeAmount(Unit unit)
    {
        return CheckConditionApplies(unit) ? _conditionMetReduction : _defaultReduction;
    }

    private bool CheckConditionApplies(Unit unit)
    {
        return (unit.StartsCombat && unit.IsFirstCombatAsInitiator) ||
               (unit.Opponent.StartsCombat && unit.IsFirstCombatAsDefender);
    }
}