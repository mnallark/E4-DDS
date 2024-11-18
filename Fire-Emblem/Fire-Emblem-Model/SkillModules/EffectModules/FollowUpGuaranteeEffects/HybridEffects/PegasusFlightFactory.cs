namespace Fire_Emblem_Model;

public class PegasusFlightFactory
{
    private const double _effectMultiplier = 0.8;
    private const int _maxChangeAmount = 8;
    private const int _effectRest = 10;
    
    public List<Effect> Create(Unit unit)
    {
        var effects = new List<Effect>();
        AddPenaltyEffects(effects, unit);

        return effects;
    }

    private void AddPenaltyEffects(List<Effect> effects, Unit unit)
    {
        int penaltyAmount = CalculatePenaltyAmount(unit);

        if (CheckSpeedConditionHolds(unit))
        {
            effects.Add(new PenaltyEffect(StatType.Atk, penaltyAmount));
            effects.Add(new PenaltyEffect(StatType.Def, penaltyAmount));
            
            AddFollowUpNeutralizationEffect(effects, unit);
        }
    }

    private int CalculatePenaltyAmount(Unit unit)
    {
        double penaltyAmount = Math.Floor((unit.BaseRes - unit.Opponent.BaseRes) * _effectMultiplier);

        if (penaltyAmount > _maxChangeAmount)
            return _maxChangeAmount;

        return Convert.ToInt32(Math.Max(penaltyAmount, 0));
    }
    
    private bool CheckSpeedConditionHolds(Unit unit)
    {
        return unit.BaseSpd >= unit.Opponent.BaseSpd - _effectRest;
    }
    
    private void AddFollowUpNeutralizationEffect(List<Effect> effects, Unit unit)
    {
        if (CheckStatConditionHolds(unit))
        {
            effects.Add(new FollowUpNeutralizationForOpponentEffect());
        }
    }

    private bool CheckStatConditionHolds(Unit unit)
    {
        return unit.Spd + unit.Res > unit.Opponent.Spd + unit.Opponent.Res;
    }
}