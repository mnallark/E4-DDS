namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;

public class UnitDamageEffectsApplier
{
    private EffectsToApplyCollection _effectsToApply;

    public UnitModifier GetUnitAffectedByDamageEffects(Unit unit)
    {
        _effectsToApply = new EffectsToApplyCollection();

        AddCommonDamageEffects();
        AddConditionalDamageEffects(unit);

        return ApplyEffectsToUnit(unit);
    }

    private void AddCommonDamageEffects()
    {
        _effectsToApply.Append(EffectType.DamageExtra);
        _effectsToApply.Append(EffectType.PercentageDamageReduction);
        _effectsToApply.Append(EffectType.DamageReduction);
    }

    private void AddConditionalDamageEffects(Unit unit)
    {
        if (!unit.HasAttackedBefore)
        {
            AddFirstAttackEffects();
        }
        else if (unit.DoesTheFollowUp)
        {
            AddFollowUpAttackEffects();
        }
    }

    private void AddFirstAttackEffects()
    {
        _effectsToApply.Append(EffectType.DamageExtraOnFirstAttack);
        _effectsToApply.Append(EffectType.PercentageDamageReductionOnFirstAttack);
    }

    private void AddFollowUpAttackEffects()
    {
        _effectsToApply.Append(EffectType.DamageExtraOnFollowUp);
        _effectsToApply.Append(EffectType.PercentageDamageReductionOnFollowUp);
    }

    private UnitModifier ApplyEffectsToUnit(Unit unit)
    {
        var modifiedUnit = new UnitModifier(unit);
        return modifiedUnit.GetUnitAffectedBy(_effectsToApply);
    }
}
