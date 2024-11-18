namespace Fire_Emblem_Model;

public class EffectsToApplyCollection
{
    private readonly List<EffectType> _effectsToApply = new();

    public void Append(EffectType effectType)
        => _effectsToApply.Add(effectType);

    public List<EffectType> GetAllEffects()
    {
        return _effectsToApply.OrderBy(effectType => effectType).ToList();
    }
}