using System;
using System.Collections.Generic;
using System.Text;

namespace first_lab
{
    class Person : INameAndCopy
    {
        string name;
        string surname;
        DateTime date;

        public Person(string name_value, string surname_value, DateTime date_value) /// конструктор с параметрами
        {
            name = name_value;
            surname = surname_value;
            date = date_value;
        } 

        public Person() : this("Иван", "Иванов", new DateTime(1, 1, 1)) /// конструктор по умолчанию
        {
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        } // свойство имя

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        } // свойство фамилия

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        } // свойство дата рождения

        public int Year
        {
            get
            {
                return Date.Year;
            }

            set
            {
                Date = new DateTime(value, Date.Month, Date.Day);
            }
        } // свойство для получения года рождения

        public override string ToString() /// перегруженный оператор ToString()
        {
            return $"{name} {surname} Дата рождения: {date.ToShortDateString()}";
        } // перегруженный метод ToString()

        public virtual string ToShortString() /// виртуальный метод ToShortString()
        {
            return $"{name} {surname}";
        } // виртуальный метод ToShortString()


        public override int GetHashCode() // перегруженный метод int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, Date);
        }

        public override bool Equals(object obj) // метод bool Equals (object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Person p = (Person)obj;
                return (Name == p.Name) && (Surname == p.Surname) && (Date == p.Date);
            }
        }

        public static bool operator ==(Person p1, Person p2) // операция сравнения на равенство
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2) // операция сравнения на неравенство
        {
            return !p1.Equals(p2);
        }

        public virtual object DeepCopy()
        {
            return new Person(this.Name, this.Surname, new DateTime(this.Date.Year, this.Date.Month, this.Date.Day));
        }
        
    }

}

