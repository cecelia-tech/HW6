using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Collections.Generic;
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
            List<string> infoToStore = CollectInfo(obj);

            if (infoToStore.Count() != 0 )
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

                using (FileStream stream = new FileStream(jsonFileName, FileMode.OpenOrCreate))
                {
                    serializer.Serialize(stream, infoToStore);
                }
            }
        }

        public List<string> CollectInfo<T>(T obj)
        {
            var type = typeof(T);
            var memberInfo = type.GetMembers();
            List<string> trackingPropertyElements = new List<string>();

            var p = type.GetCustomAttribute<TrackingEntityAttribute>();

            if (p is not null)
            {
                var filteredMemberInfo = memberInfo
                    .Where(x => x.GetCustomAttribute<TrackingPropertyAttribute>() != null)
                    .Select(x => x)
                    .ToList();

                foreach (var item in filteredMemberInfo)
                {
                    var a = item.GetCustomAttribute<TrackingPropertyAttribute>();

                    trackingPropertyElements.Add($"{a.PropertyName ?? item.Name}: " +
                        $"{(item.MemberType == MemberTypes.Field ? ((FieldInfo)item).GetValue(obj) : ((PropertyInfo)item).GetValue(obj))}");
                }
            }
            return trackingPropertyElements;
        }
    }
}
