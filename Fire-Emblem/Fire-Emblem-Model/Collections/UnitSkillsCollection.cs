namespace Fire_Emblem_Model;

public class UnitSkillsCollection
{
    private readonly List<Skill> _skillsCollection = new();
    
    public void Append(Skill skill)
        => _skillsCollection.Add(skill);
    
    public List<Skill> GetAllSkills()
        => _skillsCollection;
    
    public string[] GetSkillsToArray()
        => _skillsCollection.Select(skill => skill.Name).ToArray();
}