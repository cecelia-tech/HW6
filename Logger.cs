using System;
using System.Reflection;

namespace HW6
{
    public class Logger<T>
    {
        public string JsonFileName { get; set; }

        public Logger(string jsonFileName)
        {
            if (jsonFileName is null)
            {
                throw new ArgumentNullException();
            }
            JsonFileName = jsonFileName;
        }

        
        public void Tracker(object obj)
        {
            var type = typeof(T);

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
