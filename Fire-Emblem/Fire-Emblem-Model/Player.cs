namespace Fire_Emblem_Model;

public class Player
{
    public string Name { get; }
    public List<Unit> Team { get; }

    public Player(string name)
    {
        Name = name;
        Team = new List<Unit>();
    }
    
    public void AddUnit(Unit unit)
    {
        Team.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        Team.Remove(unit);
    }
    
    public Unit ChooseStartingUnit(int unitIndex)
    {
        return Team[unitIndex];
    }
    
    public bool HasDuplicateUnits()
    {
        var unitNames = new HashSet<string>();
        
        foreach (var unit in Team)
        {
            if (!unitNames.Add(unit.Name))
                return true;
        }
        
        return false;
    }
}