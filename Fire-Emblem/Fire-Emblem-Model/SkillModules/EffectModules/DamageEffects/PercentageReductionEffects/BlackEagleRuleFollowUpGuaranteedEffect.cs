namespace Fire_Emblem_Model;

public class BlackEagleRuleFollowUpGuaranteedEffect : Effect
{
    private const double _damageReductionAmount = 80;
    private const double _minChangeAmount = 0;

    public override EffectType GetEffectType()
    {
        return EffectType.PercentageDamageReductionOnFollowUp;
    }

    public override double GetChangeAmount(Unit unit)
    {
        return CheckConditionHolds(unit) ? _damageReductionAmount : _minChangeAmount;
    }

    private bool CheckConditionHolds(Unit unit)
    {
        return unit.Opponent.StartsCombat;
    }
}