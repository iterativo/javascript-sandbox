using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace scratch.Misc.MetadataTypeStuff
{
	public static class ReflectionHelper
	{
		public static IEnumerable<MemberInfo> WithAttribute<T>(this MemberInfo[] memberInfos)
		{
			return memberInfos.Where(mi => Attribute.IsDefined(mi, typeof(T)));
		}

		public static Type GetMetadataClassType(this Type type)
		{
			var metadataAttrib = type
				.GetCustomAttributes(typeof(MetadataTypeAttribute), true)
				.OfType<MetadataTypeAttribute>()
				.First();
			return metadataAttrib.MetadataClassType;
		}
	}
}