using System;

namespace HW6
{
    [AttributeUsage (AttributeTargets.Struct | AttributeTargets.Class)]
    public class TrackingEntityAttribute : Attribute
    {
        public TrackingEntityAttribute()
        {
        }
    }
}
