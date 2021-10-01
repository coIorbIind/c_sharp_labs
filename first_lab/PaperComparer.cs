using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace first_lab
{
    class PaperComparer : IComparer<Paper>
    {
        public int Compare(Paper x, Paper y)
        {
            return String.Compare(x.Person.Surname, y.Person.Surname);
        }
    }
}
