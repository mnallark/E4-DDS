namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;

public class CounterattackEffectsProcessor
{ 
    public void ProcessCounterattackEffectsOnUnits(Unit attackerUnit, Unit defenderUnit)
    {
        ProcessCounterattackEffects(attackerUnit);
        ProcessCounterattackEffects(defenderUnit);
    }
    
    private void ProcessCounterattackEffects(Unit unit)
    {
        double amountOfCounterattackDenial = EffectTypeCounter.CountEffectsByType(unit, EffectType.CounterattackDenial);
        double amountOfCounterattackNegationDenial = EffectTypeCounter.CountEffectsByType(unit, EffectType.CounterattackNegationDenial);

        AdjustCounterattackEffects(unit, amountOfCounterattackDenial, amountOfCounterattackNegationDenial);
    }
    
    private void AdjustCounterattackEffects(Unit unit, double amountOfCounterattackDenial, double amountOfCounterattackNegationDenial)
    {
        if (CheckShouldDeleteCounterattackNegationDenial(amountOfCounterattackDenial, amountOfCounterattackNegationDenial))
        {
            DeleteEffectsByType(unit, EffectType.CounterattackNegationDenial);
        }
        else if (CheckShouldDeleteCounterattackDenial(amountOfCounterattackDenial, amountOfCounterattackNegationDenial))
        {
            DeleteEffectsByType(unit, EffectType.CounterattackDenial);
        }
    }

    private bool CheckShouldDeleteCounterattackNegationDenial(double amountOfCounterattackDenial, double amountOfCounterattackNegationDenial)
    {
        return amountOfCounterattackDenial == 0 || amountOfCounterattackDenial > amountOfCounterattackNegationDenial;
    }

    private void DeleteEffectsByType(Unit unit, EffectType effectType)
    {
        unit.EffectsCollection.DeleteEffectsByType(effectType);
    }
    
    private bool CheckShouldDeleteCounterattackDenial(double amountOfCounterattackDenial, double amountOfCounterattackNegationDenial)
    {
        return amountOfCounterattackDenial > 0 && amountOfCounterattackDenial <= amountOfCounterattackNegationDenial;
    }
}