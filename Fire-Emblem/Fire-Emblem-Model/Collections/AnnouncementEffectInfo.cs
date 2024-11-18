namespace Fire_Emblem_Model;

public class AnnouncementEffectInfo
{
    private readonly Dictionary<string, object> _effectInfo = new();

    public AnnouncementEffectInfo(EffectType effectType, StatType statType)
    {
        _effectInfo["EffectType"] = effectType;
        _effectInfo["StatType"] = statType;
    }

    public EffectType GetEffectType()
        => (EffectType)_effectInfo["EffectType"];
    
    public StatType GetStatType()
        => (StatType)_effectInfo["StatType"];
}