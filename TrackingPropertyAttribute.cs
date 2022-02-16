using System;
namespace HW6
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class TrackingPropertyAttribute : Attribute
    {
        //optional property name, which we can define when write the atribute in the class
        public string PropertyName { get; set; }

        public TrackingPropertyAttribute()
        {

        }
        //public TrackingPropertyAttribute(string propertyName)
        //{
        //    PropertyName = propertyName;
        //}
    }
}
