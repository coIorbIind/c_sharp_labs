using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace first_lab
{
    
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeam first = new ResearchTeam("Deep Learning", "Hack", 123, TimeFrame.TwoYears);
            ResearchTeam second = new ResearchTeam("Machine Learning", "MIET", 456, TimeFrame.Long);
            ResearchTeam third = new ResearchTeam("Learning", "VSHE", 678, TimeFrame.TwoYears);
            ResearchTeam fourth = new ResearchTeam("Maths", "MFTI", 980, TimeFrame.Year);

            ResearchTeamCollection<string> firstResearchTeam = new ResearchTeamCollection<string>(ResearchTeamCollection<string>.GenerateKey);
            ResearchTeamCollection<string> secondResearchTeam = new ResearchTeamCollection<string>(ResearchTeamCollection<string>.GenerateKey);

            TeamsJournal<string> teamsJournal = new TeamsJournal<string>();


            firstResearchTeam.ResearchTeamsChanged += teamsJournal.ResearchTeamsChangedHandler;
            secondResearchTeam.ResearchTeamsChanged += teamsJournal.ResearchTeamsChangedHandler;


            firstResearchTeam.Name = "First Collection";
            firstResearchTeam.AddResearchTeams(first, second);

          
            secondResearchTeam.Name = "Second Collection";
            secondResearchTeam.AddResearchTeams(third, fourth);


            first.Organization = "MIET";
            second.Time = TimeFrame.Long;
            third.Organization = "Gimnazia";
            fourth.Time = TimeFrame.Year;

            firstResearchTeam.Remove(first);
            secondResearchTeam.Remove(fourth);

            first.Time = TimeFrame.TwoYears;
            fourth.Organization = "Name";

            firstResearchTeam.Replace(first, fourth);
            first.Organization = "Test";

            Console.WriteLine(teamsJournal);

            //Console.WriteLine("---------------------Публикации до сортировки---------------------");
            //foreach (Paper item in res.Publications)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("---------------------После сортировки по дате издания---------------------");
            //res.SortByDate();
            //foreach (Paper item in res.Publications)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("---------------------После сортировки по названию---------------------");
            //res.SortByName();
            //foreach (Paper item in res.Publications)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("---------------------После сортировки по фамилии автора---------------------");
            //res.SortByAuthor();
            //foreach (Paper item in res.Publications)
            //{
            //    Console.WriteLine(item);
            //}

            ////KeySelector<string> ke = delegate (ResearchTeam r)
            ////{
            ////    return r.Organization;
            ////};

            //Console.WriteLine("---------------------ResearchTeamCollection---------------------");

            //ResearchTeamCollection<string> collection = new ResearchTeamCollection<string>(ResearchTeamCollection<string>.GenerateKey);
            //collection.AddDefaults(res);
            //collection.AddResearchTeams(res2);
            //Console.WriteLine(collection);

            //Console.WriteLine($"Дата выхода самой поздней публикации: {collection.latest.ToShortDateString()}");

            //Console.WriteLine("----------------------------------------------------------------");

            //Console.WriteLine("Подмножество исследований продолжительностью 2 года");
            //foreach (ResearchTeam item in collection.TimeFrameGroup(TimeFrame.TwoYears).ToDictionary(x => x.Key, x => x.Value).Values)
            //{
            //    Console.WriteLine(item.ToShortString());
            //}

            ////Группировка по продолжительности исследований

            //foreach (var item in collection.NGroup())
            //{
            //    Console.WriteLine($"Время исследований в данной группе равно {item.Key}");
            //    Console.WriteLine("-------------------------------------------------------");
            //    foreach (ResearchTeam j in item.ToDictionary(x => x.Key, x => x.Value).Values)
            //    {
            //        Console.WriteLine(j.ToShortString());
            //    }

            //}

            //int n;
            //Console.WriteLine("Введите количество элементов");
            //while (true)
            //{
            //    bool flag = int.TryParse(Console.ReadLine(), out n);
            //    if (!flag || n < 1)
            //    {
            //        Console.WriteLine("Некорректный ввод, попробуйте снова");
            //    }
            //    else
            //        break;
            //}

            ////GenerateElement<Team, ResearchTeam> d = delegate (int j)
            ////{
            ////    Random rand = new Random();
            ////    string[] themes = { "Загрязнение окружающей среды", "Наводнения", "Пожары", "Сбор урожая", "Глобальное потепление", "Таяние ледников", "Наращивание ресниц" };
            ////    string[] organizations = { "Holding.WWW.Ru", "Всё для дома", "Мир животных", "Sustainability Corporation", "ГЕНЧ", "Абаркадабра" };
            ////    ResearchTeam obj = new ResearchTeam(themes[rand.Next(themes.Length)], organizations[rand.Next(organizations.Length)], rand.Next(), TimeFrame.Long);

            ////    var key = obj.OurTeam;
            ////    var value = obj;
            ////    return new KeyValuePair<Team, ResearchTeam>(key, value);
            ////};


            //TestCollections<Team, ResearchTeam> test = new TestCollections<Team, ResearchTeam>(TestCollections<Team, ResearchTeam>.GenerateElement, n);
            //test.TestLists();
            //Console.WriteLine();
            //test.TestDictsKeys();
            //Console.WriteLine();
            //test.TestDictsValues();
        }
    }
}
