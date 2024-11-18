namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;

public class BewitchingTomeController
{
    private readonly Unit _unit;
    
    public BewitchingTomeController(Unit unit)
    {
        _unit = unit;
    }
    
    public void AddEffectToUnit()
    {
        if (CheckEffectConditionHolds())
        {
            int changeAmount = GetChangeAmount();

            Effect effect = new HpReductionPreCombatForOpponentEffect(changeAmount);
            effect.AddEffectToUnit(_unit);
        }
    }

    private bool CheckEffectConditionHolds()
    {
        if (_unit.StartsCombat)
            return true;

        if (_unit.Opponent.Weapon == "Bow" || _unit.Opponent.Weapon == "Magic")
            return true;
        
        return false;
    }

    private int GetChangeAmount()
    {
        if (CheckWeaponTriangleBonusAdvantage() || CheckSpdConditionHolds())
            return CalculateChangeAmount(0.4);

        return CalculateChangeAmount(0.2);
    }

    private int CalculateChangeAmount(double percentageTarget)
    {
        return Convert.ToInt32(Math.Floor(_unit.Opponent.Atk * percentageTarget));
    }
    
    private bool CheckWeaponTriangleBonusAdvantage()
    {
        string attackerWeapon = _unit.Weapon;
        string defenderWeapon = _unit.Opponent.Weapon;

        WeaponTriangleBonusCollection weaponTriangleBonusCollection = new();
        return weaponTriangleBonusCollection.AttackerWeaponHasAdvantage(attackerWeapon, defenderWeapon);
    }
    
    private bool CheckSpdConditionHolds()
    {
        return _unit.Spd > _unit.Opponent.Spd;
    }
}