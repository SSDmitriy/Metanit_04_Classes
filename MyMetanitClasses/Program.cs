
/*
class Program
{
    static void Main(string[] args)
    {

        // Классы https://metanit.com/sharp/tutorial/3.1.php
        //в С# 6.0 применено "улучшение" - не надо явно писать метод public static void Main(){}
        // из-за этого объявления классов должны идти ниже по коду, чем их использование и вызов в коде
        // вообще ВНУТРИ МЕТОДОВ НЕЛЬЗЯ объявлять классы
        // т.е. внутри метода Main() тоже нельзя объявлять классы,
        // поэтому если Main() явно не указан, то все определения классов (типов)
        // должны после кода инструкции (вызовов этих классов)
        Person tom;
        tom = new Person();

        Console.WriteLine("Напечатать Тома");
        tom.PrintPerson();

        tom.age = 99;
        tom.name = "ИзмИмя";

        Console.WriteLine("Ещё раз напечатать Тома");
        tom.Print();

        Console.WriteLine("Напечатать константу класса PERSON");
        Console.WriteLine(Person.type);


        Person bob = new Person("bob", 23);

        Console.WriteLine("Напечатать Боба");
        bob.PrintPerson();

        //инициализаторы объектов при их создании через new
        Person jack = new("Jack", 66);
        Console.WriteLine("Напечатать Джека");
        jack.PrintPerson();

    }
}
*/

// Передача по значению и по ссылке https://metanit.com/sharp/tutorial/2.16.php
// простые типы int, double, byte... - хранят непосредственно ЗНАЧЕНИЕ
// объекты построенные на основе классов сохраняются в памяти,
// но доступ к ним происходит ПО ССЫЛКЕ.
// Person p = new Person() - здесь в p хранится ссылка на объект, а не значение
// Значения хранятся в стеке (более быстро), ссылки - в heap (верней ссылка на объект может храниться
// в стеке, но сами данные уже в куче.
/*
Person p = new Person { name = "Tom",  age = 33 };

Console.WriteLine($"Персона до изменения: {p.name}, возраст {p.age}");

// вызов метода и передача копии ссылки на объект
// т.е. внутри метода будут манипуляции с копией сслыки
// а сам объект таким образом нельзя изменить, т.к. оригинальная
// ссылка НЕ ПЕРЕДАЕТСЯ в метод
Console.WriteLine();
Console.WriteLine("Вызов метода ChangePerson");
ChangePerson(p);

Console.WriteLine();
Console.WriteLine($"Персона ПОСЛЕ изменения: {p.name}, возраст {p.age}");


Console.WriteLine();
Console.WriteLine("Новая персона Bob/77");
p = new Person { name = "Bob", age = 77 };
Console.WriteLine($"Персона ДО изменения: {p.name}, возраст {p.age}");

// вызов по ссылке ref (т.е.в метод передается не копия ссылки, а САМА ССЫЛКА
// и метод будет воздействовать уже на сам объект
Console.WriteLine();
Console.WriteLine("Вызов метода ПО ССЫЛКЕ ref метода ChangePerson");
ChangePersonByRef(ref p);
Console.WriteLine($"Персона после изм ПО ССЫЛКЕ: {p.name}, возраст {p.age}");


// Метод "изменить персону" (просто, по копии ссылки)
void ChangePerson(Person p)
{
    p.name = "Alice";       // переименовали

    p = new Person { name = "Bill", age = 45 };     //второй раз не получится переименовать
    Console.WriteLine("Это внутри метода ChangePerson (попытка изменить имя и возраст)");
}

// Метод "изменить персону по ссылке" (модификатор ref перед типом, укзаывает
// что в метод передается САМА ССЫЛКА, а не её копия
void ChangePersonByRef(ref Person p)
{
    p.name = "Alice";       // переименовали

    p = new Person { name = "Bill", age = 45 };     // и еще раз переименовали
    Console.WriteLine("Это внутри метода ChangePerson (попытка изменить имя и возраст)");
}

*/



/*
// ПРОСТРАНСТВА ИМЕН https://metanit.com/sharp/tutorial/3.25.php
// пространство имен определяется как - namespase Name{}
// можно внутри файла несколько пространств задать или вынести пространство в отдельный

// подключаю пространство из другого файла
using SomeNamespace;
using System.Net.NetworkInformation;

// создаю объект класса из простр имен и потом можно обратиться к его методу
PersonInSomeNamespace bob = new PersonInSomeNamespace("bobb");
bob.PrintMyName();

// подкл пространство внутри пространства - нужно обратиться
// по полному имени класса, включая пространства имен
SomeNamespace.InnerNamespace.ClassInInnerNamespace inInside = new SomeNamespace.InnerNamespace.ClassInInnerNamespace();
inInside.PrintFromInnerNamespace();




// подключать или отключать пространства имен можно в в файле проекта
// по дефолту в .net6 подключено глобальное пространство имен
// < ImplicitUsings > enable </ ImplicitUsings >
// пример выключенного пространства имен и подключения/отключения отдельных пространств
// в файле проекта .sln

< Project Sdk = "Microsoft.NET.Sdk" >

  < PropertyGroup >
    < OutputType > Exe </ OutputType >
    < TargetFramework > net6.0 </ TargetFramework >
    < ImplicitUsings > disable </ ImplicitUsings > // вот здесь отключены дефолтные namespace
    < Nullable > enable </ Nullable >
  </ PropertyGroup >


  < ItemGroup >
    < Using Include = "System" /> // include подключает глобально КОНКРЕТНОЕ namespace
    < Using Include = "System.Threading.Tasks" />
    < Using Remove = "System.Linq" /> // remove ОТКЛЮЧАЕТ конкретный namespace
  </ ItemGroup >


</ Project >

*/


