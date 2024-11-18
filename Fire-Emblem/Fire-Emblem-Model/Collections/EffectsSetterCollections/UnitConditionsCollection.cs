namespace Fire_Emblem_Model;

public class UnitConditionsCollection
{
    private readonly Dictionary<Unit, List<Condition>> _unitConditions = new();
    
    public void AppendConditionList(Unit unit)
        => _unitConditions[unit] = new List<Condition>();
    
    public void AppendCondition(Unit unit, Condition condition)
        => _unitConditions[unit].Add(condition);
    
    public Condition GetCondition(Unit unit, int index)
        => _unitConditions[unit][index];
}