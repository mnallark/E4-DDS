namespace Fire_Emblem_Model;

public class HpRecoveryPostCombatWithAllyConditionEffect : Effect
{
    private const int _minChangeAmount = 0;

    public HpRecoveryPostCombatWithAllyConditionEffect(int changeAmount)
    {
        TargetStat = StatType.HP;
        ChangeAmount = changeAmount;
    }

    public override double GetChangeAmount(Unit unit)
    {
        if (CheckConditionHolds(unit))
            return ChangeAmount;

        return _minChangeAmount;
    }

    private bool CheckConditionHolds(Unit unit)
    {
        foreach (Unit playerUnit in unit.Owner.Team)
        {
            if (playerUnit.Weapon == "Magic" && playerUnit != unit)
                return true;
        }

        return false;
    }

    public override EffectType GetEffectType()
    {
        return EffectType.HpRecoveryPostCombat;
    }
}