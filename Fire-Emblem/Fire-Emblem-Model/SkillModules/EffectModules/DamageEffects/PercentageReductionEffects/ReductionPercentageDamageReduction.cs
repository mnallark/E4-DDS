namespace Fire_Emblem_Model;

public class ReductionPercentageDamageReduction : Effect
{
    public ReductionPercentageDamageReduction(double changeAmount)
    {
        ChangeAmount = changeAmount;
    }
    
    public override EffectType GetEffectType()
    {
        return EffectType.ReductionPercentageDamageReduction;
    }
    
    public override void AddEffectToUnit(Unit unit)
    {
        unit.Opponent.AddEffect(this);
    }
}