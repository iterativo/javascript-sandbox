using System.Linq;
using System.Reflection;
using NUnit.Framework;
using scratch.Misc.MetadataTypeStuff;
using NBehave.Spec.NUnit;

namespace scratch.Tests.Misc.MetadataTypeStuff
{
    [TestFixture]
    public class ReflectionHelperTester
    {
        [Test]
        public void Should_determine_when_a_member_in_metaclass_has_attribute()
        {
            var metaclass = typeof (Foo).GetMetadataClassType();
            var memberInfos = metaclass
                .GetMembers(BindingFlags.Public | BindingFlags.Instance)
                .WithAttribute<IsCoolAttribute>();

            memberInfos.Count().ShouldEqual(2);
            memberInfos.SingleOrDefault(mi => mi.Name == "Bar").ShouldNotBeNull();
            memberInfos.SingleOrDefault(mi => mi.Name == "Baz").ShouldNotBeNull();
        }
    }
}