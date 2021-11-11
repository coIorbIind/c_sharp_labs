using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace first_lab
{
    enum Revision { Remove, Replace, Property, Add };
    enum TimeFrame { Year, TwoYears, Long };

    [Serializable]
    class ResearchTeam : Team, INameAndCopy, IEnumerable, IComparer<ResearchTeam>, System.ComponentModel.INotifyPropertyChanged
    {
        string theme;
        TimeFrame time;
        List<Person> people;
        List<Paper> publications;

        public event PropertyChangedEventHandler PropertyChanged;

        public ResearchTeam(string theme_value, string organization_value, int number_value, TimeFrame time_value) : base(organization_value, number_value) /// конструктор с параметрами
        {
            theme = theme_value;
            time = time_value;
            publications = new List<Paper>();
            people = new List<Person>();
        } // конструктор с параметрами

        public ResearchTeam() : this("Раскопки", "МИЭТ", 111, TimeFrame.Long) /// конструктор без параметров
        {
        } // конструктор по умолчанию

        public object DeepCopy()
        {
            MemoryStream stream = new MemoryStream();
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return formatter.Deserialize(stream);
            }
            catch
            {
                throw new Exception("Ошибка при сериализации");
            }
            finally
            {
                stream?.Close();
            }
        } // копия объекта класса ResearchTeam

        public bool Save(string filename)
        {
            Stream SaveFileStream = null;
            try
            {
                SaveFileStream = File.Create(filename);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(SaveFileStream, this);
                SaveFileStream.Close();
                return true;
            }
            catch
            {
                Console.WriteLine("Возникли проблемы при записи объекта");
                SaveFileStream?.Close();
                return false;
            }
            finally
            {
                SaveFileStream?.Close();
            }
        }//сохранение объекта в файл

        public bool Load(string filename)
        {
            if (File.Exists(filename))
            {
                Stream openFileStream = null;
                try
                {
                    ResearchTeam obj;
                    openFileStream = File.OpenRead(filename);
                    Console.WriteLine("Reading saved file");
                    BinaryFormatter deserializer = new BinaryFormatter();
                    obj = (ResearchTeam)deserializer.Deserialize(openFileStream);
                    openFileStream.Close();
                    OurTeam = (Team)obj.OurTeam.DeepCopy();
                    people = new List<Person>(obj.people);
                    publications = new List<Paper>(obj.publications);
                    Theme = obj.Theme;
                    Time = obj.Time;
                    return true;
                }
                catch
                {
                    Console.WriteLine("Возникли проблемы при записи объекта");
                    openFileStream?.Close();
                    return false;
                }
                finally
                {
                    openFileStream?.Close();
                }
            }
            return false;
        } //чтение объекта из файла

        public static bool Save(string filename, ResearchTeam obj) //статический метод для сохранения объекта
        {   
            Stream SaveFileStream = null;
            try
            {
                SaveFileStream = File.Create(filename);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(SaveFileStream, obj);
                SaveFileStream.Close();
                return true;
            }
            catch
            {
                Console.WriteLine("Возникли проблемы при записи объекта");
                SaveFileStream?.Close();
                return false;
            }
        }

        public static bool Load(string filename, ref ResearchTeam obj)
        {
            Stream openFileStream = null;
            try
            {
                if (File.Exists(filename))
                {
                    Console.WriteLine("Reading saved file");
                    openFileStream = File.OpenRead(filename);
                    BinaryFormatter deserializer = new BinaryFormatter();
                    obj = (ResearchTeam)deserializer.Deserialize(openFileStream);
                    openFileStream.Close();
                }
                return true;
            }
            catch
            {
                Console.WriteLine("Возникли проблемы при чтении объекта");
                openFileStream?.Close();
                return false;
            }
        } //чтение объекта из файла

        public bool AddFromConsole()
        {
            Console.WriteLine("Введите информацию о статье для добавления её в список публикаций.\nФормат входных данных\n" +
                "Название статьи $ Имя автора $ Фамилия автора $ Дата его рождения в формате dd.mm.year $ Дата публикации в формате dd.mm.year\n" +
                "Где $ - один из разделителей # , - ! $ ? /");
            string[] input_data = Console.ReadLine().Split('#', '-', '!', '$', '?', '/', ',');
            if (input_data.Length != 5)
            {
                Console.WriteLine("Неверное количество аргументов");
                return false;
            }
            else
            {
                try
                {
                    Paper p = new Paper();
                    p.Name = input_data[0];
                    p.Person.Surname = input_data[1];
                    p.Person.Name = input_data[2];
                    List<int> birth = new List<int>();
                    foreach(string item in input_data[3].Split('.'))
                    {
                        birth.Add(int.Parse(item));
                    }
                    p.Person.Date = new DateTime(birth[2], birth[1], birth[0]);
                    List<int> publishing = new List<int>();
                    foreach (string item in input_data[4].Split('.'))
                    {
                        publishing.Add(int.Parse(item));
                    }
                    p.Date = new DateTime(publishing[2], publishing[1], publishing[0]);
                    this.AddPapers(p);
                    return true;
                }
                catch
                {
                    Console.WriteLine("Некорректное значение одного или нескольких аргументов");
                    return false;
                }
            }
        }

        public string Theme
        {
            get
            {
                return theme;
            }

            set
            {
                theme = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Theme"));
            }
        } //свойство тема

        public TimeFrame Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Time"));
            }
        } //свойство дата начала исследований

        public List<Paper> Publications
        {
            get
            {
                return publications;
            }

            set
            {
                publications = new List<Paper>(value);
            }
        } // свойство публикации

        public List<Person> People
        {
            get
            {
                return people;
            }

            set
            {
                people = new List<Person>(value);
            }
        } // свойство участники

        public Team OurTeam
        {
            get
            {
                return new Team(this.Organization, this.Number);
            }

            set
            {
                this.Organization = value.Organization;
                this.Number = value.Number;
            }
        } // свойство взаимодействия с организацией и ее номером через объект базового класса

        public DateTime latest //получение последней публикации
        {
            get
            {
                if (Publications.Count > 0)
                {
                    return Publications.Max(x => x.Date);
                }

                return new DateTime();
            }


        }

        public void AddPapers(params Paper[] papers) //добавление новых публикаций
        {
            Publications.AddRange(papers);
        }

        public void AddMembers(params Person[] pep) //добавление новых участников
        {
            People.AddRange(pep);
        }

        public bool this[TimeFrame t]
        {
            get
            {
                return time == t;
            }
        } //индексатор по дате начала исследований

        public override string ToString() //перегруженный метод ToString()
        {
            string text = $"Тема исследований {Theme}.\nОрганизация {Organization}.\nРегистрационный номер {Number}.\nПродолжительность исследований {Time}.\n\nСписок публикаций: \n\n";

            foreach (Paper item in Publications)
            {
                text += $"{item}\n\n";
            }

            text += "\nУчастники: \n";
            foreach (Person item in People)

            {
                text += $"{item.ToShortString()}\n";
            }

            return text;
        }

        public virtual string ToShortString() // виртуальный метод ToShortString()
        {
            return $"Тема исследований {Theme}.\nОрганизация {Organization}.\nРегистрационный номер {Number}.\nПродолжительность исследований {Time}.\n";
        }

        public IEnumerable GetPublications(int n)
        {
            foreach (Paper item in Publications)
            {
                if (DateTime.Today.Year - item.Date.Year <= n)
                {
                    yield return item;
                }
            }
        }

        public IEnumerable GetLatestPublications()
        {
            foreach (Paper item in Publications)
            {
                if (DateTime.Today.Year - item.Date.Year <= 1)
                {
                    yield return item;
                }
            }
        }

        public IEnumerable GetPeopleWithoutPublications()
        {
            ArrayList new_arr = new ArrayList();
            foreach (Paper item in Publications)
            {
                new_arr.Add(item.Person);
            }
            foreach (Person item in People)
            {
                if (!new_arr.Contains(item))
                {
                    yield return item;
                }
            }
        }

        public IEnumerable GetPeopleWithPublications()
        {
            ArrayList new_arr = new ArrayList();
            foreach (Paper item in Publications)
            {
                new_arr.Add(item.Person);
            }
            foreach (Person item in People)
            {
                if (new_arr.Contains(item))
                {
                    yield return item;
                }
            }
        }

        public IEnumerable GetPeopleWithManyPublications()
        {
            ArrayList new_arr = new ArrayList();
            foreach (Paper item in Publications)
            {
                new_arr.Add(item.Person);
            }
            foreach (Person item in People)
            {
                int count = 0;
                foreach (Person person in new_arr)
                {
                    if (person == item)
                    {
                        count += 1;
                    }
                }
                if (count > 1)
                    yield return item;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new ResearchTeamEnumerator(People);
        }

        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return string.Compare(x.Theme, y.Theme);
        }

        public void SortByDate()
        {
            publications.Sort((a, b) => a.CompareTo(b));
        }

        public void SortByName()
        {
            publications.Sort((a, b) => a.Compare(a, b));
        }

        public void SortByAuthor()
        {
            publications.Sort(new PaperComparer());
        }
    }
}
