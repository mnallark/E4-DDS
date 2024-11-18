namespace Fire_Emblem_Model;

public class UnitsFromData
{
    private readonly List<Unit> _unitsFromDataCollection;

    public UnitsFromData()
    {
        _unitsFromDataCollection = new List<Unit>();
    }

    public void SetLoadUnits(IEnumerable<Unit> units)
    {
        _unitsFromDataCollection.AddRange(units);
    }

    public Unit FindBaseUnit(string unitName)
    {
        return _unitsFromDataCollection.FirstOrDefault(u => u.Name == unitName);
    }
}