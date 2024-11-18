namespace Fire_Emblem_Model;

public class HpReductionPreCombatEffect : Effect
{
    public HpReductionPreCombatEffect(int changeAmount)
    {
        TargetStat = StatType.HP;
        ChangeAmount = -changeAmount;
    }

    public override EffectType GetEffectType()
    {
        return EffectType.HpReductionPreCombat;
    }
}