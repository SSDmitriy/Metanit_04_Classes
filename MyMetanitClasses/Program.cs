
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


///* библиотека классов, подключение https://metanit.com/sharp/tutorial/3.46.php
// помещу класс Company в библиотеку классов Lib01
using Lib01;

Company acme = new Company("acme", "TazzMania, Elm st. 13", 666777666);

acme.ToString();
acme.PrintAbout();


//*//