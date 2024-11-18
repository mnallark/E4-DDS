namespace Fire_Emblem_Model;

public class PerceptiveEffect : Effect
{
    private const int _effectDividisor = 4;
    private const int _effectSum = 12;

    public PerceptiveEffect(StatType targetStat)
    {
        TargetStat = targetStat;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.Bonus;
    }
    
    public override double GetChangeAmount(Unit unit)
    {
        ChangeAmount = unit.BaseSpd / _effectDividisor + _effectSum;
        
        return ChangeAmount;
    }
}