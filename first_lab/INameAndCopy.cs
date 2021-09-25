using System;
using System.Collections.Generic;
using System.Text;

namespace first_lab
{
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}

