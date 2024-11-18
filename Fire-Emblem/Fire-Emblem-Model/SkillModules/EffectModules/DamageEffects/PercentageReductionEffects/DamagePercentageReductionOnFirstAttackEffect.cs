namespace Fire_Emblem_Model;

public class DamagePercentageReductionOnFirstAttackEffect : Effect
{
    public override EffectType GetEffectType()
    {
        return EffectType.PercentageDamageReductionOnFirstAttack;
    }
    
    public DamagePercentageReductionOnFirstAttackEffect(double changeAmount)
    {
        ChangeAmount = changeAmount;
    }
}