namespace Fire_Emblem_Model;

public class SkillsFromData
{
    private readonly List<Skill> _skillsFromDataCollection;

    public SkillsFromData()
    {
        _skillsFromDataCollection = new List<Skill>();
    }

    public void SetLoadSkills(IEnumerable<Skill> skills)
    {
        _skillsFromDataCollection.AddRange(skills);
    }

    public Skill FindBaseSkill(string skillName)
    {
        return _skillsFromDataCollection.FirstOrDefault(s => s.Name == skillName);
    }
}