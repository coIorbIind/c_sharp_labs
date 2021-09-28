using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace first_lab
{
    class ResearchTeamEnumerator : IEnumerator
    {
        List<Person> members;
        int position = -1;

        public ResearchTeamEnumerator(List<Person> members_value)
        {
            this.members = members_value;
        }
        public ResearchTeamEnumerator()
        {
            this.members = new List<Person>();
        }

        public object Current
        {
            get
            {
                if (position == -1 || position >= members.Count)
                    throw new IndexOutOfRangeException();
                return members[position];
            }
        }

        public bool MoveNext()
        {
            if (position < members.Count - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
