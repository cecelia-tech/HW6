using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace HW6
{
    [Serializable]
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
        public void Tracker<T>(T obj)
        {
            List<string> trackingPropertyElements = new List<string>();
            var type = typeof(T);
            //Assembly asemb = type.Assembly;
            //string asembName = asemb.GetName().Name;
            var p = type.GetCustomAttribute<TrackingEntityAttribute>();

            if (p is not null)
            {
                var classProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var classFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

                if (classProperties.Length != 0)
                {
                    foreach (var item in classProperties)
                    {
                        var a = item.GetCustomAttribute<TrackingPropertyAttribute>();
                        trackingPropertyElements.Add($"{a.PropertyName ?? item.Name}:  {item.GetValue(obj)}");
                        //Console.WriteLine(a.PropertyName ?? item.Name);
                        //Console.WriteLine(item.GetValue(obj));
                    }
                }

                if (classFields.Length != 0)
                {
                    foreach (var item in classFields)
                    {
                        var a = item.GetCustomAttribute<TrackingPropertyAttribute>();
                        trackingPropertyElements.Add($"{a.PropertyName ?? item.Name}:  {item.GetValue(obj)}");
                        //Console.WriteLine(a.PropertyName ?? item.Name);
                        //Console.WriteLine(item.GetValue(obj).ToString());
                    }
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

                using (FileStream stream = new FileStream("test.xml", FileMode.OpenOrCreate))
                {
                    serializer.Serialize(stream, trackingPropertyElements);
                }
                //var attributeType = typeof(TrackingPropertyAttribute);
                //var attribute = (TrackingPropertyAttribute)Attribute.GetCustomAttribute(type, attributeType);
                //var bob = new StringBuilder();
                //var a = type.GetMembers();
                //var trackingPropertyAttributes = type.GetCustomAttribute<TrackingPropertyAttribute>();
                //var x = trackingPropertyAttributes;
                //foreach (var item in trackingPropertyAttributes)
                //{
                //    Console.WriteLine(item);
                //}
                //for (int i = 0; i < a.Length; i++)
                //{
                //    a[i].getpara
                //    var attr = a[i].GetCustomAttribute<TrackingPropertyAttribute>(false);
                //    if (attr is not null)
                //    {

                //        Console.WriteLine(attr.PropertyName ?? a[i].Name);

                //        Console.WriteLine(a.GetValue(obj));
                //    }
                //}
                //foreach (var item in a)
                //{
                //    var attr = item.GetCustomAttribute<TrackingPropertyAttribute>(false);
                //if (attr != null)
                //{
                //foreach (var attr in attrs)
                //{
                //if (attr is not null)
                //{
                //    Console.WriteLine(attr.PropertyName ?? item.Name);

                //    Console.WriteLine(item);
                //}
                //}
                //}

                //bob.Append(attr.PropertyName ?? item.Name).Append(",");
                //bob.Append(item.GetValue());
                //if (item != null)
                //{
                //    var b = item.GetCustomAttribute<TrackingPropertyAttribute>();
                //    var c = b.ToString();
                //    Console.WriteLine(c);
                //}

                //}
                //Console.WriteLine(bob.ToString());
                Console.WriteLine("rado");
            }
            else
            {
                Console.WriteLine("nerado");
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
                int age = person.age;

                serializer.Serialize(stream, age);
            }

            //we also would need using for desializeration!!!!!!! same issue
        }
    }
}
