namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using Fire_Emblem_View;
using System;
using System.IO;

public class TeamsLoader
{
    private readonly IFireEmblemView _view;
    private readonly string _teamsFolder;
    private readonly PlayersCollection _players;

    public TeamsLoader(IFireEmblemView view, string teamsFolder, PlayersCollection players)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        _players = players;
    }

    public void SetupTeams()
    {
        string selectedTeamFile = SelectTeamFile();
        string[] teamLines = File.ReadAllLines(selectedTeamFile);
        
        TeamsBuilder teamsBuilder = new TeamsBuilder(_players);
        teamsBuilder.BuildTeams(teamLines);
    }
    
    private string SelectTeamFile()
    {
        if (_view is FireEmblemConsoleView)
        {
            _view.SelectTeamFileMessage();
            
            var teamFiles = GetTeamFiles();
            DisplayTeamFiles(teamFiles);
            
            return GetSelectedFile(teamFiles);
        }
        
        if (_view is FireEmblemGuiView)
        {
            return _view.SelectTeamFile();
        }
        
        throw new InvalidOperationException("Unknown view type.");
    }
    
    private string[] GetTeamFiles()
    {
        var teamFiles = Directory.GetFiles(_teamsFolder, "*.txt");
        Array.Sort(teamFiles);
        
        return teamFiles;
    }

    private void DisplayTeamFiles(string[] teamFiles)
    {
        for (int index = 0; index < teamFiles.Length; index++)
        {
            string fileName = Path.GetFileName(teamFiles[index]);
            _view.DisplayTeams(index, fileName);
        }
    }
    
    private string GetSelectedFile(string[] teamFiles)
    {
        int selectedIndex = int.Parse(_view.ReadLine());
        return teamFiles[selectedIndex];
    }
}
