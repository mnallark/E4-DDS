namespace Fire_Emblem_Model;

public class FlowEffectsFactory
{
    private const int _speedThreshold = 10;
    private const double _statMultiplier = 0.7;
    private const int _maxChangeAmount = 7;
    private const int _minChangeAmount = 0;

    private readonly StatType _targetStatType;
    
    public FlowEffectsFactory(StatType targetStatType)
    {
        _targetStatType = targetStatType;
    }
    
    public List<Effect> Create(Unit unit)
    {
        var effects = new List<Effect>();
        AddEffects(effects, unit);

        return effects;
    }

    private void AddEffects(List<Effect> effects, Unit unit)
    {
        if (CheckSpeedConditionHolds(unit))
        {
            int effectsChangeAmount = CalculateEffectChangeAmount(unit);
            
            effects.Add(new DamageExtraEffect(effectsChangeAmount));
            effects.Add(new DamageReductionEffect(effectsChangeAmount));
        }
    } 

    private bool CheckSpeedConditionHolds(Unit unit)
    {
        return unit.Spd >= unit.Opponent.Spd - _speedThreshold;
    }

    private int CalculateEffectChangeAmount(Unit unit)
    {
        double changeAmount = GetStatChangeAmount(unit);

        return GetFinalChangeAmount(changeAmount);
    }

    private double GetStatChangeAmount(Unit unit)
    {
        return _targetStatType switch
        {
            StatType.Res => CalculateResistanceChange(unit),
            StatType.Def => CalculateDefenseChange(unit),
            _ => _minChangeAmount
        };
    }

    private double CalculateResistanceChange(Unit unit)
    {
        return (unit.Res - unit.Opponent.Res) * _statMultiplier;
    }

    private double CalculateDefenseChange(Unit unit)
    {
        return (unit.Def - unit.Opponent.Def) * _statMultiplier;
    }

    private int GetFinalChangeAmount(double changeAmount)
    {
        if (changeAmount > _maxChangeAmount)
            return _maxChangeAmount;

        return Convert.ToInt32(Math.Floor(Math.Max(changeAmount, 0)));
    }
}