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

        
        //this one for attributes
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

        //probably we won't need this method, it will be in a Tracker 
        public void WriteInfo(Person person)
        {
            //instead of typeof(int), we'll probably use T
            XmlSerializer serializer = new XmlSerializer(typeof(int));

            using (FileStream stream = new FileStream("test.xml", FileMode.OpenOrCreate))
            {
                //instead of this we'll have some kind of list with property and method info
                int age = person.Age;

                serializer.Serialize(stream, age);
            }

            //we also would need using for desializeration!!!!!!! same issue
        }
    }
}
