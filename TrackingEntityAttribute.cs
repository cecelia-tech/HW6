using System;

namespace HW6
{
    [AttributeUsage (AttributeTargets.Struct | AttributeTargets.Class, Inherited = false)]
    public class TrackingEntityAttribute : Attribute
    {
        public TrackingEntityAttribute()
        {
        }
    }
}
