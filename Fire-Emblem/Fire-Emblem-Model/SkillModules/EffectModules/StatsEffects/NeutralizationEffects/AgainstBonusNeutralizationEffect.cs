namespace Fire_Emblem_Model;

public class AgainstBonusNeutralizationEffect : Effect
{
    public AgainstBonusNeutralizationEffect(StatType targetNeutralizationStat)
    {
        TargetStat = targetNeutralizationStat;
    }

    public override EffectType GetEffectType()
    {
        
        return EffectType.NeutralizationBonus;
    }
}