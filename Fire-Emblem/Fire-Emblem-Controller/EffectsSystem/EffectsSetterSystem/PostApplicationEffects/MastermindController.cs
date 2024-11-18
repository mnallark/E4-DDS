namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;

public class MastermindController
{
    private readonly Unit _unit;
    private const double _predefinedEffectPercentage = 0.8;
    
    public MastermindController(Unit unit)
    {
        _unit = unit;
    }
    
    public void AddEffectToUnit()
    {
        if (_unit.StartsCombat)
        {
            int changeAmount = CalculateChangeAmount();
            
            Effect effect = new DamageExtraEffect(changeAmount);
            effect.AddEffectToUnit(_unit);
        }
    }
    
     
    private int CalculateChangeAmount()
    {
        double amountOfBonusEffects = EffectTypeCounter.CountEffectsTypeChangeAmount(_unit, EffectType.Bonus);
        double amountOfPenaltyEffectsFromOpponent = EffectTypeCounter.CountEffectsTypeChangeAmount(_unit.Opponent, EffectType.Penalty);

        double changeAmount = Math.Floor((amountOfBonusEffects - amountOfPenaltyEffectsFromOpponent) * _predefinedEffectPercentage);

        return Convert.ToInt32(changeAmount);
    }
}