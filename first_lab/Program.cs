using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace first_lab
{
    
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeam first = new ResearchTeam("Deep Learning", "Hack", 123, TimeFrame.TwoYears); //Создание объекта
            first.AddPapers(new Paper()); //Добавление публикации


            ResearchTeam second = new ResearchTeam();
            // Создание копии
            try
            {
                second = (ResearchTeam)first.DeepCopy();
            }
            catch
            {
                Console.WriteLine("Возникли проблемы при создании копии");
            }
            Console.WriteLine("Первоначальный объект");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(first);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Скопированный объект");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(second);
            Console.WriteLine("------------------------------------------------------------------------------------------------");



            Console.WriteLine("Введите название файла (без указания расширения)");
            string FileName = Console.ReadLine();
            if (File.Exists(FileName + ".bin"))
            {
                if (second.Load(FileName + ".bin"))
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Загруженный объект");
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine(second);
                }
                else
                    Console.WriteLine("Не удалось загрузить объект");
            }
            else
            {
                Console.WriteLine("Файл не найден!");
                try
                {
                    File.Create(FileName + ".bin");
                    Console.WriteLine("Файл успешно создан");
                }
                catch
                {
                    Console.WriteLine("Возникли ошибки при создании файла");
                }

            }
            Console.WriteLine("------------------------------------------------------------------------------------------------");


            if (second.AddFromConsole())
            {
                Console.WriteLine("Публикация успешно добавлена");
                if (second.Save(FileName))
                {
                    Console.WriteLine("Файл успешно сохранен");
                    Console.WriteLine(second);
                }
                else
                    Console.WriteLine("Возникли проблемы при сохранении файла");
            }
                
            else
                Console.WriteLine("Возникли проблемы при добавлении публикации");
            
            
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            if (ResearchTeam.Load(FileName, ref second))
            {
                Console.WriteLine("Файл успешно считан");
                Console.WriteLine(second);
            }
            else
                Console.WriteLine("Возникли проблемы при чтении файла");
            if (second.AddFromConsole())
                Console.WriteLine("Публикация успешно добавлена");
            else
                Console.WriteLine("Возникли проблемы при добавлении публикации");
            if (ResearchTeam.Save(FileName, second))
            {
                Console.WriteLine("Файл успешно сохранен");
                Console.WriteLine(second);
            }
            else
                Console.WriteLine("Возникли проблемы при сохранении файла");
        }
    }
}
