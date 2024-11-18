namespace Fire_Emblem_Model;

public class NegationFollowUpNeutralizationEffect : Effect
{
    private const double _minChangeAmount = 1.0;

    public override EffectType GetEffectType()
    {
        return EffectType.NegationFollowUpNeutralization;
    }
    
    public override double GetChangeAmount(Unit unit)
    {
        return _minChangeAmount;
    }
}