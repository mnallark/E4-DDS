namespace Fire_Emblem_Model;

public static class NeutralizationPair
{
    private static readonly Dictionary<EffectType, EffectType> _neutralizationPairs = new()
    {
        { EffectType.Bonus, EffectType.NeutralizationBonus },
        { EffectType.HpBonus, EffectType.NeutralizationBonus },
        { EffectType.BonusOnFirstAttack, EffectType.NeutralizationBonus },
        { EffectType.BonusOnFollowUp, EffectType.NeutralizationBonus },
        { EffectType.Penalty, EffectType.NeutralizationPenalty },
        { EffectType.PenaltyOnFirstAttack, EffectType.NeutralizationPenalty },
        { EffectType.PenaltyOnFollowUp, EffectType.NeutralizationPenalty },
    };

    public static EffectType GetNeutralizationEffect(EffectType effectType)
    {
        if (_neutralizationPairs.TryGetValue(effectType, out var neutralizer))
        {
            return neutralizer;
        }
        throw new ArgumentException($"No neutralizer found for effect type {effectType}");
    }
}