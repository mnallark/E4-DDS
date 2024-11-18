namespace Fire_Emblem_Model;

public class FollowUpNeutralizationForOpponentEffect : Effect
{
    private const double _minChangeAmount = 1.0;

    public override EffectType GetEffectType()
    {
        return EffectType.FollowUpNeutralization;
    }
    
    public override double GetChangeAmount(Unit unit)
    {
        return _minChangeAmount;
    }

    public override void AddEffectToUnit(Unit unit)
    {
        unit.Opponent.AddEffect(this);
    }
}