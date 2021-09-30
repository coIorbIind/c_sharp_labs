using System;
using System.Collections.Generic;
using System.Text;


namespace first_lab
{
    class TestCollections
    {
        List<Team> teams;
        List<string> names;
        Dictionary<Team, ResearchTeam> TeamResearchTeamPairs;
        Dictionary<string, ResearchTeam> StringResearchTeamPairs;


        public TestCollections(int n)
        {
            for (int i = 0; i < n; i++)
            {
                ResearchTeam obj = Generation();
                teams.Add(obj.OurTeam);
                names.Add(obj.Organization);
                TeamResearchTeamPairs.Add(obj.OurTeam, obj);
                //Stri
            }

        }

        public static ResearchTeam Generation()
        {
            Random rand = new Random();
            string[] themes = { "Загрязнение окружающей среды", "Наводнения", "Пожары", "Сбор урожая", "Глобальное потепление", "Таяние ледников", "Наращивание ресниц" };
            string[] organizations = {"Holding.WWW.Ru", "Всё для дома", "Мир животных", "Sustainability Corporation", "ГЕНЧ"}; 
            return new ResearchTeam(themes[rand.Next(themes.Length)], organizations[rand.Next(organizations.Length)], rand.Next(), TimeFrame.Long);
        }
    }
      
}
