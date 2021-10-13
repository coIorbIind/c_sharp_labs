using System;
using System.Linq;
using System.Diagnostics;

namespace first_lab
{
    
    class Program
    {
        public enum Enum2: byte
        {
            A,
            B,
            C,
            D
        }
        static void Main(string[] args)
        {
            Console.WriteLine((byte) (Enum2.B | Enum2.D));
            //ResearchTeam res = new ResearchTeam();
            //res.Number = 400;
            ////Добавление участников и публикаций
            //Paper[] papers = { new Paper("Механика", new Person("Иван", "Иванов", new DateTime(2020, 08, 22)), new DateTime(2024, 08, 22)), new Paper("Термодинамика", new Person("Петров", "Петр", new DateTime(2021, 08, 22)), new DateTime(2021, 08, 22)) };
            //res.AddPapers(papers);
            //Person[] people = { new Person("Иван", "Иванов", new DateTime(1970, 03, 13)), new Person("Сидоров", "Степан", new DateTime(1980, 04, 15)), new Person("Михайлов", "Михаил", new DateTime(1990, 12, 13)) };
            //res.AddMembers(people);

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

            //ResearchTeam res2 = new ResearchTeam();
            //res2.Organization = "МГУ";
            ////Добавление участников и публикаций
            //Paper[] papers_2 = { new Paper("Информатика", new Person("Иван", "Иванов", new DateTime(2020, 08, 22)), new DateTime(2024, 08, 22)), new Paper("Физика", new Person("Петров", "Петр", new DateTime(2021, 08, 22)), new DateTime(2021, 08, 22)) };
            //res2.AddPapers(papers);
            //Person[] people_2 = { new Person("Иван", "Иванов", new DateTime(1970, 03, 13)), new Person("Сидоров", "Степан", new DateTime(1980, 04, 15)), new Person("Михайлов", "Михаил", new DateTime(1990, 12, 13)) };
            //res2.AddMembers(people);
            //res2.Number = 500;
            //res2.Theme = "Машинное обучение";
            //res2.Time = TimeFrame.TwoYears;

            //ResearchTeamCollection<string> collection = new ResearchTeamCollection<string>(ResearchTeamCollection<string>.GenerateKey);
            //collection.AddDefaults(res);
            //collection.AddResearchTeams(res2);
            //Console.WriteLine(collection);


            //Console.WriteLine($"Дата выхода самой поздней публикации: {collection.latest.ToShortDateString()}");

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

            //TestCollections test = new TestCollections(1000);
            //test.TestLists();
            //Console.WriteLine();
            //test.TestDictsKeys();
            //Console.WriteLine();
            //test.TestDictsValues();
        }
    }
}
