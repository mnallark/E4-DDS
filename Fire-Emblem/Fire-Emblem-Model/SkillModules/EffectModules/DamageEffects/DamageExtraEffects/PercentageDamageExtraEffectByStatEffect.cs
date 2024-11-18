namespace Fire_Emblem_Model;

public class PercentageDamageExtraEffectByStatEffect : Effect
{
    private readonly int _targetPercentage;
    private readonly int _oneHundred = 100;

    public PercentageDamageExtraEffectByStatEffect(StatType targetStatType, int targetPercentage)
    {
        TargetStat = targetStatType;
        _targetPercentage = targetPercentage;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.DamageExtra;
    }
    
    public override double GetChangeAmount(Unit unit)
    {
        switch (TargetStat)
        {
            case StatType.Atk:
                ChangeAmount = unit.Atk * _targetPercentage / _oneHundred;
                break;
        }
        return ChangeAmount;
    }
}