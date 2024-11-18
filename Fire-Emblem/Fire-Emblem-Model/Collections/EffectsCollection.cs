namespace Fire_Emblem_Model;

public class EffectsCollection
{
    private readonly List<Effect> _effectsCollection = new();

    public void Append(Effect effect)
        => _effectsCollection.Add(effect);

    public void AppendRange(IEnumerable<Effect> effects)
        => _effectsCollection.AddRange(effects);
    
    public List<Effect> GetAllEffects()
    {
        var orderedEffects = OrderEffectsStep();
        return ToList(orderedEffects);
    }

    private IOrderedEnumerable<Effect> OrderEffectsStep()
        => _effectsCollection.OrderBy(effect => effect.GetEffectType())
            .ThenBy(effect => effect.GetStatType());

    private List<Effect> ToList(IOrderedEnumerable<Effect> orderedEffects)
        => orderedEffects.ToList();
    
    public void DeleteEffectsByType(EffectType effectType)
        => _effectsCollection.RemoveAll(effect => effect.GetEffectType() == effectType);
    
    public bool ContainsEffectType(EffectType effectType, StatType statType)
    {
        return _effectsCollection.Any(effect => 
            effect.GetEffectType() == effectType && effect.GetStatType() == statType);
    }
    
    public void Clear()
        => _effectsCollection.Clear();
}