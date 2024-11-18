namespace Fire_Emblem_Model;

public class DamageReductionEffect : Effect
{
    public DamageReductionEffect(int changeAmount)
    {
        ChangeAmount = changeAmount;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.DamageReduction;
    }
}