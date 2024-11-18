namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;

public class DivineRecreationController
{
    private readonly Unit _unit;

    public DivineRecreationController(Unit unit)
    {
        _unit = unit;
    }

    public void AddEffectToUnit()
    {
        int changeAmount = CalculateDamageChangeAmount();

        Effect effect = _unit.StartsCombat
            ? new DamageExtraOnFollowUpEffect(changeAmount)
            : new DamageExtraOnFirstAttackEffect(changeAmount);

        effect.AddEffectToUnit(_unit);
    }

    private int CalculateDamageChangeAmount()
    {
        EffectsToApplyCollection effectsBeforeReduction = GetInitialEffects();
        EffectsToApplyCollection effectsAfterReduction = GetFinalEffects();

        UnitModifier modifiedUnitBeforeReductions = GetModifiedUnit(effectsBeforeReduction);
        UnitModifier modifiedUnitAfterReductions = GetModifiedUnit(effectsAfterReduction);

        int opponentDamageBeforeReductions = modifiedUnitBeforeReductions.GetModifiedDamage();
        int opponentDamageAfterReductions = modifiedUnitAfterReductions.GetModifiedDamage();

        return opponentDamageBeforeReductions - opponentDamageAfterReductions;
    }

    private EffectsToApplyCollection GetInitialEffects()
    {
        EffectsToApplyCollection effects = new();
        effects.Append(EffectType.DamageExtra);
        effects.Append(EffectType.DamageExtraOnFirstAttack);
        
        return effects;
    }

    private EffectsToApplyCollection GetFinalEffects()
    {
        EffectsToApplyCollection effects = GetInitialEffects();
        effects.Append(EffectType.PercentageDamageReductionOnFirstAttack);
        
        return effects;
    }

    private UnitModifier GetModifiedUnit(EffectsToApplyCollection effectsToApply)
    {
        UnitModifier modifiedUnit = new UnitModifier(_unit.Opponent);
        
        return modifiedUnit.GetUnitAffectedBy(effectsToApply);
    }
}