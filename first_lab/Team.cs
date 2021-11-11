using System;
using System.Collections.Generic;
using System.Text;

namespace first_lab
{
    [Serializable]
    class Team : INameAndCopy, IComparable
    {
        protected string organization;
        protected int number;

        public Team(string organization_value, int number_value) /// конструктор с параметрами
        {
            organization = organization_value;
            number = number_value;
        } // конструктор с параметрами

        public Team() : this("МИЭТ", 111)
        {
        } // конструктор без параметров
        public string Organization
        {
            get
            {
                return organization;
            }

            set
            {
                organization = value;
            }
        } //свойство организация

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Номер должен быть положительным числом");
                }
                else
                    number = value;

            }
        } //свойство номер организации

        string INameAndCopy.Name
        {
            get
            {
                return Organization;
            }

            set
            {
                Organization = value;
            }
        }

        public virtual object DeepCopy()
        {
            return new Team(Organization, Number);
        } // копия объекта класса Team

        public override bool Equals(object obj) // метод bool Equals (object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Team t = (Team)obj;
                return (this.Organization == t.Organization) && (this.Number == t.Number);
            }
        }

        public static bool operator ==(Team t1, Team t2) // операция сравнения на равенство
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(Team t1, Team t2) // операция сравнения на неравенство
        {
            return !(t1.Equals(t2));
        }

        public override int GetHashCode() // перегруженный метод int GetHashCode()
        {
            return HashCode.Combine(Organization, Number);
        }

        public override string ToString()
        {
            return $"Название организации: {Organization}. Номер организации: {Number}";
        } // перегруженный метод string ToString()

        public int CompareTo(object obj)
        {
            return Number - ((Team)obj).Number;
        }
    }
}
