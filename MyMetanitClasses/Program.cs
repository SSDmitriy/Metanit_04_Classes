
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
        // должны быть после кода инструкции (вызовов этих классов)
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


/*
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


*/


/*
// Статические методы, модификатор static https://metanit.com/sharp/tutorial/3.6.php
// Статическими могут быть: КЛАСС, внутри класса - ПОЛЯ, СВОЙСТВА, МЕТОДЫ и КОНСТРУКТОР
Person bob = new(19);
bob.Name = "Bob";
Console.Write($"Персона №: {Person.counter}, Имя: {bob.Name}, возраст {bob.age} - "); ;
bob.CheckAge();

Person tom = new(26);
tom.Name = "Tom";
Console.Write($"Персона №: {Person.counter}, Имя: {tom.Name}, возраст {tom.age} - "); ;
tom.CheckAge();

//напечатать статическое свойство - надо обратиться напрямую по имени класса
// AdultAge - сввойство (с большой буквы), adultAge - статическая переменная
Console.WriteLine("(Статическое свойство) Возраст совершеннолетия: " + Person.AdultAge);



class Person
{
    
    static int adultAge = 21; //статическая переменная - возраст совершеннолетия - один для всех
    public static int counter = 0; //статическая переменная - счетчик созданных персон

    public int age;
    string name;

    public string Name { get; set; }

    public static int AdultAge
    {
        get { return adultAge; }
    }

    public Person(int age)
    {
        this.age = age;
        this.name = name;
        counter++;
    }

    public void CheckAge()
    {
        if (age >= adultAge) Console.WriteLine("взрослый");
        else if (age >= 0) Console.WriteLine("ребенок");
        else Console.WriteLine("некорректный возраст");
    }
}
 

*/


/*
//NuGet пакеты https://metanit.com/sharp/tutorial/3.60.php
//
// we are downloaded NuGet package Newtonsoft.Json
// now we should turn on this package with "using"
using Newtonsoft.Json;


Console.WriteLine("Hello, this word");

Person dan = new("Dan", 33);

//serialasing objext "dan"
string danInJson = JsonConvert.SerializeObject(dan);

//now print serialased result
Console.WriteLine(danInJson);
Console.WriteLine("End of hwapp");


class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

}

*/


/*/
// Constants https://metanit.com/sharp/tutorial/3.3.php
// CONSTANTS must initialising at moment definition (i.e. BEFORE compilation)
// READONLY fields can initialise with declaration OR inside constructor

Person dan = new Person(7, "Daniel");

Console.WriteLine("Print constant: " + Person.Type); //call the constant with class name
Console.WriteLine("Print readonly var (id): " + dan.id);


class Person
{
    public const string Type = "Human"; // this is a CONSTANT
    public readonly int id;
    public string Name { get; set; }

    public Person(int id, string name)
    {
        this.id = id; 
        this.Name = name;
    }

}

*/

