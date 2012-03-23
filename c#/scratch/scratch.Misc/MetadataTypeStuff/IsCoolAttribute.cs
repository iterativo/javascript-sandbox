using System;

namespace scratch.Misc.MetadataTypeStuff
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IsCoolAttribute : Attribute
    {
    }
}