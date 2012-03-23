using NUnit.Framework;
using scratch.NHibernate;
using scratch.NHibernate.Entities;
using NBehave.Spec.NUnit;

namespace scratch.Tests.NHibernate
{
    [TestFixture]
    public class NHibernateTest
    {
        private SessionBuilder _sessionBuilder;
        private Person _person;

        [SetUp]
        public void SetUp()
        {
            _sessionBuilder = new SessionBuilder();
        }

        [Test]
        public void Should_map()
        {
            _person = new Person { Age = 20, FirstName = "Foo", LastName = "Bar" };
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

        [Test]
        public void Should_map_even_when_using_aop_proxy()
        {
            var proxyBuilder = new ProxyBuilder();
            _person = proxyBuilder.GetProxy(new Person { Age = 20, FirstName = "Foo", LastName = "Bar" });
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