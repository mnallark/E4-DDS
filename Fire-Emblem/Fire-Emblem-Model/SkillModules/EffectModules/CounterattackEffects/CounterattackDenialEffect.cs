namespace Fire_Emblem_Model;

public class CounterattackDenialEffect : Effect
{
    private const double _minChangeAmount = 1;

    public override EffectType GetEffectType()
    {
        return EffectType.CounterattackDenial;
    }

    public override double GetChangeAmount(Unit unit)
    {
        return _minChangeAmount;
    }
    
    public override void AddEffectToUnit(Unit unit)
    {
        unit.Opponent.AddEffect(this);
    }
}