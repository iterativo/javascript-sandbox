using scratch.NHibernate.Entities;
using Spring.Aop.Framework;

namespace scratch.NHibernate
{
    public class ProxyBuilder : IProxyBuilder
    {
        public Person GetProxy(Person target)
        {
            var proxyFactory = new ProxyFactory(target) {ProxyTargetType = true};
            return (Person) proxyFactory.GetProxy();
        }
    }

    public interface IProxyBuilder
    {
        Person GetProxy(Person target);
    }
}