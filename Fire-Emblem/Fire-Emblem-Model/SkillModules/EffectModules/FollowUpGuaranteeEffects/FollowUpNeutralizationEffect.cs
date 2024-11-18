namespace Fire_Emblem_Model;

public class FollowUpNeutralizationEffect : Effect
{
    private const double _minChangeAmount = 1.0;

    public override EffectType GetEffectType()
    {
        return EffectType.FollowUpNeutralization;
    }
    
    public override double GetChangeAmount(Unit unit)
    {
        return _minChangeAmount;
    }
}