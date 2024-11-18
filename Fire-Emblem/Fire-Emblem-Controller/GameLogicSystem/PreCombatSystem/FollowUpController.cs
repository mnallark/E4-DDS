using Fire_Emblem_Model;
namespace Fire_Emblem_Controller;

public class FollowUpController
{
    private const int SpeedDifferenceForFollowUp = 5;

    public void DetermineFollowUpOnUnits(Unit attackerUnit, Unit defenderUnit)
    {
        if (CheckSatisfyFollowUpConditions(attackerUnit))
            attackerUnit.ChangeDoesFollowUpState();
    
        if (CheckSatisfyFollowUpConditions(defenderUnit))
            defenderUnit.ChangeDoesFollowUpState();
    }

    private bool CheckSatisfyFollowUpConditions(Unit unit)
    {
        ProcessNegationFollowUpEffectsCancellation(unit);

        if (CheckFollowUpGuaranteed(unit))
            return true;

        return !CheckIsAnyFollowUpNeutralization(unit) && CheckStatCondition(unit);
    }
    
    private void ProcessNegationFollowUpEffectsCancellation(Unit unit)
    {
        ProcessNegationFollowUpEffect(unit, EffectType.NegationFollowUpGuaranteed, EffectType.FollowUpGuaranteed);
        ProcessNegationFollowUpEffect(unit, EffectType.NegationFollowUpNeutralization, EffectType.FollowUpNeutralization);
    }

    private void ProcessNegationFollowUpEffect(Unit unit, EffectType negationEffectType, EffectType followUpEffectType)
    {
        if (CheckUnitHasNegationEffect(unit, negationEffectType))
            DeleteEffectsByType(unit, followUpEffectType);
    }

    private bool CheckUnitHasNegationEffect(Unit unit, EffectType effectType)
    {
        return EffectTypeCounter.CountEffectsByType(unit, effectType) > 0;
    }

    private void DeleteEffectsByType(Unit unit, EffectType effectType)
    {
        unit.EffectsCollection.DeleteEffectsByType(effectType);
    }
    
    private bool CheckFollowUpGuaranteed(Unit unit)
    {
        double followUpGuaranteedCount = EffectTypeCounter.CountEffectsByType(unit, EffectType.FollowUpGuaranteed);
        double followUpNeutralizationCount = EffectTypeCounter.CountEffectsByType(unit, EffectType.FollowUpNeutralization);
    
        return followUpGuaranteedCount > followUpNeutralizationCount;
    }

    private bool CheckIsAnyFollowUpNeutralization(Unit unit)
    {
        return EffectTypeCounter.CountEffectsByType(unit, EffectType.FollowUpNeutralization) > 0;
    }
    
    private bool CheckStatCondition(Unit unit)
    {
        return unit.Spd - unit.Opponent.Spd >= SpeedDifferenceForFollowUp;
    }
}