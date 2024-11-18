namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;

public class TeamsBuilder
{
    private Player _currentPlayer;
    private readonly PlayersCollection _players;
    private readonly UnitsFromData _unitsFromData = new();
    private readonly SkillsFromData _skillsFromData = new();
    
    public TeamsBuilder(PlayersCollection players)
    {
        _players = players;
        GameDataDeserializer gameDataDeserializer = new GameDataDeserializer();
        gameDataDeserializer.LoadUnitsFromData(_unitsFromData);
        gameDataDeserializer.LoadSkillsFromData(_skillsFromData);
    }
    
    public void BuildTeams(string[] lines)
    {
        foreach (var line in lines)
        {
            if (CheckStartsWithTeamName(line))
                SelectTeamToSetup(line);
            else
                AddUnitToPlayer(line);
        }
    }
    
    private bool CheckStartsWithTeamName(string line)
    {
        return line.StartsWith("Player");
    }
    
    private void SelectTeamToSetup(string line)
    {
        if (line.StartsWith("Player 1 Team"))
            _currentPlayer = _players.GetPlayer1();
        
        else
            _currentPlayer = _players.GetPlayer2();
    }
    
    private void AddUnitToPlayer(string line)
    {
        Unit newUnit = SetUnit(line);

        newUnit.Owner = _currentPlayer;
        _currentPlayer.AddUnit(newUnit);
    }
    
    private Unit SetUnit(string line)
    {
        string unitName = ExtractUnitName(line);
        string skillsPart = ExtractSkillsPart(line);
        
        Unit baseUnit = FindBaseUnitFromData(unitName);
        Unit newUnit = CreateUnitFromBase(baseUnit);
        
        AssignSkillsToUnit(skillsPart, newUnit);

        return newUnit;
    }
    
    private string ExtractUnitName(string line)
    {
        return line.Split('(')[0].Trim();
    }
    
    private string ExtractSkillsPart(string line)
    {
        var parts = line.Split('(');
        return parts.Length > 1 ? parts[1].Replace(")", "").Trim() : string.Empty;
    }
    
    private Unit FindBaseUnitFromData(string unitName)
    {
        return _unitsFromData.FindBaseUnit(unitName);
    }
    
    private Unit CreateUnitFromBase(Unit baseUnit)
    {
        return new Unit(baseUnit.Name, baseUnit.Weapon, baseUnit.Gender, 
            baseUnit.HP, baseUnit.Atk, baseUnit.Spd, baseUnit.Def, baseUnit.Res);
    }
    
    private void AssignSkillsToUnit(string skillsPart, Unit unit)
    {
        if (!string.IsNullOrEmpty(skillsPart)) 
            SetSkillsOnUnit(skillsPart, unit);
    }

    private void SetSkillsOnUnit(string skillsPart, Unit unit)
    {
        List<string> skillNames = ParseSkillNames(skillsPart);
        
        foreach (var skillName in skillNames)
        {
            Skill skill = FindBaseSkillFromData(skillName);
            unit.AddSkill(skill);
        }
    }
    
    private List<string> ParseSkillNames(string skillsPart)
    {
        var skillsArray = skillsPart.Split(',');
        var trimmedSkills = skillsArray.Select(s => s.Trim());
        
        return trimmedSkills.ToList();
    }
    
    private Skill FindBaseSkillFromData(string skillName)
    {
        return _skillsFromData.FindBaseSkill(skillName);
    }
}
