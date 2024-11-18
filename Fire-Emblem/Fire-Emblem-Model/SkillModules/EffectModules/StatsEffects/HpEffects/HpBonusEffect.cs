namespace Fire_Emblem_Model;

public class HpBonusEffect : Effect
{
    public HpBonusEffect(StatType targetStat, int bonus)
    {
        TargetStat = targetStat;
        ChangeAmount = bonus;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.HpBonus;
    }
}