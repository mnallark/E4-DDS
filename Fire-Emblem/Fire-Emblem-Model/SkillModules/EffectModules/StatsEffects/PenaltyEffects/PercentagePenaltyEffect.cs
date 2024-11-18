namespace Fire_Emblem_Model;

public class PercentagePenaltyEffect : Effect
{
    private readonly int _oneHundred = 100;

    public PercentagePenaltyEffect(StatType targetStat, int targetPercentage)
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
        return -Math.Floor(unit.BaseRes * ChangeAmount / _oneHundred);
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.Penalty;
    }

    public override void AddEffectToUnit(Unit unit)
    {
        
        unit.Opponent.AddEffect(this);
    }
}