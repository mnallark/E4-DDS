namespace Fire_Emblem_Model;

public static class EffectTypeExtensions
{
    public static bool IsStatEffect(this EffectType effectType)
    {
        return effectType == EffectType.Bonus ||
               effectType == EffectType.BonusOnFirstAttack ||
               effectType == EffectType.BonusOnFollowUp ||
               effectType == EffectType.HpBonus ||
               effectType == EffectType.Penalty ||
               effectType == EffectType.PenaltyOnFirstAttack ||
               effectType == EffectType.PenaltyOnFollowUp ||
               effectType == EffectType.NeutralizationBonus ||
               effectType == EffectType.NeutralizationPenalty;
    }
    
    public static bool IsDamageEffect(this EffectType effectType)
    {
        return IsDamageExtraEffect(effectType) ||
               IsPercentageDamageReductionEffect(effectType) ||
               IsDamageAbsoluteReductionEffect(effectType);
    }
    
    public static bool IsDamageExtraEffect(this EffectType effectType)
    {
        return effectType == EffectType.DamageExtra ||
               effectType == EffectType.DamageExtraOnFirstAttack ||
               effectType == EffectType.DamageExtraOnFollowUp;
    }
    
    public static bool IsPercentageDamageReductionEffect(this EffectType effectType)
    {
        return effectType == EffectType.PercentageDamageReduction ||
               effectType == EffectType.PercentageDamageReductionOnFirstAttack ||
               effectType == EffectType.PercentageDamageReductionOnFollowUp;
    }
    
    public static bool IsDamageAbsoluteReductionEffect(this EffectType effectType)
    {
        return effectType == EffectType.DamageReduction;
    }
    
    public static bool IsHpModificationEffect(this EffectType effectType)
    {
        return effectType == EffectType.HpPercentageRecovery ||
               effectType == EffectType.HpRecoveryPostCombat ||
               effectType == EffectType.HpReductionPostCombat;
    }
    
    public static bool IsCounterattackEffect(this EffectType effectType)
    {
        return effectType == EffectType.CounterattackDenial ||
               effectType == EffectType.CounterattackNegationDenial;
    }
    
    public static bool IsEffectWithoutPreAnnouncementEstablished(this EffectType effectType)
    {
        return effectType == EffectType.HpBonus ||
               effectType == EffectType.HpReductionPreCombat ||
               effectType == EffectType.HpRecoveryPostCombat ||
               effectType == EffectType.HpReductionPostCombat;
    }
}