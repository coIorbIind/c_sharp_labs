using System;
using System.Collections.Generic;
using System.Text;

namespace first_lab
{
    class TeamsJournal<TKey>
    {
        List<TeamsJournalEntry> changes_data = new List<TeamsJournalEntry>();

        public void ResearchTeamsChangedHandler(object sendler, ResearchTeamsChangedEventArgs<TKey> args) 
        {
            changes_data.Add(new TeamsJournalEntry(args.Name_of_collection, args.Info, args.Property_from, args.Organization_number));
        }

        public override string ToString() //перегруженный метод ToString()
        {
            string text = "Полученные изменения:\n";
            foreach (TeamsJournalEntry item in changes_data)
            {
                text += item.ToString();
            }
            return text;
        }
    }
}
