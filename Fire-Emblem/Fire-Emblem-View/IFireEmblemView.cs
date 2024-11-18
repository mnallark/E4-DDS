namespace Fire_Emblem_View;
using Fire_Emblem_Model;

public interface IFireEmblemView
{
    string ReadLine();
    void AnnounceThatTeamIsInvalid();
    void SelectTeamFileMessage();
    string SelectTeamFile();
    void ShowUpdateTeams(PlayersCollection players);
    void DisplayTeams(int i, string fileName);
    void StartRoundInfo(int roundNumber, Unit attackerUnit);
    void SelectionOptionMessage(Player player);
    void UnitSelectionOptions(int unitNumberOnTeam, Player player);
    string UnitSelection(Player player);
    void AdvantageAnnouncement(Unit advantagedUnit, Unit disadvantagedUnit);
    void NoAdvantageAnnouncement();
    void ShowAttackInfo(Unit unitAttacking, Unit unitDefending);
    void NoOneDoesFollowUpMessage(Unit attackerUnit, Unit defenderUnit);
    void GetEffectDescription(Unit unit, AnnouncementEffectInfo effectInfo, double changeAmount);
    void GetHpReductionPreCombatDescription(Unit unit, double changeAmount);
    void GetCounterattackDenialDescription(string unitName);
    void GetCounterattackNegationDenialDescription(string unitName);
    void GetHpRecoveryPostAttackDescription(string unitName, double recoveryAmount, int unitHp);
    void GetHpReductionPostCombatDescription(string unitName, double changeAmount);
    void GetHpRecoveryPostCombatDescription(string unitName, double changeAmount);
    void ShowUnitsCombatResults(Unit attackerUnit);
    void ShowGameFinished(Player winnerPlayer);
}