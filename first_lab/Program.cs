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
            //Сравнение элементов

            //Team t1 = new Team("МИЭТ", 123);
            //Team t2 = new Team("МИЭТ", 123);

            //Console.WriteLine((object)t1 == (object)t2);
            //Console.WriteLine(t1.Equals(t2));
            //Console.WriteLine(t1.GetHashCode());
            //Console.WriteLine(t2.GetHashCode());

            // Обработка некорректного регистрационного номер

            //Team t = new Team();
            //try
            //{
            //    t.Number = -3;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);

            //}

            ResearchTeam res = new ResearchTeam();

            // Добавление участников и публикаций
            //Paper[] papers = { new Paper("Механика", new Person("Иван", "Иванов", new DateTime(2020, 08, 22)), new DateTime(2024, 08, 22)), new Paper("Термодинамика", new Person("Петров", "Петр", new DateTime(2021, 08, 22)), new DateTime(2021, 08, 22)) };
            //res.AddPapers(papers);
            //Person[] people = { new Person("Иван", "Иванов", new DateTime(1970, 03, 13)), new Person("Сидоров", "Степан", new DateTime(1980, 04, 15)), new Person("Михайлов", "Михаил", new DateTime(1990, 12, 13)) };
            //res.AddMembers(people);
            //Console.WriteLine(res);


            // Вывод значение Team
            //Console.WriteLine(res.OurTeam);


            // Проверка DeepCopy()
            //ResearchTeam res2 = (ResearchTeam) res.DeepCopy();
            //Console.WriteLine("Данные до изменения\n");
            //Console.WriteLine(res);
            //Console.WriteLine(res2);
            //res.Number = 123;
            //Console.WriteLine("Данные после изменения\n");
            //Console.WriteLine(res);
            //Console.WriteLine(res2);


            //Итератор участников
            //Paper[] papers = { new Paper("Механика", new Person("Иван", "Иванов", new DateTime(1970, 03, 13)), new DateTime(2015, 08, 22)), new Paper("Термодинамика", new Person("Петров", "Петр", new DateTime(2021, 08, 22)), new DateTime(2021, 08, 22)), new Paper("Оптика", new Person("Иван", "Иванов", new DateTime(1970, 03, 13)), new DateTime(2020, 08, 22)) };
            //res.AddPapers(papers);
            //Person[] people = { new Person("Сидоров", "Степан", new DateTime(1980, 04, 15)), new Person("Михайлов", "Михаил", new DateTime(1990, 12, 13)), new Person("Иван", "Иванов", new DateTime(1970, 03, 13)) };
            //res.AddMembers(people);
            //foreach (Person item in res.GetPeopleWithoutPublications())
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("\n");
            //foreach (Person item in res.GetPeopleWithPublications())
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("\n");
            //foreach (Person item in res.GetPeopleWithManyPublications())
            //{
            //    Console.WriteLine(item);
            //}


            //Итератор публикаций за последние n лет
            Paper[] papers = { new Paper("Механика", new Person("Иван", "Иванов", new DateTime(1970, 03, 13)), new DateTime(2015, 08, 22)), new Paper("Термодинамика", new Person("Петров", "Петр", new DateTime(2021, 08, 22)), new DateTime(2021, 08, 22)), new Paper("Оптика", new Person("Иван", "Иванов", new DateTime(1970, 03, 13)), new DateTime(2020, 08, 22)) };
            res.AddPapers(papers);
            Console.WriteLine("Введите число, указывающие на то, за сколько последних лет нужно вывести публикации");
            int n = Int32.Parse(Console.ReadLine());
            foreach (Paper item in res.GetPublications(n))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");
            foreach (Paper item in res.GetLatestPublications())
            {
                Console.WriteLine(item);
            }
        }
    }
}
