using System;
using System.Collections;
using System.Text;

namespace first_lab
{
    class ResearchTeamEnumerator : IEnumerator
    {
        ArrayList members;
        int position = -1;

        public ResearchTeamEnumerator(ArrayList members_value)
        {
            this.members = members_value;
        }
        public ResearchTeamEnumerator()
        {
            this.members = new ArrayList();
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
