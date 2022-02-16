using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace HW6
{
    public class Logger
    {
        private string jsonFileName;
        
        public Logger(string jsonFileName)
        {
            if (jsonFileName is null)
            {
                throw new ArgumentNullException();
            }
            this.jsonFileName = jsonFileName;
        }

        

        public void Tracker(object obj)
        {
            var type = typeof(Person);
             
            Assembly asemb = type.Assembly;
            string asembName = asemb.GetName().Name;

            if (Attribute.IsDefined(asemb,
                typeof(TrackingEntityAttribute)))
            {

            }
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        public void WriteInfo(Person person)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(int));

            using (FileStream stream = new FileStream("test.xml", FileMode.OpenOrCreate))
            {
                int age = person.Age;

                serializer.Serialize(stream, age);
            }
        }
    }
}
