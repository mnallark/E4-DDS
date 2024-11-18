using Fire_Emblem_Model;
namespace Fire_Emblem_Controller;

public class InitialEffectsApplier
{
    private UnitModifier _modifiedUnit;
    public void SetInitialEffects(Unit unit)
    {
        unit.ResetStats();
        _modifiedUnit = new(unit);
        
        SetModifiedUnitsByInitialEffects(unit);
        ApplyInitialEffects(unit);
    }
    
    private void SetModifiedUnitsByInitialEffects(Unit unit)
    {
        EffectsToApplyCollection effectsToApply = new();
        
        effectsToApply.Append(EffectType.Bonus);
        effectsToApply.Append(EffectType.Penalty);

        if (!unit.HasHpBonusApplied)
        {
            effectsToApply.Append(EffectType.HpBonus);
        }
        
        _modifiedUnit.GetUnitAffectedBy(effectsToApply);
    }

    private void ApplyInitialEffects(Unit unit)
    {
        var statsToApply = CollectStatsToApply();
        unit.UpdateModifiedUnitStats(statsToApply);
    }
    
    private ModifiedStatsToApplyOnUnit CollectStatsToApply()
    {
        ModifiedStatsToApplyOnUnit modifiedStatsToApplyOnUnit = new();

        modifiedStatsToApplyOnUnit.SetModifiedStatToApply(StatType.Atk, _modifiedUnit.GetModifiedAtk());
        modifiedStatsToApplyOnUnit.SetModifiedStatToApply(StatType.Spd, _modifiedUnit.GetModifiedSpd());
        modifiedStatsToApplyOnUnit.SetModifiedStatToApply(StatType.Def, _modifiedUnit.GetModifiedDef());
        modifiedStatsToApplyOnUnit.SetModifiedStatToApply(StatType.Res, _modifiedUnit.GetModifiedRes());
        modifiedStatsToApplyOnUnit.SetModifiedStatToApply(StatType.HP, _modifiedUnit.GetModifiedHp());

        return modifiedStatsToApplyOnUnit;
    }
}