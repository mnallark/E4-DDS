namespace Fire_Emblem_Model;

public class FollowUpPenaltyEffect : Effect
{
    public FollowUpPenaltyEffect(StatType targetStat, int penalty)
    {
        TargetStat = targetStat;
        ChangeAmount = penalty;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.PenaltyOnFollowUp;
    }
}