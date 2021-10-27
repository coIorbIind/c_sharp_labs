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
        private GenerateElement<TKey, TValue> generateElement;
        List<TKey> teams = new List<TKey>();
        List<string> names = new List<string>();
        Dictionary<TKey, TValue> TKeyTValuePairs = new Dictionary<TKey, TValue>();
        Dictionary<string, TValue> StringTValuePairs = new Dictionary<string, TValue>();

        public TestCollections(GenerateElement<TKey, TValue> key_value, int n)
        {
            //this.my_key_value = key_value;
            //teams = new List<TKey>();
            //names = new List<string>();
            //TeamResearchTeamPairs = new Dictionary<TKey, TValue>();
            //StringResearchTeamPairs = new Dictionary<string, TValue>();
            //for (int i = 0; i < n; i++)
            //{
            //    ResearchTeam obj = Generation();
            //    if (names.Contains(obj.Organization))
            //        obj.Organization += $"_{i}";
            //    teams.Add((obj.OurTeam);
            //    names.Add(obj.Organization);
            //    TeamResearchTeamPairs.Add(obj.OurTeam, obj);
            //    StringResearchTeamPairs.Add(obj.Organization, obj);
            //}
            generateElement = key_value;

            for (int i = 0; i < n; i++)
            {
                var item = generateElement(i);
                teams.Add(item.Key);
                names.Add(item.Key.ToString());
                TKeyTValuePairs.Add(item.Key, item.Value);
                StringTValuePairs.Add(item.Key.ToString(), item.Value);
                
            }

        }


        public static KeyValuePair<Team, ResearchTeam> GenerateElement(int j)
        {
            Random rand = new Random();
            string[] themes = { "Загрязнение окружающей среды", "Наводнения", "Пожары", "Сбор урожая", "Глобальное потепление", "Таяние ледников", "Наращивание ресниц" };
            string[] organizations = { "Holding.WWW.Ru", "Всё для дома", "Мир животных", "Sustainability Corporation", "ГЕНЧ", "Абаркадабра" };
            ResearchTeam obj = new ResearchTeam(themes[rand.Next(themes.Length)], organizations[rand.Next(organizations.Length)], rand.Next(), TimeFrame.Long);
            obj.Organization += $"_{j}";
            var key = obj.OurTeam;
            var value = obj;
            return new KeyValuePair<Team, ResearchTeam>(key, value);
        }

        //public static KeyValuePair<TKey, TValue> GenerateKey(KeyValuePair<TKey, TValue> keyValuePair)
        //{
        //    return keyValuePair;
        //}


        public TestCollections()
        {
            teams = new List<TKey>();
            names = new List<string>();
            TKeyTValuePairs = new Dictionary<TKey, TValue>();
            StringTValuePairs = new Dictionary<string, TValue>();
        }

        public static ResearchTeam Generation()
        {
            Random rand = new Random();
            string[] themes = { "Загрязнение окружающей среды", "Наводнения", "Пожары", "Сбор урожая", "Глобальное потепление", "Таяние ледников", "Наращивание ресниц" };
            string[] organizations = { "Holding.WWW.Ru", "Всё для дома", "Мир животных", "Sustainability Corporation", "ГЕНЧ", "Абаркадабра" };
            return new ResearchTeam(themes[rand.Next(themes.Length)], organizations[rand.Next(organizations.Length)], rand.Next(), TimeFrame.Long);
        }

        public void TestLists()
        {
            bool f;
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("-------------------------------Тест List<Team>-------------------------------");
            sw.Start();
            f = teams.Contains(teams[0]);
            sw.Stop();
            Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = teams.Contains(teams[teams.Count - 1]);
            sw.Stop();
            Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = teams.Contains(teams[teams.Count / 2]);
            sw.Stop();
            Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            var empty = generateElement(teams.Count + 1).Key;
            f = teams.Contains(empty);
            sw.Stop();
            Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");


            Console.WriteLine("-------------------------------Тест List<string>-------------------------------");
            sw.Reset();
            sw.Start();
            f = names.Contains(names[0]);
            sw.Stop();
            Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = names.Contains(names[names.Count - 1]);
            sw.Stop();
            Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = names.Contains(names[names.Count / 2]);
            sw.Stop();
            Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
            string name = "dfssdfs";
            sw.Reset();
            sw.Start();
            f = names.Contains(name);
            sw.Stop();
            Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");
        }

        public void TestDictsKeys()
        {
            bool f;
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("-------------------------------Тест Dictionary<Team, ResearchTeam>-------------------------------");
            sw.Start();
            f = TKeyTValuePairs.ContainsKey(teams[0]);
            sw.Stop();
            Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = TKeyTValuePairs.ContainsKey(teams[teams.Count - 1]);
            sw.Stop();
            Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = TKeyTValuePairs.ContainsKey(teams[teams.Count / 2]);
            sw.Stop();
            Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            var empty = generateElement(TKeyTValuePairs.Count + 1).Key;
            f = TKeyTValuePairs.ContainsKey(empty);
            sw.Stop();
            Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");


            Console.WriteLine("-------------------------------Тест Dictionary<string, ResearchTeam>-------------------------------");
            sw.Reset();
            sw.Start();
            f = StringTValuePairs.ContainsKey(names[0]);
            sw.Stop();
            Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = StringTValuePairs.ContainsKey(names[names.Count - 1]);
            sw.Stop();
            Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = StringTValuePairs.ContainsKey(names[names.Count / 2]);
            sw.Stop();
            Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
            string name = "dfssdfs";
            sw.Reset();
            sw.Start();
            f = StringTValuePairs.ContainsKey(name);
            sw.Stop();
            Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");
        }

        public void TestDictsValues()
        {
            bool f;
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("-------------------------------Тест Dictionary<Team, ResearchTeam>-------------------------------");
            sw.Start();
            f = TKeyTValuePairs.ContainsValue(TKeyTValuePairs[teams[0]]);
            sw.Stop();
            Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = TKeyTValuePairs.ContainsValue(TKeyTValuePairs[teams[teams.Count - 1]]);
            sw.Stop();
            Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = TKeyTValuePairs.ContainsValue(TKeyTValuePairs[teams[teams.Count / 2]]);
            sw.Stop();
            Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            var empty = generateElement(TKeyTValuePairs.Count + 1).Value;
            f = TKeyTValuePairs.ContainsValue(empty);
            sw.Stop();
            Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");


            Console.WriteLine("-------------------------------Тест Dictionary<string, ResearchTeam>-------------------------------");
            sw.Reset();
            sw.Start();
            f = StringTValuePairs.ContainsValue(StringTValuePairs[names[0]]);
            sw.Stop();
            Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = StringTValuePairs.ContainsValue(StringTValuePairs[names[names.Count - 1]]);
            sw.Stop();
            Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = StringTValuePairs.ContainsValue(StringTValuePairs[names[names.Count / 2]]);
            sw.Stop();
            Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            var none = generateElement(StringTValuePairs.Count + 1).Value;
            f = StringTValuePairs.ContainsValue(none);
            sw.Stop();
            Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");
        }

    }
      
}
