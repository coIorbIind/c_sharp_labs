using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace first_lab
{
    delegate TKey KeySelector<TKey>(ResearchTeam rt);
    class ResearchTeamCollection<TKey>
    {


        //private static readonly Dictionary<Type, ResearchTeamCollection<Type>>

        KeySelector<TKey> my_key;
        Dictionary<TKey, ResearchTeam> MyTeams;

        public ResearchTeamCollection(KeySelector<TKey> key_value)
        {
            this.my_key = key_value;
            MyTeams = new Dictionary<TKey, ResearchTeam >();
        }

        public static string GenerateKey(ResearchTeam rs)
        {
            return rs.Organization;
        }


        public void AddDefaults(params ResearchTeam[] teams)
        {
            foreach (ResearchTeam item in teams)
            {
                TKey key = my_key(item);
                if (!MyTeams.ContainsKey(key))
                    MyTeams.Add(key, item);
                else
                    Console.WriteLine("Элемент с таким ключом уже существует");
            }
        }

        public void AddResearchTeams(params ResearchTeam[] teams)
        {
            foreach (ResearchTeam item in teams)
            {
                TKey key = my_key(item);
                if (!MyTeams.ContainsKey(key))
                    MyTeams.Add(key, item);
                else
                    Console.WriteLine("Элемент с таким ключом уже существует");
            }
        }

        public override string ToString()
        {
            String text = "Исследовательские команды:\n\n";
            foreach (ResearchTeam item in MyTeams.Values)
            {
                text += (item.ToString() + "\n\n");
                text += "-------------------------------------------------------------\n";
            }

            return text;
        }

        public virtual string ToShortString()
        {
            String text = "Исследовательские команды:\n";
            foreach (ResearchTeam item in MyTeams.Values)
            {
                text += (item.ToShortString() + "\n\n");
            }

            return text;
        }

        public DateTime latest
        {
            get
            {
                if (MyTeams.Count > 0)
                {
                    return MyTeams.Max(x => x.Value.latest);
                }
                return new DateTime();
            }
        }

        public IEnumerable<KeyValuePair<TKey, ResearchTeam>> TimeFrameGroup(TimeFrame time)
        {
            return MyTeams.Where(x => x.Value.Time == time);
        }

        ////public void SortByTeam()
        ////{
        ////    MyTeams.Sort((a, b) => a.CompareTo(b));
        ////}

        ////public void SortByTheme()
        ////{
        ////    MyTeams.Sort(new ResearchTeam());
        ////}

        ////public void SortByPublications()
        ////{
        ////    MyTeams.Sort(new PaperComparer());
        ////}


        //public IEnumerable<ResearchTeam> researchTeams
        //{
        //    get
        //    {
        //        return MyTeams.Where(x => x.Time == TimeFrame.TwoYears);
        //    }
        //}

        //public List<ResearchTeam> CountPeople(int value)
        //{
        //    var team = (from t in MyTeams
        //                      where t.People.Count == value
        //                      select t).ToList();
        //    return team;
        //}

        public IEnumerable<IGrouping<TimeFrame, KeyValuePair<TKey, ResearchTeam>>> NGroup()
        {
            return MyTeams.GroupBy(x => x.Value.Time);
        }


    }
}
