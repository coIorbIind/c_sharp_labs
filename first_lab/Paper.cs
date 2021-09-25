using System;
using System.Collections.Generic;
using System.Text;

namespace first_lab
{

    class Paper : INameAndCopy
    {
        public string Name { get; set; } // свойство название
        public Person Person { get; set; } // свойство автор

        public DateTime Date { get; set; } // свойство дата публикации

        public Paper(string name, Person person, DateTime date) /// конструктор с параметрами
        {
            Name = name;
            Person = person;
            Date = date;
        }

        public Paper(): this("Земля", new Person(), new DateTime(1, 1, 1)) /// конструктор по умолчанию
        {
        }

        public override string ToString() 
        {
            return $"Название: {Name} \nАвтор: {Person.ToShortString()}\nДата издания: {Date.ToShortDateString()}";
        } //перегруженный метод ToString()

        public virtual object DeepCopy()
        {
            return new Paper(this.Name, (Person)this.Person.DeepCopy(), new DateTime(this.Date.Year, this.Date.Month, this.Date.Day));
        }
    }
}
