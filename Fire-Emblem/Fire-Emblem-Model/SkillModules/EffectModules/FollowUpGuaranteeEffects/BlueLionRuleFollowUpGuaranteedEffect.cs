namespace Fire_Emblem_Model;

public class BlueLionRuleFollowUpGuaranteedEffect : Effect
{
    private const double _minChangeAmount = 1.0;
    private const int _baseChangeAmount = 0;

    public override EffectType GetEffectType()
    {
        return EffectType.FollowUpGuaranteed;
    }
    
    public override double GetChangeAmount(Unit unit)
    {
        if (CheckConditionHolds(unit))
            return _minChangeAmount;

        return _baseChangeAmount;
    }

    private bool CheckConditionHolds(Unit unit)
    {
        return unit.Opponent.StartsCombat;
    }
}