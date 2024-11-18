namespace Fire_Emblem_Model;

public class DamageExtraOnFollowUpEffect : Effect
{
    public DamageExtraOnFollowUpEffect(int damageExtra)
    {
        ChangeAmount = damageExtra;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.DamageExtraOnFollowUp;
    }
}