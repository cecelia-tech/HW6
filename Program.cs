using System;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger test = new Logger("test.xml");

            Person person = new Person("Simon", "Rogers", 47);

            test.Tracker(person);
        }
    }
}
