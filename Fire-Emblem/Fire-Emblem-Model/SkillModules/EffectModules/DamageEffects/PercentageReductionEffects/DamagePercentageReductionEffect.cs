namespace Fire_Emblem_Model;

public class DamagePercentageReductionEffect : Effect
{
    public DamagePercentageReductionEffect(double changeAmount)
    {
        ChangeAmount = changeAmount;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.PercentageDamageReduction;
    }
}