/*
// https://metanit.com/sharp/tutorial/3.50.php
// NULLABLE ? ?? ?. !
//
// "?" after type means variable can take NULL
// this ? for static analyse before compilation

#nullable enable
using Lib01;
///*
string? someStr2 = null;


#nullable disable // disable for few strings below
PrintUpper(someStr2);

#nullable restore //return nullable context in this file

string? someStr = null;


PrintUpper(someStr2!); // ! - means "I know, that here is not null, because i checked it manually in method"

void PrintUpper(string s)
{
    if (s == null) Console.WriteLine("null");
    else Console.WriteLine(s.ToUpper());
}

Console.WriteLine("---");

//int num1 = null; - WRONG. int - it's valuable type and can't be a null
int? num1 = null; // "int?" it's like "System.Nullable<int>"
Console.WriteLine(num1);


Console.WriteLine("---");

//PROPERTIES "Value" and "HasValue"
//System.Nullable<T>.Value - return value of object <T>
//System.Nullable<T>.HasValue - return TRUE if object is not null, or return FALSE if object is null

MyPrintNullable(5);
MyPrintNullable(null);

void MyPrintNullable(int? num)
{
    if (num.HasValue)
    {
        Console.WriteLine("Num is: " + num.Value);
           }
    else
    {
        Console.WriteLine("There is no any num, there is only NULL");
    }
}

Console.WriteLine("---");
Console.WriteLine("GetValueOrDefault");

//int? num2 = null; // nullable variable
//Console.WriteLine(num2.Value); //ERROR we can't get property "Value" from "null"

//property GetValueOrDefault(x) - return value or "x" if value is null
int? num3 = null;
Console.WriteLine(num3.GetValueOrDefault()); //return "0" - as default for numbers
Console.WriteLine(num3.GetValueOrDefault(42)); // return 42, because num3=null, then return default=42

int? num4 = 23; //not null here
Console.WriteLine(num4.GetValueOrDefault()); //return "23"
Console.WriteLine(num4.GetValueOrDefault(42)); // also return "23"


Console.WriteLine("---");
Console.WriteLine("Null-guard checks");

//null guard checks
// operators "is", "is not"
string someString5 = "abc";

JustPrint(someString5);

void JustPrint(string? s)
{
    if(s is not null) Console.WriteLine("Sting is not null: " + s);
}


Console.WriteLine("---");
Console.WriteLine("Null-Union \"??\"");

// ?? - "null union"
// a ?? b - return "a" if a<>null
// a ?? b - return "b" if a==null
string? someString6 = null;
string otherStr = someString6 ?? "someString6 has no value...";
someString6 ??= "it was null"; // "??=" is someSrting6 = someString6 ?? "yourText". Like operators += or *=

Console.WriteLine(otherStr);

int? num6 = 100;
int val6 = num6 ?? 1; //val6 = 100, because is not null
Console.WriteLine(val6);



Console.WriteLine("---");
Console.WriteLine("Check \"if-null\" with \"?.\"");
// ?.
//Company comp = new Company("222-33-22");
Person2 person2 = new Person2(null);
Person2 persWithPhone = new Person2(new Company("222-33-22"));

Console.WriteLine("Check for person2");
PrintPhone(person2);
Console.WriteLine("End check for person2");
Console.WriteLine("...");
Console.WriteLine("Check for persWithPhone");
PrintPhone(persWithPhone);
Console.WriteLine("End check for persWithPhone");

void PrintPhone(Person2? pers)
{
    if (pers is not null)
    {
        if (pers.Company is not null)
        {
            if (pers.Company.Phone is not null)
            {
                Console.WriteLine(pers.Company.Phone);
            }
        }
    }

    // same check but SHORTER with ?.
    // "?." means - if property "is not null, then call next level after dot"
    Console.WriteLine(pers?.Company?.Phone);

}


class Person2
{
    public Company? Company { get; set; } // job-company - may be null
    public Person2(Company? company)
    {
        Company = company;
    }
}

class Company
{
    public string? Phone{ get; set; } // phone of company - may be null
    public Company(string? phone)
    {
        Phone = phone;
    }
}



// !


*/

///*
// Псевдонимы https://metanit.com/sharp/tutorial/4.1.php
// we can use alias for classes (types) and structures with USING and =

//STATIC IMPORT
using static System.Console;
//STATIC IMPORT for custom type (class)
using static myOpps;

//ALIAS
using myOwnPrinter = System.Console;
//using myPrinter = System.Console.WriteLine(); - WRONG. WriteLine() - this a method, and can not have alias


myOwnPrinter.WriteLine("Hello app, this is with alias"); //here "myOwnPrinter" - alias

WriteLine("Hello, I'm using static import"); // here we use "WriteLine()" without full name

WriteLine("Sum 5+3 with static import: " + Sum(5, 3));



//my own static class (type)
static class myOpps
{
    public static int Sum(int a, int b)
    {
        return a + b;
    }

    public static int Substract(int a, int b)
    {
        return a - b;
    }

    public static double Divide(double a, double b)
    {
        return a / b;
    }
}


//*/

