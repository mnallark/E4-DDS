namespace Fire_Emblem_Model;

public class DamageExtraEffect : Effect
{
    public override EffectType GetEffectType()
    {
        return EffectType.DamageExtra;
    }
    
    public DamageExtraEffect(int damageExtra)
    {
        ChangeAmount = damageExtra;
    }
}