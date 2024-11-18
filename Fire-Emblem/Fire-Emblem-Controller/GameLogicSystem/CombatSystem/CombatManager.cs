namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using Fire_Emblem_View;

public class CombatManager
{
    private readonly IFireEmblemView _view;
    private readonly Unit _attackerUnit; 
    private readonly Unit _defenderUnit;
    
    public CombatManager(IFireEmblemView view, Unit attackerUnit, Unit defenderUnit)
    {
        _view = view;
        _attackerUnit = attackerUnit;
        _defenderUnit = defenderUnit;
    }

    public void StartSingleCombat()
    {
        SetUnitsDamage();
        PerformCombatEncounters();
        ConcludeCombat();
    }

    private void SetUnitsDamage()
    {
        DamageController damageController = new(_attackerUnit, _defenderUnit);
        damageController.SetUnitsDamage();
    }
    
    private void PerformCombatEncounters()
    {
        PerformFirstEncounter();
        PerformSecondEncounter();
    }
    
    private void PerformFirstEncounter()
    {
        ExecuteAttack(_attackerUnit);
        ExecuteCounterAttack();
    }
    
    private void ExecuteAttack(Unit unitAttacking)
    {
        AttackExecutionController attackExecutionController = new(_view, unitAttacking);
        attackExecutionController.ExecuteAttack();
    }

    private void ExecuteCounterAttack()
    {
        if (_defenderUnit.IsAlive())
        {
            if (CheckIsCounterAttackPossible(_defenderUnit))
                ExecuteAttack(_defenderUnit);
        }
    }
    
    private bool CheckIsCounterAttackPossible(Unit unit)
    {
        if (unit.IsAlive())
            return EffectTypeCounter.CountEffectsByType(unit, EffectType.CounterattackDenial) == 0;
        
        return false;
    }

    private void PerformSecondEncounter()
    {
        if (_attackerUnit.IsAlive() && _defenderUnit.IsAlive())
            CheckFollowUp();
    }
    
    private void CheckFollowUp()
    {
        if (CheckIsFollowUpPossibleFor(_attackerUnit))
            ExecuteFollowUp(_attackerUnit);
        
        if (CheckIsFollowUpPossibleFor(_defenderUnit))
            ExecuteFollowUp(_defenderUnit);
        
        if (!CheckIsFollowUpPossibleFor(_attackerUnit) && !CheckIsFollowUpPossibleFor(_defenderUnit)) 
            _view.NoOneDoesFollowUpMessage(_attackerUnit, _defenderUnit);
    }
    
    private bool CheckIsFollowUpPossibleFor(Unit unit)
    {
        if (CheckIsCounterAttackPossible(unit))
        {
            if (unit.DoesTheFollowUp)
                return true;
        }

        else
            unit.ChangeDoesFollowUpState();
        
        return false;
    }

    private void ExecuteFollowUp(Unit unit)
    {
        SetUnitsDamage();
        ExecuteAttack(unit);
    }

    private void ConcludeCombat()
    {
        CheckHpReduction();
        _view.ShowUnitsCombatResults(_attackerUnit);
        ChangeUnitCombatStates();
    }
    
    private void CheckHpReduction()
    {
        HpModificationsPostCombatController hpModificationsController = new(_view);
        hpModificationsController.CheckHpModificationsPostCombat(_attackerUnit, _defenderUnit);
    }

    private void ChangeUnitCombatStates()
    {
        HandleUnitPostCombatSettings();
        ResetUnitsTemporaryStates();
    }

    private void HandleUnitPostCombatSettings()
    {
        _attackerUnit.SetPostCombatSettings();
        _defenderUnit.SetPostCombatSettings();
    }

    private void ResetUnitsTemporaryStates()
    {
        _attackerUnit.ResetTemporaryStates();
        _defenderUnit.ResetTemporaryStates();
    }
}