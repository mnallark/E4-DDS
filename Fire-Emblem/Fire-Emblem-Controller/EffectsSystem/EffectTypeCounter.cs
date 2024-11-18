namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;

public static class EffectTypeCounter
{
    public static double CountEffectsByType(Unit unit, EffectType effectType)
    {
        EffectsSummaryCollection effectsSummary = SummarizeEffects(unit);
        var effects = GetEffectsByType(effectsSummary, effectType);
        
        return SumEffectChangeAmounts(effects);
    }
    
    private static EffectsSummaryCollection SummarizeEffects(Unit unit)
    {
        EffectSummarizer effectSummarizer = new EffectSummarizer(unit);
        return effectSummarizer.SummarizeEffects();
    }
    
    private static IEnumerable<(EffectType effectType, StatType statType, double changeAmount)> GetEffectsByType(EffectsSummaryCollection effectsSummary, EffectType effectType)
    {
        return effectsSummary.GetEffectsByType(effectType);
    }
    
    private static double SumEffectChangeAmounts(IEnumerable<(EffectType effectType, StatType statType, double changeAmount)> effects)
    {
        return effects.Sum(effect => effect.changeAmount);
    }

    public static double CountEffectsTypeChangeAmount(Unit unit, EffectType effectType)
    {
        EffectsSummaryCollection effectsSummary = SummarizeEffects(unit);
        double amountOfEffectsByType = 0;

        foreach (var (statType, changeAmount) in effectsSummary.GetStatTypesDictionary(effectType))
        {
            if (!CheckIsEffectNeutralized(unit, effectType, statType))
            {
                amountOfEffectsByType += changeAmount;
            }
        }

        return amountOfEffectsByType;
    }

    private static bool CheckIsEffectNeutralized(Unit unit, EffectType effectType, StatType statType)
    {
        var neutralizationType = NeutralizationPair.GetNeutralizationEffect(effectType);
        return unit.EffectsCollection.ContainsEffectType(neutralizationType, statType);
    }
}