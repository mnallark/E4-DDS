namespace Fire_Emblem_Model;

public class FollowUpBonusEffect : Effect
{
    public FollowUpBonusEffect(StatType targetStat, int bonus)
    {
        TargetStat = targetStat;
        ChangeAmount = bonus;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.BonusOnFollowUp;
    }
}