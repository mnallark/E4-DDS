namespace Fire_Emblem_Model;

public class DamageReductionWithStatCondition : Effect 
{
    private const int _statMultiplier = 4;
    private const double _maxReductionAmount = 40;
    private const double _minChangeAmount = 0;
    private readonly StatType _targetStatType;

    public DamageReductionWithStatCondition(StatType targetStatType)
    {
        _targetStatType = targetStatType;
    }

    public override EffectType GetEffectType()
    {
        return EffectType.PercentageDamageReduction;
    }

    public override double GetChangeAmount(Unit unit)
    {
        return CalculateDamageReduction(unit, _targetStatType);
    }

    private double CalculateDamageReduction(Unit unit, StatType statType)
    {
        int unitStatValue = GetUnitStatValue(unit, statType);
        int opponentStatValue = GetUnitStatValue(unit.Opponent, statType);

        return unitStatValue > opponentStatValue
            ? Math.Min((unitStatValue - opponentStatValue) * _statMultiplier, _maxReductionAmount)
            : _minChangeAmount;
    }

    private int GetUnitStatValue(Unit unit, StatType statType)
    {
        return statType switch
        {
            StatType.Spd => unit.Spd,
            StatType.Def => unit.Def,
            _ => throw new InvalidStatType()
        };
    }
}