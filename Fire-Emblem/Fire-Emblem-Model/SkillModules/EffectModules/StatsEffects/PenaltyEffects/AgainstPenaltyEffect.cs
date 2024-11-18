namespace Fire_Emblem_Model;

public class AgainstPenaltyEffect : Effect
{
    public AgainstPenaltyEffect(StatType targetPenaltyStat, int penalty)
    {
        TargetStat = targetPenaltyStat;
        ChangeAmount = -penalty;
    }   
    
    public override EffectType GetEffectType()
    {
        return EffectType.Penalty;
    }
}