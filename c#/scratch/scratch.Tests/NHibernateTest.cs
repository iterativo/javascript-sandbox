using NUnit.Framework;
using scratch.NHibernate;
using scratch.NHibernate.Entities;
using NBehave.Spec.NUnit;

namespace scratch.Tests
{
    [TestFixture]
    public class NHibernateTest
    {
        private SessionBuilder _sessionBuilder;
        private readonly Person _person = new Person { Age = 20, FirstName = "Foo", LastName = "Bar" };

        [Test]
        public void Should_map()
        {
            _sessionBuilder = new SessionBuilder();
            using (var session = _sessionBuilder.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(_person);
                    transaction.Commit();
                }
            }
            using (var session = _sessionBuilder.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var people = session.CreateCriteria<Person>().List<Person>();
                    transaction.Commit();
                    people.Count.ShouldEqual(1);
                    people[0].Age.ShouldEqual(20);
                    people[0].FirstName.ShouldEqual("Foo");
                    people[0].LastName.ShouldEqual("Bar");
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var session = _sessionBuilder.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(_person);
                    transaction.Commit();
                }
            }
        }
    }
}