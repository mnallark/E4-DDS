namespace Fire_Emblem_Model;

public class SandstormFactory
{
    private const double _effectMultiplier = 1.5;
    
    public List<Effect> Create(Unit unit)
    {
        var effects = new List<Effect>();

        int attackChangeAmount = CalculateAttackChangeAmount(unit.BaseDef, unit.BaseAtk);
        AddAttackEffect(effects, attackChangeAmount);

        return effects;
    }

    private int CalculateAttackChangeAmount(double baseDefense, double baseAttack)
    {
        return Convert.ToInt32(Math.Floor(baseDefense * _effectMultiplier - baseAttack));
    }

    private void AddAttackEffect(List<Effect> effects, int attackChangeAmount)
    {
        if (attackChangeAmount > 0)
        {
            effects.Add(new FollowUpBonusEffect(StatType.Atk, attackChangeAmount));
        }
        else if (attackChangeAmount < 0)
        {
            effects.Add(new FollowUpPenaltyEffect(StatType.Atk, attackChangeAmount));
        }
    }
}