
public class DeveloperTeamRepository
{
    private DeveloperRepository _devRepo;

    private readonly List<DeveloperTeam> _devTeamDb = new List<DeveloperTeam>();
    private int _count;

    public DeveloperTeamRepository(DeveloperRepository devRepo)
    {
        _devRepo = devRepo;
        SeedData();
    }

    public bool AddTeamToDb(DeveloperTeam team)
    {
        if (team is null)
        {
            return false;
        }
        else
        {
            _count++;
            team.Id = _count;
            _devTeamDb.Add(team);
            return true;
        }
    }

    public List<DeveloperTeam> GetDeveloperTeams()
    {
        return _devTeamDb;
    }

    public DeveloperTeam GetDeveloperTeam(int devTeamId)
    {
        foreach (DeveloperTeam team in _devTeamDb)
        {
            if (team.Id == devTeamId)
            {
                return team;
            }
        }
        return null;
    }

    public bool UpdateDevTeam(int devTeamId, DeveloperTeam updatedTeamData)
    {
        var teamInDB = GetDeveloperTeam(devTeamId);

        if (teamInDB != null)
        {
            teamInDB.TeamName = updatedTeamData.TeamName;
            teamInDB.Developers = updatedTeamData.Developers;
            return true;
        }
        return false;
    }

    public bool DeleteDeveloperTeam(int devTeamId)
    {
        var teamInDB = GetDeveloperTeam(devTeamId);
        return _devTeamDb.Remove(teamInDB);
    }

    //Challenge:
    //we need the teamId and we need List<Developers> to add
    public bool AddMultiDevsToTeam(int devTeamId, List<Developer> devs)
    {
        var teamInDB = GetDeveloperTeam(devTeamId);
        if (teamInDB != null && devs != null)
        {
            teamInDB.Developers.AddRange(devs);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SeedData()
    {

        var walter = _devRepo.GetDeveloper(1); //Walter Payton
        var ladainian = _devRepo.GetDeveloper(2); //LaDainian Tomlinson

        var teamA = new DeveloperTeam("HedgeHog", new List<Developer>
        {
          walter,
          ladainian
        });

        var ricky = _devRepo.GetDeveloper(3); //Ricky Williams
        var edgerrin = _devRepo.GetDeveloper(4); // Edgerrin James

        var teamB = new DeveloperTeam("Primate", new List<Developer>
        {
            ricky,
            edgerrin
        });

        AddTeamToDb(teamA);
        AddTeamToDb(teamB);
    }
}

