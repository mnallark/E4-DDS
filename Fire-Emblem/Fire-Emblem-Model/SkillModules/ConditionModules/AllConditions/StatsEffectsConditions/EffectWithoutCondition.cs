namespace Fire_Emblem_Model;

public class EffectWithoutCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        return true;
    }
}
