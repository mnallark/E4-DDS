using Fire_Emblem_Model;
namespace Fire_Emblem_Controller;

public class DamageSetter
{
    private readonly Unit _attackerUnit; 
    private readonly Unit _defenderUnit;
    private UnitModifier _modifiedAttacker;
    private UnitModifier _modifiedDefender;
    
    public DamageSetter(Unit attackerUnit, Unit defenderUnit)
    {
        _attackerUnit = attackerUnit;
        _defenderUnit = defenderUnit;
        _modifiedAttacker = new UnitModifier(attackerUnit);
        _modifiedDefender = new UnitModifier(defenderUnit);
    }
    
    public void SetUnitsDamage()
    {
        ApplyOneTimeStatEffects();

        _attackerUnit.Damage = CalculateDamage(_modifiedAttacker, _modifiedDefender, _attackerUnit);
        _defenderUnit.Damage = CalculateDamage(_modifiedDefender, _modifiedAttacker, _defenderUnit);
    }
    
    private void ApplyOneTimeStatEffects()
    {
        UnitStatEffectsApplier unitStatEffectsApplier = new UnitStatEffectsApplier();
        _modifiedAttacker = unitStatEffectsApplier.GetUnitAffectedStatEffects(_attackerUnit);
        _modifiedDefender = unitStatEffectsApplier.GetUnitAffectedStatEffects(_defenderUnit);
    }
    
    private int CalculateDamage(UnitModifier attacker, UnitModifier defender, Unit unit)
    {
        int attackerAttack = attacker.GetModifiedAtk();
        int defenderDefense = GetDefenderDefense(defender, unit.Weapon);
        
        return Math.Max(0, (int)(attackerAttack * unit.WeaponTriangleBonusAmount - defenderDefense));
    }
    
    private int GetDefenderDefense(UnitModifier defender, string weaponType)
    {
        return weaponType == "Magic" ? defender.GetModifiedRes() : defender.GetModifiedDef();
    }
}