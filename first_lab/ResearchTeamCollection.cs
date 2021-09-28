using System;
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
    }
}