/* библиотека классов, подключение https://metanit.com/sharp/tutorial/3.46.php
// помещу класс Company в библиотеку классов Lib01
using Lib01;

Company acme = new Company("acme", "TazzMania, Elm st. 13", 666777666);

acme.ToString();
acme.PrintAbout();


*/

/*
// Свойства https://metanit.com/sharp/tutorial/3.4.php
// свойства - это по сути геттеры и сеттеры (аксессоры)
// свойства предоставляют доступ к полям класса (можно установить
// или извлечь значение переменной в классе), при этом ДОБАВИТЬ НЕКУЮ ЛОГИКУ
// в операцию установки или извлечения 

ClassWithGetSet obj01 = new ClassWithGetSet();
Console.WriteLine("поле класса ДО установления вручную (дефолтное значение):< "
    + obj01.Field + " >");
obj01.Field = "I set this field with setter";

Console.WriteLine("поле класса ПОСЛЕ установки через сеттер:< " + obj01.Field + " >"); //напечатать значение поля класса через геттер .Field


Console.WriteLine("age ДО установления (дефолтное значение):< "
    + obj01.Age + " >");
obj01.Age = 7914;

Console.WriteLine("поле age ПОСЛЕ установки через сеттер:< " + obj01.Age + " >");

public class ClassWithGetSet
{
    private string field; // это приватное поле

    public string Field // а это СВОЙСТВО класса (начинается с заглавной буквы)
    {
        //геттер - возвращает значение ПРИВАТНОГО поля
        get { return field; }

        //сеттер - устанавливает значение ПРИВАТНОГО поля
        set { field = value; }
    }


    //другой геттер-сеттер для другого поля Age
    //зададим в сеттере проверку, чтобы возраст был не менее 18 и не более 65 лет
    private int age;

    public int Age
    {
        get
        {
            return age;
        }

        // в сеттер введена проверка на 18<age<65
        set
        {
            if (value < 18) age = 18;
            else if (value > 65) age = 65;
            else age = value;
        }
    }


}

*/

/*
// если в классе прописано только одно свойство GET or SET
// тогда с полем класса можно сделать только одну операцию
// установить или прочитать


//класс Person со свойствами
// name - только чтение (GET)
// age - только запись (SET)
Person person = new Person();

//person.Name = "Bob"; //так не получится, т.к. для Person нет свойства SET
Console.WriteLine($"Имя Person через вызов свойства GET: {person.Name}");

//установить age
//person.age = 39; //не получится, т.к. поле age - приватное
//надо через свойство SET
person.Age = 39;

person.Print();

class Person
{
    string name = "MrDefault";
    int age = 1;

    public string Name //только GET
    {
        get
        {
            return name;
        }
    }


    public int Age // только SET
    {
        set
        {
            age = value;
        }
    }

    public void Print()
    {
        Console.WriteLine($"Name is: {name}, age is: {age}");
    }
}

*/


///*
//Перегрузка методов https://metanit.com/sharp/tutorial/3.5.php

//Сигнатура - это ИМЯ метода + колчичество параметров + типы параметров
//                              + порядок параметров + модификаторы параметров
//например тут сигнатура Sum(int, int)
//public int Sum(int a, int b)
//{
//    return a + b;
//}

Calculator calculator = new Calculator();

Console.WriteLine("Вызов перегруженных методов: ");
Console.WriteLine("5 + 3: " + calculator.Sum(5, 3));
Console.WriteLine("5 + 3 + 2: " + calculator.Sum(5, 3, 2));
Console.WriteLine("5 + 3 + 2 + 1: " + calculator.Sum(5, 3, 2, 1));
Console.WriteLine();


Overload overl = new Overload();
int overloadedVar = 5;
Console.WriteLine("Перегрузка по модификатору ref и без него");
Console.WriteLine("Модификатор ref: ");overl.Increment(ref overloadedVar);
Console.WriteLine("Без модификатора: "); overl.Increment(5);

class Calculator
{
    public int Sum(int a, int b)
    {
        return a + b;
    }

    public int Sum(int a, int b, int c)
    {
        return a + b + c;
    }

    public int Sum(int x, int y, int z, int a)
    {
        return x + y + z + a;
    }
}



class Overload
{
    //перегрузка по используемым модификаторам
    public void Increment(ref int a)
    {
        a++;
        Console.WriteLine(a);
    }

    public void Increment(int a)
    {
        a++;
        Console.WriteLine(a);
    }

}








//*/
