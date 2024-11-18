namespace Fire_Emblem_Model;

public class BonusNeutralizationEffect : Effect
{
    public BonusNeutralizationEffect(StatType targetNeutralizationStat)
    {
        TargetStat = targetNeutralizationStat;
    }

    public override EffectType GetEffectType()
    {
        return EffectType.NeutralizationBonus;
    }
    
    public override void AddEffectToUnit(Unit unit)
    {
        unit.Opponent.AddEffect(this);
    }
}