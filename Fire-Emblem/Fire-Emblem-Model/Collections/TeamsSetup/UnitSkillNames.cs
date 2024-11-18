namespace Fire_Emblem_Model;

public class UnitSkillNames
{
    private readonly List<string> _unitSkillNames = new();
    private readonly int _maxSkillsAmount = 2;

    public UnitSkillNames(Unit unit)
    {
        _unitSkillNames = ExtractSkillNames(unit);
    }
    
    private List<string> ExtractSkillNames(Unit unit)
    {
        var skills = unit.SkillsCollection.GetAllSkills();
        
        return skills.Select(s => s.Name).ToList();
    }

    public bool CheckSkillsWithSameName()
        => _unitSkillNames.GroupBy(s => s).Any(g => g.Count() > 1);

    public bool CheckUnitHasMoreThanTwoSkills()
        => _unitSkillNames.Count > _maxSkillsAmount;
}