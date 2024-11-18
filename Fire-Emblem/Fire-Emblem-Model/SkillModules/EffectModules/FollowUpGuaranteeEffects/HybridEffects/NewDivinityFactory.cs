namespace Fire_Emblem_Model;

public class NewDivinityFactory
{    
    private const int _effectMultiplier = 4;
    private const int _maxChangeAmount = 40;
    private const int _effectRest = 5;
    private const int _penaltyFromOwnEffect = 5;
    private const double _hpConditionFirstThreshold = 0.25;
    private const double _hpConditionSecondThreshold = 0.4;

    public List<Effect> Create(Unit unit)
    {
        var effects = new List<Effect>();
        AddEffects(effects, unit);

        return effects;
    }

    private void AddEffects(List<Effect> effects, Unit unit)
    {
        if (CheckHpConditionHolds(unit, _hpConditionFirstThreshold))
        {
            effects.Add(new PenaltyEffect(StatType.Atk, _effectRest));
            effects.Add(new PenaltyEffect(StatType.Res, _effectRest));
            
            AddDamageEffect(effects, unit);
        }
        
        AddFollowUpNeutralizationEffect(effects, unit);
    }

    private bool CheckHpConditionHolds(Unit unit, double targetHpPercentage)
    {
        return Math.Round(Convert.ToDouble(unit.HP) / Convert.ToDouble(unit.MaxHP), 2) >= targetHpPercentage;
    }
    
    private void AddDamageEffect(List<Effect> effects, Unit unit)
    {
        if (CheckResistanceConditionHolds(unit))
        {
            int damageReductionAmount = CalculateDamageReductionAmount(unit);
            effects.Add(new DamagePercentageReductionEffect(damageReductionAmount));
        }
    }
    
    private bool CheckResistanceConditionHolds(Unit unit)
    {
        return unit.Res > unit.Opponent.Res - _effectRest;
    }
    
    private int CalculateDamageReductionAmount(Unit unit)
    {
        int penaltyAmount = (unit.Res - (unit.Opponent.Res - _penaltyFromOwnEffect)) * _effectMultiplier;

        if (penaltyAmount > _maxChangeAmount)
            return _maxChangeAmount;

        return penaltyAmount;
    }

    private void AddFollowUpNeutralizationEffect(List<Effect> effects, Unit unit)
    {
        if (CheckHpConditionHolds(unit, _hpConditionSecondThreshold))
        {
            effects.Add(new FollowUpNeutralizationForOpponentEffect());
        }
    }
}