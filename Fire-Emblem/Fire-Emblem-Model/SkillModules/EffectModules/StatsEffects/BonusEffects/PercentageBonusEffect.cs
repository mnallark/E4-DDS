namespace Fire_Emblem_Model;

public class PercentageBonusEffect : Effect
{
    private readonly int _oneHundred = 100;

    public PercentageBonusEffect(StatType targetStat, int targetPercentage)
    {
        TargetStat = targetStat;
        ChangeAmount = targetPercentage;
    }

    public override double GetChangeAmount(Unit unit)
    {
        return CalculatePercentageBonus(unit);
    }

    private double CalculatePercentageBonus(Unit unit)
    {
        return Math.Floor(unit.BaseSpd * ChangeAmount / _oneHundred);
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.Bonus;
    }
}