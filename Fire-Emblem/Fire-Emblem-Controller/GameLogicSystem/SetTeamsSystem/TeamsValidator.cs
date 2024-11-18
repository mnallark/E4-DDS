namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using System;

public class TeamsValidator
{
    private readonly int _maxTeamLength = 3;
    
    public void CheckValidateTeams(PlayersCollection players)
    {
        try
        {
            Player player1 = players.GetPlayer1();
            Player player2 = players.GetPlayer2();

            ValidateTeams(player1, player2);
        }
        catch (ValidationException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
    
    private void ValidateTeams(Player player1, Player player2)
    {
        ValidateTeam(player1);
        ValidateTeam(player2);
    }

    private void ValidateTeam(Player player)
    {
        CheckTeamLengthIsValid(player);
        CheckNoDuplicateUnits(player);
        ValidateUnitSkills(player);
    }

    private void CheckTeamLengthIsValid(Player player)
    {
        int teamCount = player.Team.Count;

        if (teamCount <= 0)
            throw new InvalidTeamLengthException($"{player.Name}'s team it's empty.");

        if (teamCount > _maxTeamLength)
            throw new InvalidTeamLengthException($"{player.Name}'s team have more than 3 units.");
    }

    private void CheckNoDuplicateUnits(Player player)
    {
        if (player.HasDuplicateUnits())
            throw new DuplicateUnitsException($"{player.Name}'s team have duplicate units.");
    }

    private void ValidateUnitSkills(Player player)
    {
        foreach (var unit in player.Team)
        {
            UnitSkillNames unitSkillNames = new(unit);
            CheckAreSkillsValid(unitSkillNames);
        }
    }

    private void CheckAreSkillsValid(UnitSkillNames unitSkillNames)
    {
        CheckSkillsWithSameName(unitSkillNames);
        CheckNotMoreThanTwoSkills(unitSkillNames);
    }

    private void CheckSkillsWithSameName(UnitSkillNames unitSkillNames)
    {
        if (unitSkillNames.CheckSkillsWithSameName())
            throw new InvalidSkillsException("Unit cannot have the same skill twice.");
    }

    private void CheckNotMoreThanTwoSkills(UnitSkillNames unitSkillNames)
    {
        if (unitSkillNames.CheckUnitHasMoreThanTwoSkills())
            throw new InvalidSkillsException("Unit cannot have more than two skills.");
    }
}
