using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;


namespace first_lab
{
    delegate System.Collections.Generic.KeyValuePair<TKey, TValue>
        GenerateElement<TKey, TValue>(int j);
    class TestCollections<TKey, TValue>
    {
        GenerateElement<TKey, TValue> my_key_value;
        List<TKey> teams;
        List<string> names;
        Dictionary<TKey, TValue> TeamResearchTeamPairs;
        Dictionary<string, TValue> StringResearchTeamPairs;

        public TestCollections(GenerateElement<TKey, TValue> key_value, int n)
        {
            this.my_key_value = key_value;
            teams = new List<TKey>();
            names = new List<string>();
            TeamResearchTeamPairs = new Dictionary<TKey, TValue>();
            StringResearchTeamPairs = new Dictionary<string, TValue>();
            for (int i = 0; i < n; i++)
            {
                ResearchTeam obj = Generation();
                if (names.Contains(obj.Organization))
                    obj.Organization += $"_{i}";
                teams.Add(obj.OurTeam);
                names.Add(obj.Organization);
                TeamResearchTeamPairs.Add(obj.OurTeam, obj);
                StringResearchTeamPairs.Add(obj.Organization, obj);
            }
        }

        public static KeyValuePair<TKey, TValue> GenerateKey(KeyValuePair<TKey, TValue> keyValuePair)
        {
            return keyValuePair;
        }


        //public TestCollections()
        //{
        //    teams = new List<Team>();
        //    names = new List<string>();
        //    TeamResearchTeamPairs = new Dictionary<Team, ResearchTeam>();
        //    StringResearchTeamPairs = new Dictionary<string, ResearchTeam>();
        //}

        public static ResearchTeam Generation()
        {
            Random rand = new Random();
            string[] themes = { "Загрязнение окружающей среды", "Наводнения", "Пожары", "Сбор урожая", "Глобальное потепление", "Таяние ледников", "Наращивание ресниц" };
            string[] organizations = { "Holding.WWW.Ru", "Всё для дома", "Мир животных", "Sustainability Corporation", "ГЕНЧ", "Абаркадабра" };
            return new ResearchTeam(themes[rand.Next(themes.Length)], organizations[rand.Next(organizations.Length)], rand.Next(), TimeFrame.Long);
        }

        //public void TestLists()
        //{
        //    bool f;
        //    Stopwatch sw = new Stopwatch();
        //    Console.WriteLine("-------------------------------Тест List<Team>-------------------------------");
        //    sw.Start();
        //    f = teams.Contains(teams[0]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = teams.Contains(teams[teams.Count - 1]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = teams.Contains(teams[teams.Count / 2]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = teams.Contains(new Team());
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");


        //    Console.WriteLine("-------------------------------Тест List<string>-------------------------------");
        //    sw.Reset();
        //    sw.Start();
        //    f = names.Contains(names[0]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = names.Contains(names[names.Count - 1]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = names.Contains(names[names.Count / 2]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
        //    string name = "dfssdfs";
        //    sw.Reset();
        //    sw.Start();
        //    f = names.Contains(name);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");
        //}

        //public void TestDictsKeys()
        //{
        //    bool f;
        //    Stopwatch sw = new Stopwatch();
        //    Console.WriteLine("-------------------------------Тест Dictionary<Team, ResearchTeam>-------------------------------");
        //    sw.Start();
        //    f = TeamResearchTeamPairs.ContainsKey(teams[0]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = TeamResearchTeamPairs.ContainsKey(teams[teams.Count - 1]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = TeamResearchTeamPairs.ContainsKey(teams[teams.Count / 2]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = TeamResearchTeamPairs.ContainsKey(new Team());
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");


        //    Console.WriteLine("-------------------------------Тест Dictionary<string, ResearchTeam>-------------------------------");
        //    sw.Reset();
        //    sw.Start();
        //    f = StringResearchTeamPairs.ContainsKey(names[0]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = StringResearchTeamPairs.ContainsKey(names[names.Count - 1]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = StringResearchTeamPairs.ContainsKey(names[names.Count / 2]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
        //    string name = "dfssdfs";
        //    sw.Reset();
        //    sw.Start();
        //    f = StringResearchTeamPairs.ContainsKey(name);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");
        //}

        //public void TestDictsValues()
        //{
        //    bool f;
        //    Stopwatch sw = new Stopwatch();
        //    Console.WriteLine("-------------------------------Тест Dictionary<Team, ResearchTeam>-------------------------------");
        //    sw.Start();
        //    f = TeamResearchTeamPairs.ContainsValue(TeamResearchTeamPairs[teams[0]]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = TeamResearchTeamPairs.ContainsValue(TeamResearchTeamPairs[teams[teams.Count - 1]]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = TeamResearchTeamPairs.ContainsValue(TeamResearchTeamPairs[teams[teams.Count / 2]]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = TeamResearchTeamPairs.ContainsValue(new ResearchTeam());
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");


        //    Console.WriteLine("-------------------------------Тест Dictionary<string, ResearchTeam>-------------------------------");
        //    sw.Reset();
        //    sw.Start();
        //    f = StringResearchTeamPairs.ContainsValue(StringResearchTeamPairs[names[0]]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = StringResearchTeamPairs.ContainsValue(StringResearchTeamPairs[names[names.Count - 1]]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = StringResearchTeamPairs.ContainsValue(StringResearchTeamPairs[names[names.Count / 2]]);
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
        //    sw.Reset();
        //    sw.Start();
        //    f = StringResearchTeamPairs.ContainsValue(new ResearchTeam());
        //    sw.Stop();
        //    Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");
        //}

    }
      
}
