namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using Fire_Emblem_View;

public class WeaponTriangleBonusController
{
    private readonly IFireEmblemView _view;
    private readonly Unit _attackerUnit; 
    private readonly Unit _defenderUnit;
    private readonly WeaponTriangleBonusValues _weaponTriangleBonusValues;
    private readonly WeaponTriangleBonusCollection _weaponTriangleBonus = new();
    private const double _advantagedAmount = 1.2;
    private const double _disadvantagedAmount = 0.8;
    private const double _equalBonusAmount = 1;
    
    public WeaponTriangleBonusController(IFireEmblemView view, Unit attackerUnit, Unit defenderUnit)
    {
        _view = view;
        _attackerUnit = attackerUnit;
        _defenderUnit = defenderUnit;
        _weaponTriangleBonusValues = new WeaponTriangleBonusValues(_attackerUnit, _defenderUnit);
    }
    
    public void SetWeaponTriangleBonusOnUnits()
    {
        CalculateWeaponTriangleBonus();
        
        _attackerUnit.SetWeaponTriangleBonus(_weaponTriangleBonusValues.GetUnitBonus(_attackerUnit));
        _defenderUnit.SetWeaponTriangleBonus(_weaponTriangleBonusValues.GetUnitBonus(_defenderUnit));
    }

    private void CalculateWeaponTriangleBonus()
    {
        if (_weaponTriangleBonus.AttackerWeaponHasAdvantage(_attackerUnit.Weapon, _defenderUnit.Weapon))
            ApplyAdvantage(_attackerUnit.Weapon);
        
        else if (_weaponTriangleBonus.AttackerWeaponHasAdvantage(_defenderUnit.Weapon, _attackerUnit.Weapon))
            ApplyAdvantage(_defenderUnit.Weapon);
        
        else
            SetNoOneHasAdvantage();
    }
    
    private void ApplyAdvantage(string attackerWeapon)
    {
        GenerateResultForAdvantage(attackerWeapon);
        AnnounceAdvantage(attackerWeapon);
    }
    
    private void GenerateResultForAdvantage(string advantagedWeapon)
    {
        var isAttackerAdvantaged = advantagedWeapon == _attackerUnit.Weapon;
        GenerateResult(
            isAttackerAdvantaged ? _advantagedAmount : _disadvantagedAmount,
            isAttackerAdvantaged ? _disadvantagedAmount : _advantagedAmount
        );
    }
    
    private void GenerateResult(double attackerBonus, double defenderBonus)
    {
        _weaponTriangleBonusValues.SetBonusValue(_attackerUnit, attackerBonus);
        _weaponTriangleBonusValues.SetBonusValue(_defenderUnit, defenderBonus);
    }

    private void AnnounceAdvantage(string advantagedWeapon)
    {
        var advantagedUnit = advantagedWeapon == _attackerUnit.Weapon ? _attackerUnit : _defenderUnit;
        var disadvantagedUnit = advantagedWeapon == _attackerUnit.Weapon ? _defenderUnit : _attackerUnit;

        _view.AdvantageAnnouncement(advantagedUnit, disadvantagedUnit);
    }

    private void SetNoOneHasAdvantage() 
    {
        GenerateResult(_equalBonusAmount, _equalBonusAmount);
        AnnounceNoAdvantage();
    }
    
    private void AnnounceNoAdvantage()
    {
        _view.NoAdvantageAnnouncement();
    }
}
