//this is my custom class library
namespace Lib01
{
    public class Company
    {
        string name;
        string address;
        int inn;

        public Company(string name, string address, int inn)
        {
            this.name = name;
            this.address = address;
            this.inn = inn;
        }

        public void PrintAbout()
        {
            Console.WriteLine("================");
            Console.WriteLine($"It's about Company {name}, address {address}, INN: {inn}");
            Console.WriteLine("================");
            Console.WriteLine();
        }
    }
}