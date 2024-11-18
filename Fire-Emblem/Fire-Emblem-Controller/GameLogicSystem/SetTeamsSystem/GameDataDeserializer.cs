namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using System.Text.Json;

public class GameDataDeserializer
{
    private readonly JsonSerializerOptions _options;

    public GameDataDeserializer()
    {
        _options = new JsonSerializerOptions();
        _options.Converters.Add(new StringToIntConverter());
    }

    public void LoadUnitsFromData(UnitsFromData unitsFromData)
    {
        var units = LoadData<List<Unit>>("characters.json");
        unitsFromData.SetLoadUnits(units);
    }
    
    private T LoadData<T>(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json, _options);
    }

    public void LoadSkillsFromData(SkillsFromData skillsFromData)
    {
        var skills = LoadData<List<Skill>>("skills.json");
        skillsFromData.SetLoadSkills(skills);
    }
}