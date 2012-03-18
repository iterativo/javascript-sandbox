using NHibernate;
using scratch.NHibernate.Entities;

namespace scratch.NHibernate
{
    public class DataBindingInterceptor : EmptyInterceptor
    {
        public override string GetEntityName(object entity)
        {
            return typeof(Person).FullName; // Deals with Spring AOP Decorator Proxy mapping
        }
    }
}