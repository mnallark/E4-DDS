namespace Fire_Emblem_Model;

public class CounterattackNegationDenialEffect : Effect
{
    private const double _minChangeAmount = 1;

    public override EffectType GetEffectType()
    {
        return EffectType.CounterattackNegationDenial;
    }
    
    public override double GetChangeAmount(Unit unit)
    {
        return _minChangeAmount;
    }
}