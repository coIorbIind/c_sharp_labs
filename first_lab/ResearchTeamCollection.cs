using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace first_lab
{
    class ResearchTeamCollection
    {
        List<ResearchTeam> MyTeams = new List<ResearchTeam>();

        public void AddDefaults(params ResearchTeam[] teams)
        {
            foreach (ResearchTeam item in teams)
            {
                MyTeams.Add(item);
            }
        }

        public void AddResearchTeams(ResearchTeam team)
        {
            MyTeams.Add(team);
        }

        public override string ToString()
        {
            String text = "Исследовательские команды:\n";
            foreach (ResearchTeam item in MyTeams)
            {
                text += (item.ToString() + "\n\n");
            }

            return text;
        }

        public virtual string ToShortString()
        {
            String text = "Исследовательские команды:\n";
            foreach (ResearchTeam item in MyTeams)
            {
                text += (item.ToShortString() + "\n\n");
            }

            return text;
        }

        public void SortByTeam()
        {
            MyTeams.Sort((a, b) => a.CompareTo(b));
        }

        public void SortByTheme()
        {
            MyTeams.Sort(new ResearchTeam());
        }

        public void SortByPublications()
        {
            MyTeams.Sort(new ResearchTeamComparer());
        }

        public int MinNumber
        {
            get
            {
                if (MyTeams.Count > 0)
                    return MyTeams.Min(x => x.Number);
                return -1;
            }
        }

        public IEnumerable<ResearchTeam> researchTeams
        {
            get
            {
                return MyTeams.Where(x => x.Time == TimeFrame.TwoYears);
            }
        }

        public List<ResearchTeam> CountPeople(int value)
        {
            var team = (from t in MyTeams
                              where t.People.Count == value
                              select t).ToList();
            return team;
        }

        public IEnumerable<IGrouping<int, ResearchTeam>> NGroup()
        {
            return MyTeams.GroupBy(x => x.Publications.Count);
        }


    }
}
