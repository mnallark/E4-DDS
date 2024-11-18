using Fire_Emblem_Model;
namespace Fire_Emblem_Controller;

public class EffectSummarizer
{
    private readonly Unit _unit;
    private readonly EffectsSummaryCollection _effectsSummary;
    private const double _initialAmount = 1.0;
    private const double _baseAmount = 0;

    public EffectSummarizer(Unit unit)
    {
        _unit = unit;
        _effectsSummary = new EffectsSummaryCollection();
    }
    
    public EffectsSummaryCollection SummarizeEffects()
    {
        var orderedEffects = _unit.EffectsCollection.GetAllEffects();
        
        foreach (var effect in orderedEffects)
        {
            AddEffectToSummary(effect);
        }

        return _effectsSummary;
    }

    private void AddEffectToSummary(Effect effect)
    {
        var effectType = effect.GetEffectType();
        var statType = effect.GetStatType();
        var changeAmount = effect.GetChangeAmount(_unit);

        EnsureEffectTypeInitialized(effectType);
        EnsureStatTypeInitialized(effectType, statType, changeAmount);
        UpdateEffectStats(effectType, statType, changeAmount);
    }
    
    private void EnsureEffectTypeInitialized(EffectType effectType)
    {
        if (!_effectsSummary.ContainsEffect(effectType))
        {
            _effectsSummary.AppendEffect(effectType);
        }
    }
    
    private void EnsureStatTypeInitialized(EffectType effectType, StatType statType, double changeAmount)
    {
        if (!_effectsSummary.ContainsEffectStatType(effectType, statType))
        {
            if (effectType.IsPercentageDamageReductionEffect() && changeAmount != _baseAmount)
                _effectsSummary.SetEffectStatAmount(effectType, statType, _initialAmount);

            else if (effectType.IsCounterattackEffect())
                _effectsSummary.SetEffectStatAmount(effectType, statType, _initialAmount);

            else
                _effectsSummary.SetEffectStatAmount(effectType, statType, _baseAmount);
        }
    }
    
    private void UpdateEffectStats(EffectType effectType, StatType statType, double changeAmount)
    {
        if (effectType.IsPercentageDamageReductionEffect())
            MultiplyStatValue(effectType, statType, changeAmount);
        
        else
            IncrementStatValue(effectType, statType, changeAmount);
    }
    
    private void MultiplyStatValue(EffectType effectType, StatType statType, double changeAmount)
    {
        if (changeAmount != _baseAmount)
        {
            double actualSummaryValue = CalculateActualSummaryValue(effectType, statType);
            double newValue = CalculateNewStatValue(statType, actualSummaryValue, changeAmount);

            _effectsSummary.SetEffectStatAmount(effectType, statType, newValue);
        }
    }
    
    private double CalculateActualSummaryValue(EffectType effectType, StatType statType)
    {
        double actualSummaryValuePercentage = _initialAmount;
        double effectStatAmount = _effectsSummary.GetEffectStatChangeAmount(effectType, statType);
            
        if (effectStatAmount != _initialAmount)
            actualSummaryValuePercentage = _initialAmount - effectStatAmount / 100;

        return actualSummaryValuePercentage;
    }
    
    private double CalculateNewStatValue(StatType statType, double actualSummaryValue, double changeAmount)
    {
        double reductionOfDamageReductionPercentage = GetReductionDamageReductionChangeAmount(statType);
        double adjustedChangeAmount = changeAmount * reductionOfDamageReductionPercentage;
        double decimalChangeAmountPercentage = _initialAmount - adjustedChangeAmount / 100;
        
        return Math.Round((1 - actualSummaryValue * decimalChangeAmountPercentage) * 100, 9);
    }
    
    private double GetReductionDamageReductionChangeAmount(StatType statType)
    {
        if (_effectsSummary.ContainsEffect(EffectType.ReductionPercentageDamageReduction))
            return _effectsSummary.GetEffectStatChangeAmount(EffectType.ReductionPercentageDamageReduction, statType);
       
        return _initialAmount;
    }
        
    private void IncrementStatValue(EffectType effectType, StatType statType, double changeAmount)
    {
        _effectsSummary.IncrementEffectStatValue(effectType, statType, changeAmount);
    }
}
