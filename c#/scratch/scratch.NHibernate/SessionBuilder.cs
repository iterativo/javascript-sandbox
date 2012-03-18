using NHibernate;
using NHibernate.Cfg;

namespace scratch.NHibernate
{
    public class SessionBuilder : ISessionBuilder
    {
        public ISession GetSession()
        {
            var config = new Configuration();
            config.Configure("hibernate.cfg.xml");
            return config.BuildSessionFactory().OpenSession();
        }
    }

    public interface ISessionBuilder
    {
        ISession GetSession();
    }
}