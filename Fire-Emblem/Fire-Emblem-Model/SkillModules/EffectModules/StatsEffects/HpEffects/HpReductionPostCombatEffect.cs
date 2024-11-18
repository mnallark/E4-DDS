namespace Fire_Emblem_Model;

public class HpReductionPostCombatEffect : Effect
{
    private const int _minChangeAmount = 0;

    public HpReductionPostCombatEffect(int changeAmount)
    {
        TargetStat = StatType.HP;
        ChangeAmount = -changeAmount;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.HpReductionPostCombat;
    }

    public override double GetChangeAmount(Unit unit)
    {
        if (unit.HasAttackedBefore)
            return ChangeAmount;

        return _minChangeAmount;
    }
}