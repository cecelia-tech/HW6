using System;
namespace HW6
{
    [Serializable]
    [TrackingEntity]
    public class Person
    {
        [TrackingProperty]
        public string Name { get; set; }
        [TrackingProperty(PropertyName = "Last name")]
        public string LastNmae { get; set; }
        [TrackingProperty]
        public int age;

        public Person()
        {
        }

        public Person(string name, string lastNmae, int age)
        {
            Name = name;
            LastNmae = lastNmae;
            this.age = age;
        }

        
    }
}
