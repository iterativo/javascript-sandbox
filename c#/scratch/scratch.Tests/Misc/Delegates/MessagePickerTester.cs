using NUnit.Framework;
using scratch.Misc.Delegates;
using NBehave.Spec.NUnit;

namespace scratch.Tests.Misc.Delegates
{
    [TestFixture]
    public class MessagePickerTester
    {
        [Test]
        public void Should_resolve_message()
        {
            var john = new Person {Name = "John", Gender = Gender.Male, Age = 20};
            var grace = new Person {Name = "Grace", Gender = Gender.Female, Age = 18};

            var johnConfig = MessagePicker.GetMessageConfig(john);
            johnConfig.Message.ShouldEqual("John");

            var graceConfig = MessagePicker.GetMessageConfig(grace);
            graceConfig.Message.ShouldEqual("18");
        }
    }
}