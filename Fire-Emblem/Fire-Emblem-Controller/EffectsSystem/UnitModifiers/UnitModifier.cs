namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;

public class UnitModifier
{
    private readonly UnitModifierByDamageEffects _damageEffectsModifier;
    private readonly UnitModifierByStatEffects _statEffectsModifier;

    public UnitModifier(Unit baseUnit)
    {
        _damageEffectsModifier = new UnitModifierByDamageEffects(baseUnit);
        _statEffectsModifier = new UnitModifierByStatEffects(baseUnit);
    }

    public UnitModifier GetUnitAffectedBy(EffectsToApplyCollection effectsToApply)
    {
        foreach (var effectType in effectsToApply.GetAllEffects())
        {
            if (effectType.IsStatEffect() || effectType.IsHpModificationEffect())
            {
                _statEffectsModifier.ApplyStatEffectsByType(effectType);
            }

            if (effectType.IsDamageEffect())
            {
                _damageEffectsModifier.ApplyDamageEffectsByType(effectType);
            }
        }

        _damageEffectsModifier.ApplyCumulativeReductions();
        return this;
    }

    public int GetModifiedAtk() => _statEffectsModifier.GetModifiedAtk();
    public int GetModifiedSpd() => _statEffectsModifier.GetModifiedSpd();
    public int GetModifiedDef() => _statEffectsModifier.GetModifiedDef();
    public int GetModifiedRes() => _statEffectsModifier.GetModifiedRes();
    public int GetModifiedHp() => _statEffectsModifier.GetModifiedHp();
    public int GetModifiedDamage() => _damageEffectsModifier.GetModifiedDamage();
}