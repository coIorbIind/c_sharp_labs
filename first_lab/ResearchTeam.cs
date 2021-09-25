using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace first_lab
{
    enum TimeFrame { Year, TwoYears, Long };

    class ResearchTeam : Team, INameAndCopy, IEnumerable
    {
        string theme;
        TimeFrame time;
        ArrayList people;
        ArrayList publications;

        public ResearchTeam(string theme_value, string organization_value, int number_value, TimeFrame time_value):base(organization_value, number_value) /// конструктор с параметрами
        {
            theme = theme_value;
            time = time_value;
            publications = new ArrayList();
            people = new ArrayList();
        } // конструктор с параметрами

        public ResearchTeam() : this("Раскопки", "МИЭТ", 111, TimeFrame.Long) /// конструктор без параметров
        {
        } // конструктор по умолчанию

        public override object DeepCopy()
        {
            ResearchTeam other = new ResearchTeam(Theme, Organization, Number, Time);
            foreach (Paper item in this.Publications)
            {
                other.Publications.Add(item.DeepCopy());
            }
            foreach (Person item in this.People)
            {
                other.People.Add(item.DeepCopy());
            }
            return other;
        } // копия объекта класса ResearchTeam

        public string Theme
        {
            get
            {
                return theme;
            }

            set
            {
                theme = value;
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
            }
        } //свойство дата начала исследований

        public ArrayList Publications
        {
            get
            {
                return publications;
            }

            set
            {
                publications = new ArrayList(value);
            }
        } // свойство публикации

        public ArrayList People
        {
            get
            {
                return people;
            }

            set
            {
                people = new ArrayList(value);
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

        public Paper latest //получение последней публикации
        {
            get
            {
                if (Publications.Count > 0)
                {
                    Paper latest = new Paper();
                    latest.Date = new DateTime(1, 1, 1);
                    foreach (Paper item in Publications)
                    {
                        if (item.Date > latest.Date)
                        {
                            latest = item;
                        }
                    }
                    return latest;
                }

                return null;
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

    }
}
