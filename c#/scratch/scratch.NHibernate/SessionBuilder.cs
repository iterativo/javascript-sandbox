using NHibernate;
using NHibernate.Cfg;

namespace scratch.NHibernate
{
    public class SessionBuilder : ISessionBuilder
    {
        public ISession GetSession()
        {
            var config = new Configuration();
            return config
                .Configure("hibernate.cfg.xml")
                .SetInterceptor(new DataBindingInterceptor())
                .BuildSessionFactory()
                .OpenSession();
        }
    }

    public interface ISessionBuilder
    {
        ISession GetSession();
    }
}