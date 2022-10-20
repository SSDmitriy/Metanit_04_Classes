namespace SomeNamespace
{
    public class PersonInSomeNamespace
    {
        string name;
        public PersonInSomeNamespace(string name)
        {
            this.name = name;
        }

        //print name from object
        public void PrintMyName()
        {
            Console.WriteLine("My name is: " + name);
        }

    }

    namespace InnerNamespace
    {

        public class ClassInInnerNamespace
        {
            public void PrintFromInnerNamespace()
            {
                Console.WriteLine("Print with method from inner namespace");
            }
        }
    }

}



