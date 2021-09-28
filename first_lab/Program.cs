using System;
using System.Linq;
using System.Diagnostics;

namespace first_lab
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    ResearchTeam res = new ResearchTeam(); // создание нового объекта
        //    Console.WriteLine(res.ToShortString()); // вывод информации по умалчанию
        //                                            // заполнение полей
        //    res.Theme = "Физика";
        //    res.Organization = "МИЭТ";
        //    res.Number = 12345;
        //    res.Time = TimeFrame.Year;
        //    Paper[] papers = { new Paper("Механика", new Person("Иван", "Иванов", new DateTime(2020, 08, 22)), new DateTime(2024, 08, 22)), new Paper("Термодинамика", new Person("Петров", "Петр", new DateTime(2021, 08, 22)), new DateTime(2021, 08, 22)) };
        //    res.AddPapers(papers);
        //    // вывод значений индексатора
        //    Console.WriteLine($"Индексатор TimeFrame.Year: {res[TimeFrame.Year]}");
        //    Console.WriteLine($"Индексатор TimeFrame.TwoYears: {res[TimeFrame.TwoYears]}");
        //    Console.WriteLine($"Индексатор TimeFrame.Long: {res[TimeFrame.Long]}\n");
        //    Console.WriteLine(res.ToString()); // вывод информации
        //    Console.WriteLine(res.latest); // вывод последней публикации

        //    //Получение данных для тестирования
        //    Console.WriteLine("Введите число строк и столбцов, разделяя числа одним из разделителей: ' ', '.', '-'");
        //    // Выделение числа строк и столбцов
        //    string str = Console.ReadLine();
        //    string[] arr = str.Split(' ', '.', '-');

        //    Stopwatch sw = new Stopwatch();

        //    int rows = int.Parse(arr[0]);
        //    int cols = int.Parse(arr[1]);

        //    //Инициализация одномерного массива
        //    ResearchTeam[] arr_one = new ResearchTeam[rows * cols];
        //    for (int i = 0; i < rows * cols; i++)
        //    {
        //        arr_one[i] = new ResearchTeam();
        //    }

        //    //Инициализация двумерного массива
        //    ResearchTeam[,] arr_two = new ResearchTeam[rows, cols];
        //    for (int i = 0; i < rows; i++)
        //        for (int j = 0; j < cols; j++)
        //        {
        //            arr_two[i, j] = new ResearchTeam();
        //        }

        //    //Инициализация ступенчатого массива
        //    ResearchTeam[][] arr_step = new ResearchTeam[rows][];
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        arr_step[i] = new ResearchTeam[2 * i + 1];
        //        for (int j = 0; j < 2 * i + 1; j++)
        //        {
        //            arr_step[i][j] = new ResearchTeam();
        //        }
        //    }

        //    //Подсчет времени для одномерного массива
        //    sw.Start();
        //    for (int i = 0; i < rows * cols; i++)
        //    {
        //        arr_one[i].Theme = "Физика";
        //    }
        //    sw.Stop();
        //    Console.WriteLine($"Время выполнения программы для одномерного массива: {sw.Elapsed}");

        //    //Подсчет времени для двумерного массива
        //    sw.Start();
        //    for (int i = 0; i < rows; i++)
        //        for (int j = 0; j < cols; j++)
        //        {
        //            arr_two[i, j].Theme = "Физика";
        //        }
        //    sw.Stop();
        //    Console.WriteLine($"Время выполнения программы для двумерного массива: {sw.Elapsed}");

        //    //Подсчет времени для ступенчатого массива
        //    sw.Start();
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        for (int j = 0; j < 2 * i + 1; j++)
        //        {
        //            arr_step[i][j].Theme = "Физика";
        //        }
        //    }
        //    sw.Stop();
        //    Console.WriteLine($"Время выполнения программы для ступенчатого массива: {sw.Elapsed}");

        ///*
        //Console.WriteLine("Введите тему исследований");
        //res.Theme = Console.ReadLine();
        //Console.WriteLine("Введите название организации");
        //res.Organization = Console.ReadLine();
        //Console.WriteLine("Введите номер организации");
        //int number;
        //while (true)
        //{
        //    bool flag = Int32.TryParse(Console.ReadLine(), out number);
        //    if (!flag)
        //    {
        //        Console.WriteLine("Некорректный ввод, попробуйте снова");
        //    }
        //    else
        //        break;
        //}
        //res.Number = number;
        //Console.WriteLine("Введите продолжительность исследований");
        //int time;
        //while (true)
        //{
        //    bool flag = Int32.TryParse(Console.ReadLine(), out time);
        //    if (flag && time > 0)
        //    {
        //        switch (time)
        //        {
        //            case 1:
        //                res.Time = TimeFrame.Year;
        //                break;

        //            case 2:
        //                res.Time = TimeFrame.TwoYears;
        //                break;
        //            default:
        //                res.Time = TimeFrame.Long;
        //                break;
        //        }
        //        break;
        //    }

        //    else
        //    {
        //        Console.WriteLine("Некорректный ввод, попробуйте снова");
        //    }

        //}

        //Console.WriteLine("Введите количество публикаций");
        //while (true)
        //{
        //    bool flag = Int32.TryParse(Console.ReadLine(), out number);
        //    if (!flag)
        //    {
        //        Console.WriteLine("Некорректный ввод, попробуйте снова");
        //    }
        //    else
        //        break;
        //}
        //Paper[] papers = new Paper[number];
        //for (int i = 0; i < number; i++)
        //{
        //    Paper p = new Paper();
        //    Console.WriteLine("Введите название публикации");
        //    p.Name = Console.ReadLine();
        //    p.Person = new Person();
        //    Console.WriteLine("Введите фамилию исследователя");
        //    p.Person.Surname = Console.ReadLine();
        //    Console.WriteLine("Введите имя исследователя");
        //    p.Person.Name = Console.ReadLine();
        //    Console.WriteLine("Введите дату начала исследования, разделяя день месяц и год точкой");
        //    string[] date_str = Console.ReadLine().Split(".");
        //    int[] date_int = new int[3];
        //    for (int j = 0; j < 3; j++)
        //    {
        //        date_int[j] = Int32.Parse(date_str[j]);
        //    }
        //    p.Date = new DateTime(date_int[2], date_int[1], date_int[0]);
        //    papers[i] = p;
        //}

        //res.AddPapers(papers);


        //Console.WriteLine(res.ToString());
        //*/

        //}


        static void Main(string[] args)
        {
            ResearchTeam res = new ResearchTeam();
            res.Number = 400;
            //Добавление участников и публикаций
            Paper[] papers = { new Paper("Механика", new Person("Иван", "Иванов", new DateTime(2020, 08, 22)), new DateTime(2024, 08, 22)), new Paper("Термодинамика", new Person("Петров", "Петр", new DateTime(2021, 08, 22)), new DateTime(2021, 08, 22)) };
            res.AddPapers(papers);
            Person[] people = { new Person("Иван", "Иванов", new DateTime(1970, 03, 13)), new Person("Сидоров", "Степан", new DateTime(1980, 04, 15)), new Person("Михайлов", "Михаил", new DateTime(1990, 12, 13)) };
            res.AddMembers(people);

            ResearchTeam res2 = new ResearchTeam();

            //Добавление участников и публикаций
            Paper[] papers_2 = { new Paper("Информатика", new Person("Иван", "Иванов", new DateTime(2020, 08, 22)), new DateTime(2024, 08, 22)), new Paper("Физика", new Person("Петров", "Петр", new DateTime(2021, 08, 22)), new DateTime(2021, 08, 22)) };
            res2.AddPapers(papers);
            Person[] people_2 = { new Person("Иван", "Иванов", new DateTime(1970, 03, 13)), new Person("Сидоров", "Степан", new DateTime(1980, 04, 15)), new Person("Михайлов", "Михаил", new DateTime(1990, 12, 13)) };
            res2.AddMembers(people);
            res2.Number = 500;
            res2.Theme = "Машинное обучение";
            res2.Time = TimeFrame.TwoYears;

            //Создание ResearchTeamCollection
            ResearchTeamCollection collection = new ResearchTeamCollection();
            collection.AddDefaults(res);
            collection.AddResearchTeams(res2);

            //Сортировка по номеру регистрации

            //Console.WriteLine(collection.ToShortString());
            //Console.WriteLine("--------------------------После сортировки---------------------------------");
            //collection.SortByTeam();
            //Console.WriteLine(collection.ToShortString());

            //Сортировка по теме исследований

            //Console.WriteLine(collection.ToShortString());
            //Console.WriteLine("--------------------------После сортировки---------------------------------");
            //collection.SortByTheme();
            //Console.WriteLine(collection.ToShortString());

            //Сортировка по количеству публикаций

            //res.AddPapers(new Paper("Анализ данных", new Person("Иван", "Пупкин", new DateTime(2020, 08, 22)), new DateTime(2024, 08, 22)));
            //Console.WriteLine(collection.ToString());
            //Console.WriteLine("--------------------------После сортировки---------------------------------");
            //collection.SortByPublications();
            //Console.WriteLine(collection.ToString());

            //Вывод минимального номера регистрации

            //Console.WriteLine(collection.MinNumber);

            //Вывод исследовательский групп с продолжительностью исследований два года

            //foreach (ResearchTeam item in collection.researchTeams)
            //{
            //    Console.WriteLine(item.ToShortString());
            //}

            //Вывод исследовательский групп с заданным количество участников
            //foreach (ResearchTeam item in collection.CountPeople(3)
            //{
            //        Console.WriteLine(item.ToShortString());
            //}

            //Группировка по числу публикаций

            //foreach (IGrouping<int, ResearchTeam> item in collection.NGroup())
            //{
            //    Console.WriteLine($"Количество публикаций в данной группе равно {item.Key}");
            //    Console.WriteLine("-------------------------------------------------------");
            //    foreach (ResearchTeam j in item)
            //    {
            //        Console.WriteLine(j.ToShortString());
            //    }

            //}

        }
    }
}
