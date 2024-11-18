namespace Fire_Emblem_Model;

public class OpponenWeaponCondition : Condition
{
    private readonly string _weapon;
    public OpponenWeaponCondition(string weapon)
    {
        _weapon = weapon;
    }
    
    public override bool DoesItHold(Unit unit)
    {
        return false;
    }
    
    public override bool DoesItHoldAfterStatsEffectsApplied(Unit unit)
    {
        return unit.Opponent.Weapon == _weapon;
    }
}