using Fire_Emblem_Model;
namespace Fire_Emblem_Controller;

public class UnitStatEffectsApplier
{
    private EffectsToApplyCollection _effectsToApply;

    public UnitModifier GetUnitAffectedStatEffects(Unit unit)
    {
        _effectsToApply = new EffectsToApplyCollection();
        AddConditionalOneTimeEffects(unit);
        
        return ApplyEffectsToUnit(unit);
    }

    private void AddConditionalOneTimeEffects(Unit unit)
    {
        if (!unit.HasAttackedBefore)
        {
            AddFirstAttackEffects();
        }
        else if (unit.DoesTheFollowUp)
        {
            AddFollowUpEffects();
        }
    }

    private void AddFirstAttackEffects()
    {
        _effectsToApply.Append(EffectType.BonusOnFirstAttack);
        _effectsToApply.Append(EffectType.PenaltyOnFirstAttack);
    }

    private void AddFollowUpEffects()
    {
        _effectsToApply.Append(EffectType.BonusOnFollowUp);
        _effectsToApply.Append(EffectType.PenaltyOnFollowUp);
    }

    private UnitModifier ApplyEffectsToUnit(Unit unit)
    {
        var modifiedUnit = new UnitModifier(unit);
        
        return modifiedUnit.GetUnitAffectedBy(_effectsToApply);
    }
}