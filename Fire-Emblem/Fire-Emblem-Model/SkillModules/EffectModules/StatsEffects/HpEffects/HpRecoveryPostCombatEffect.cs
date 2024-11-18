namespace Fire_Emblem_Model;

public class HpRecoveryPostCombatEffect : Effect
{
    public HpRecoveryPostCombatEffect(int changeAmount)
    {
        TargetStat = StatType.HP;
        ChangeAmount = changeAmount;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.HpRecoveryPostCombat;
    }
}