using Fire_Emblem_Model;
namespace Fire_Emblem_Controller;

public class DamageController
{
    private readonly Unit _attackerUnit; 
    private readonly Unit _defenderUnit;
    private UnitModifier _modifiedUnit;
    private UnitModifier _modifiedOpponentUnit;
    
    public DamageController(Unit attackerUnit, Unit defenderUnit)
    {
        _attackerUnit = attackerUnit;
        _defenderUnit = defenderUnit;
        _modifiedUnit = new UnitModifier(attackerUnit);
        _modifiedOpponentUnit = new UnitModifier(defenderUnit);
    }
    
    public void SetUnitsDamage()
    {
        DamageSetter damageSetter = new(_attackerUnit, _defenderUnit);
        damageSetter.SetUnitsDamage();
        
        SetDamageEffectsOnModifiedUnits();

        _attackerUnit.Damage = _modifiedUnit.GetModifiedDamage();
        _defenderUnit.Damage = _modifiedOpponentUnit.GetModifiedDamage();
    }
    
    private void SetDamageEffectsOnModifiedUnits()
    {
        UnitDamageEffectsApplier unitDamageEffectsApplier = new();
        _modifiedUnit = unitDamageEffectsApplier.GetUnitAffectedByDamageEffects(_attackerUnit);
        _modifiedOpponentUnit = unitDamageEffectsApplier.GetUnitAffectedByDamageEffects(_defenderUnit);
    }
}