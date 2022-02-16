using System;
namespace HW6
{
    [TrackingEntity]
    public class Person
    {
        [TrackingProperty]
        public string Name { get; set; }
        public string LastNmae { get; set; }
        public int Age { get; set; }

        public Person()
        {
        }
    }
}
