namespace Fire_Emblem_Model;

public class WeaponTriangleBonusValues
{
    private readonly Dictionary<Unit, double> _weaponTriangleBonusValues = new();
    private const int _baseBonusValue = 0;

    public WeaponTriangleBonusValues(Unit attackerUnit, Unit defenderUnit)
    {
        _weaponTriangleBonusValues = new Dictionary<Unit, double>
        {
            { attackerUnit, _baseBonusValue },
            { defenderUnit, _baseBonusValue }
        };
    }

    public void SetBonusValue(Unit unit, double bonusAmount)
        => _weaponTriangleBonusValues[unit] = bonusAmount;

    public double GetUnitBonus(Unit unit)
        => _weaponTriangleBonusValues[unit];
}