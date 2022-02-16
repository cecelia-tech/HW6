using System;
namespace HW6
{
    [Serializable]
    [TrackingEntity]
    public class Person
    {
        [TrackingProperty]
        public string Name { get; set; }
        [TrackingProperty]
        public string LastNmae { get; set; }
        public int Age { get; set; }

        public Person()
        {
        }

        public Person(string name, string lastNmae, int age)
        {
            Name = name;
            LastNmae = lastNmae;
            Age = age;
        }
    }
}
