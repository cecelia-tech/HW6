using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public void Tracker<T>(T obj)
        {
            var type = typeof(T);
            List<string> trackingPropertyElements = new List<string>();
            List<MemberInfo> memberInfo = new List<MemberInfo>();
            memberInfo.AddRange(type.GetProperties());
            memberInfo.AddRange(type.GetFields());
            
            var p = type.GetCustomAttribute<TrackingEntityAttribute>();

            //var members = type.GetMembers().Where(x => x == typeof(TrackingPropertyAttribute));

            if (p is not null)
            {
                var filteredInfo = memberInfo.Where(x => x.GetCustomAttribute<TrackingPropertyAttribute>() == null)
                    .Select(x => x)
                    .ToList();

                    filteredInfo.ForEach(x => trackingPropertyElements.Add($"{x.GetCustomAttribute<TrackingPropertyAttribute>().PropertyName ?? x.Name}: {((FieldInfo)x).GetValue(obj) ?? ((PropertyInfo)x).GetValue(obj)}"));

                //var classProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                //var classFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

                //if (classProperties.Length != 0)
                //{
                //    foreach (var item in classProperties)
                //    {
                //        var a = item.GetCustomAttribute<TrackingPropertyAttribute>();
                //        //turim tikrint del null
                //        trackingPropertyElements.Add($"{a.PropertyName ?? item.Name}: {item.GetValue(obj)}");
                //    }
                //}

                //if (classFields.Length != 0)
                //{
                //    foreach (var item in classFields)
                //    {
                //        var a = item.GetCustomAttribute<TrackingPropertyAttribute>();
                //        trackingPropertyElements.Add($"{a.PropertyName ?? item.Name}: {item.GetValue(obj)}");
                //    }
                //}

                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

                using (FileStream stream = new FileStream(jsonFileName, FileMode.OpenOrCreate))
                {
                    serializer.Serialize(stream, trackingPropertyElements);
                }
            }
        }
    }
}
