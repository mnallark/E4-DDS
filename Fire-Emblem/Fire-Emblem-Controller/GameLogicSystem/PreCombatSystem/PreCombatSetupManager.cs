namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using Fire_Emblem_View;

public class PreCombatSetupManager
{
    private readonly IFireEmblemView _view;
    private readonly Unit _attackerUnit; 
    private readonly Unit _defenderUnit;
    
    public PreCombatSetupManager(IFireEmblemView view, Unit attackerUnit, Unit defenderUnit)
    {
        _view = view;
        _attackerUnit = attackerUnit;
        _defenderUnit = defenderUnit;
    }
    public void SetPreCombatSetUp()
    {
        SetWeaponTriangleBonus();
        SetStartingUnitsAttributes();
        StartSkillsSystem();
        SetFollowUpStateOnUnits();
    }

    private void SetWeaponTriangleBonus()
    {
        WeaponTriangleBonusController weaponTriangleBonusController = new(_view, _attackerUnit, _defenderUnit);
        weaponTriangleBonusController.SetWeaponTriangleBonusOnUnits();
    }
    
    private void SetStartingUnitsAttributes()
    {
        _attackerUnit.ItsStartingTheBattle();
        UnitsInCombat();
    }
    
    private void UnitsInCombat()
    {
        _attackerUnit.FightAgainst(_defenderUnit);
        _defenderUnit.FightAgainst(_attackerUnit);
    }

    private void StartSkillsSystem()
    {
        AddEffectsOnUnits();
        ProcessCounterattackEffects();
        AnnounceEffects();
        ProcessPreCombatHpReductionEffects();
    }

    private void AddEffectsOnUnits()
    {
        UnitEffectsSetter unitEffectsSetter = new(_attackerUnit, _defenderUnit);
        unitEffectsSetter.ProcessEffectsOnUnits();
    }

    private void ProcessCounterattackEffects()
    {
        CounterattackEffectsProcessor counterattackEffectsProcessor = new();
        counterattackEffectsProcessor.ProcessCounterattackEffectsOnUnits(_attackerUnit, _defenderUnit);
    }

    private void AnnounceEffects()
    {
        EffectsAnnouncementManager effectsAnnouncementManager = new(_view);
        effectsAnnouncementManager.AnnounceEffects(_attackerUnit, _defenderUnit);
    }
    
    private void ProcessPreCombatHpReductionEffects()
    {
        HpModificationsPreCombatController hpModificationsPreCombatController = new(_view);
        hpModificationsPreCombatController.CheckHpModificationsPreCombat(_attackerUnit, _defenderUnit);
    }
    
    private void SetFollowUpStateOnUnits()
    {
        FollowUpController followUpController = new();
        followUpController.DetermineFollowUpOnUnits(_attackerUnit, _defenderUnit);
    }
}