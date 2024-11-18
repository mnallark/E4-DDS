namespace Fire_Emblem_Model;

public class PercentageDamageExtraEffectByStat : Effect
{
    private readonly StatType _targetStatType;
    private readonly double _targetPercentage;

    public PercentageDamageExtraEffectByStat(StatType statType, double targetPercentage)
    {
        _targetStatType = statType;
        _targetPercentage = targetPercentage;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.DamageExtra;
    }
    
    public override double GetChangeAmount(Unit unit)
    {
        switch (_targetStatType)
        {
            case StatType.Atk:
                return Math.Floor(unit.Opponent.Atk * _targetPercentage);

            case StatType.Def:
                return Math.Floor(unit.Opponent.Def * _targetPercentage);
            
            default:
                throw new InvalidStatType();
        }
    }
}