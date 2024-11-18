namespace Fire_Emblem_Model;

public class BackAtYouEffect : Effect
{
    private const int _effectDividisor = 2;

    public override EffectType GetEffectType()
    {
        return EffectType.DamageExtra;
    }
    
    public override double GetChangeAmount(Unit unit)
    {
        return (unit.MaxHP - unit.HP) / _effectDividisor;
    }
}