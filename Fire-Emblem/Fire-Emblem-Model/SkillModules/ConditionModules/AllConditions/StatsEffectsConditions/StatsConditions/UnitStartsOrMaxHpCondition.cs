namespace Fire_Emblem_Model;

public class UnitStartsOrMaxHpCondition : Condition
{
    public override bool DoesItHold(Unit unit)
    {
        Unit opponent = unit.Opponent;
        
        return opponent.StartsCombat | opponent.HP == opponent.MaxHP;
    }
}