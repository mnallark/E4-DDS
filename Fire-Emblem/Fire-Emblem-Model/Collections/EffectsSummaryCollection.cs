namespace Fire_Emblem_Model;

public class EffectsSummaryCollection
{
    private readonly Dictionary<EffectType, Dictionary<StatType, double>> _effectsSummary = new();

    public bool ContainsEffect(EffectType effectType)
        => _effectsSummary.ContainsKey(effectType);

    public void AppendEffect(EffectType effectType)
        => _effectsSummary[effectType] = new Dictionary<StatType, double>();
    
    public bool ContainsEffectStatType(EffectType effectType, StatType statType)
        => _effectsSummary[effectType].ContainsKey(statType);

    public void SetEffectStatAmount(EffectType effectType, StatType statType, double initialAmount)
        => _effectsSummary[effectType][statType] = initialAmount;

    public double GetEffectStatChangeAmount(EffectType effectType, StatType statType)
        => _effectsSummary[effectType][statType];

    public void IncrementEffectStatValue(EffectType effectType, StatType statType, double changeAmount)
        => _effectsSummary[effectType][statType] += changeAmount;
    
    public IEnumerable<EffectType> GetEffectTypes()
        => _effectsSummary.Keys;
    
    public IEnumerable<StatType> GetStatTypes(EffectType effectType)
        => _effectsSummary[effectType].Keys;
    
    public Dictionary<StatType, double> GetStatTypesDictionary(EffectType effectType)
        => _effectsSummary.TryGetValue(effectType, out var statTypes) ? statTypes : new Dictionary<StatType, double>();
    
    public IEnumerable<(EffectType effectType, StatType statType, double changeAmount)> 
        GetEffectsByType(EffectType targetEffectType)
    {
        var filteredEffects = FilterEffectsByType(targetEffectType);
        return SelectEffects(filteredEffects);
    }

    private IEnumerable<KeyValuePair<EffectType, Dictionary<StatType, double>>> 
        FilterEffectsByType(EffectType targetEffectType)
    {
        return _effectsSummary.Where(e => e.Key == targetEffectType);
    }

    private IEnumerable<(EffectType effectType, StatType statType, double changeAmount)> 
        SelectEffects(IEnumerable<KeyValuePair<EffectType, Dictionary<StatType, double>>> filteredEffects)
    {
        return filteredEffects.SelectMany(e => e.Value, (effect, changes) => (effect.Key, changes.Key, changes.Value));
    }
}