namespace Fire_Emblem_Model;

public class UnitHpPercentageMoreThanAndOpponentUsesWeaponCondition : Condition
{
    private readonly double _hpPercentage;
    private readonly string[] _weapons;

    public UnitHpPercentageMoreThanAndOpponentUsesWeaponCondition(double hpPercentage, string[] weapons)
    {
        _hpPercentage = hpPercentage;
        _weapons = weapons;
    }
    
    public override bool DoesItHold(Unit unit)
    {
        if (CheckUnitHpTarget(unit, _hpPercentage))
            return _weapons.Contains(unit.Opponent.Weapon);

        return false;
    }

    private bool CheckUnitHpTarget(Unit unit, double hpTargetPercentage)
    {
        return Math.Round(Convert.ToDouble(unit.HP) / Convert.ToDouble(unit.MaxHP), 2) >= hpTargetPercentage;
    }
}