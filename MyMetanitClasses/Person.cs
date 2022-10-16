//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyMetanitClasses
//{
//    internal class Person
//    {
//    }
//}

class Person
{
    //константы класса - задаются для ВСЕГО КЛАССА, а не для его объектов
    //обращаться к константам ВНЕ класса надо через имя класса Person.type
    public const string type = "Person";

    //поля класса или переменные класса - то что будет иметь
    //конкретные значения в КОНКРЕТНЫХ ОБЪЕКТАХ класса
    public int id;
    public string name = "Undifinied";
    public int age;

    //конструктор класса Person
    public Person()
    {
        Console.WriteLine("Это внутри конструктора Person без параметров");
        name = "Ваня";
        age = 42;
    }

    //второй констрктор с параметрами и this
    // если имена переменных в классе и передаваемые в конструктор - одинаковы
    // то this указывает на переменные в классе (а не в передаваемых() параметрах)
    public Person(string name, int age)
    {
        Console.WriteLine("Конструктор с двумя параметрами name/age");
        this.name = name;
        this.age = age;
    }

    // деконструктор
   public void Deconstruct(out string perName, out int perAge)
    {
        perName = name;
        perAge = age;  
    }


    //метод без параметров
    public void Print()
    {
        Console.WriteLine($"Персона #{id}, имя: {name}, возраст: {age}");
    }

    //метод с передаваемыми параметрами
    public void PrintPerson()
    {
        Console.WriteLine($"Персона #{id}, имя: {name}, возраст: {age}");
    }

}

