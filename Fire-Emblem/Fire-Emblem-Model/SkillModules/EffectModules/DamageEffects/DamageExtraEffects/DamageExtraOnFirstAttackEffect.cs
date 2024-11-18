namespace Fire_Emblem_Model;

public class DamageExtraOnFirstAttackEffect : Effect
{
    public DamageExtraOnFirstAttackEffect(int damageExtra)
    {
        ChangeAmount = damageExtra;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.DamageExtraOnFirstAttack;
    }
}