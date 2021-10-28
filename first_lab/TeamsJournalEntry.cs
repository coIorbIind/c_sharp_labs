using System;
using System.Collections.Generic;
using System.Text;

namespace first_lab
{
    class TeamsJournalEntry
    {
        public string Name_of_collection { get; set; }
        public Revision Info { get; set; }
        public string Property_from { get; set; }
        public int Organization_number { get; set; }

        public TeamsJournalEntry(string name_value, Revision info_value, string property_value, int number_value)
        {
            Name_of_collection = name_value;
            Info = info_value;
            Property_from = property_value;
            Organization_number = number_value;
        }

        public override string ToString() //перегруженный метод ToString()
        {
            return $"Название коллекции {Name_of_collection}.\nСвойство {Property_from} было {Info} у организации {Organization_number}\n";
        }
    }
}
