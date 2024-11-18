using Fire_Emblem_Model;
namespace Fire_Emblem_Controller;
using System.Collections.Generic;

public class UnitEffectsSetter
{
    private readonly Unit _attackerUnit; 
    private readonly Unit _defenderUnit;
    private readonly UnitConditionsCollection _unitConditions = new();
    private readonly UnitEffectsCollection _unitEffects = new();
    
    public UnitEffectsSetter(Unit attackerUnit, Unit defenderUnit)
    {
        _attackerUnit = attackerUnit;
        _defenderUnit = defenderUnit;
    }

    public void ProcessEffectsOnUnits()
    {
        SetStatEffects();
        SetInitialEffectsOnUnits();
        SetDamageEffects();
        SetUnitsDamage();
        SetEffectsThatMustAddLaterOnUnits();
    }

    private void SetStatEffects()
    {
        AddStatEffectsOnUnit(_attackerUnit);
        AddStatEffectsOnUnit(_defenderUnit);
    }
    
    private void AddStatEffectsOnUnit(Unit unit)
    {
        InitializeEffects(unit);
        AddUnitEffects(unit, AddStatEffect);
    }
    
    private void InitializeEffects(Unit unit)
    {
        _unitConditions.AppendConditionList(unit);
        _unitEffects.AppendEffectList(unit);
        BuildFactoriesFor(unit);
    }
    
    private void BuildFactoriesFor(Unit unit)
    {
        ConditionFactory conditionFactory = new();
        EffectFactory effectFactory = new();
        
        foreach (var skill in unit.SkillsCollection.GetAllSkills())
        {
            _unitConditions.AppendCondition(unit, conditionFactory.Create(skill.Name));
            _unitEffects.AppendSkillEffects(unit, effectFactory.Create(skill.Name, unit));
        }
    }
    
    private void AddStatEffect(Effect effect, Unit unit)
    {
        effect.AddEffectToUnit(unit);
    }
    
    private void AddUnitEffects(Unit unit, Action<Effect, Unit> addEffect,
        Func<Condition, bool>? customConditionCheck = null)
    {
        int amountOfEffects = _unitEffects.GetEffectsAmount(unit);

        for (int index = 0; index < amountOfEffects; index++)
        {
            Condition condition = _unitConditions.GetCondition(unit, index);
            EffectsCollection effectsCollection = _unitEffects.GetEffectsList(unit, index);
            
            if (CheckIsConditionSatisfied(condition, unit, customConditionCheck))
            {
                AddEffectsToUnit(effectsCollection, effect => addEffect(effect, unit));
            }
        }
    }
    
    private bool CheckIsConditionSatisfied(Condition condition, Unit unit, Func<Condition, bool>? customConditionCheck)
    {
        return customConditionCheck == null ? condition.DoesItHold(unit) : customConditionCheck(condition);
    }
    
    private void AddEffectsToUnit(EffectsCollection effectsCollection, Action<Effect> addEffect)
    {
        List<Effect> effectsFromCollection = effectsCollection.GetAllEffects();
        
        foreach (var effect in effectsFromCollection)
        {
            addEffect(effect);
        }
    }
    
    private void SetInitialEffectsOnUnits()
    {
        InitialEffectsApplier initialEffectsApplier = new();
        initialEffectsApplier.SetInitialEffects(_attackerUnit);
        initialEffectsApplier.SetInitialEffects(_defenderUnit);
    }
    
    private void SetDamageEffects()
    {
        SetDamageEffectsFor(_attackerUnit);
        SetDamageEffectsFor(_defenderUnit);
        SetInitialEffectsOnUnits();
    }
    
    private void SetDamageEffectsFor(Unit unit)
    {
        InitializeEffects(unit);
        AddUnitEffects(unit, AddDamageEffect, 
            condition => condition.DoesItHoldAfterStatsEffectsApplied(unit));
    }
    
    private void AddDamageEffect(Effect effect, Unit unit)
    {
        effect.AddEffectToUnit(unit);
    }

    private void SetUnitsDamage()
    {
        DamageSetter damageSetter = new(_attackerUnit, _defenderUnit);
        damageSetter.SetUnitsDamage();
    }
    
    private void SetEffectsThatMustAddLaterOnUnits()
    {
        CheckEffectsThatMustAddAfter(_defenderUnit);
        CheckEffectsThatMustAddAfter(_attackerUnit);
    }
    
    private void CheckEffectsThatMustAddAfter(Unit unit)
    {
        PostApplicationEffectsController postApplicationEffectsController = new(unit);
        postApplicationEffectsController.ProcessEffects();
    }
}
