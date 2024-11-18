namespace Fire_Emblem_Model;

public class WeaponsCollection
{
    private readonly List<string> _weaponsCollection = new();
    
    public void Append(string weapon)
        => _weaponsCollection.Add(weapon);
    
    public bool CheckWeaponCollectionContains(string weapon)
        => _weaponsCollection.Contains(weapon);
}