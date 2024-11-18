namespace Fire_Emblem_Model;

public class ModifiedStatsToApplyOnUnit
{
    private readonly Dictionary<StatType, int> _modifiedStatsToApplyOnUnit = new();

    public void SetModifiedStatToApply(StatType statType, int modifiedAmount)
        => _modifiedStatsToApplyOnUnit[statType] = modifiedAmount;

    public int GetModifiedAmount(StatType statType)
        => _modifiedStatsToApplyOnUnit[statType];
}