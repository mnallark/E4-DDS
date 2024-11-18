namespace Fire_Emblem_Model;

public class SoulbladeFactory
{
    public List<Effect> Create(Unit unit)
    {
        List<Effect> effects = new List<Effect>();

        int baseDef = unit.Opponent.BaseDef;
        int baseRes = unit.Opponent.BaseRes;
        int average = CalculateAverage(baseDef, baseRes);

        AddEffect(effects, StatType.Def, baseDef, average);
        AddEffect(effects, StatType.Res, baseRes, average);

        return effects;
    }

    private int CalculateAverage(int baseDef, int baseRes)
    {
        return (baseDef + baseRes) / 2;
    }

    private void AddEffect(List<Effect> effects, StatType statType, int baseValue, int average)
    {
        int changeAmount = average - baseValue;

        if (changeAmount > 0)
        {
            effects.Add(new BonusForOpponentEffect(statType, changeAmount));
        }
        else if (changeAmount < 0)
        {
            effects.Add(new PenaltyEffect(statType, -changeAmount));
        }
    }
}