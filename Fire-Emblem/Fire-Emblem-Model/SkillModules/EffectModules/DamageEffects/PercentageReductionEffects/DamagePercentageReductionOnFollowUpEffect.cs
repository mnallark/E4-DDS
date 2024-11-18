namespace Fire_Emblem_Model;

public class DamagePercentageReductionOnFollowUpEffect : Effect
{
    public override EffectType GetEffectType()
    {
        return EffectType.PercentageDamageReductionOnFollowUp;
    }

    public DamagePercentageReductionOnFollowUpEffect(double changeAmount)
    {
        ChangeAmount = changeAmount;
    }
}