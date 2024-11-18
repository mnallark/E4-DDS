namespace Fire_Emblem_Model;

public class PenaltyNeutralizationEffect : Effect
{ 
    public PenaltyNeutralizationEffect(StatType targetNeutralizationStat)
    {
        TargetStat = targetNeutralizationStat;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.NeutralizationPenalty;
    }
}