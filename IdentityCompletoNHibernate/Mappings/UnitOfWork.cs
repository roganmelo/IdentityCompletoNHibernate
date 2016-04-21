using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace IdentityCompletoNHibernate.Mappings
{
    //public class NHibernateHelper
    //{
    //    private static ISessionFactory sessionFactory;

    //    public static ISession OpenSession()
    //    {
    //        var path = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), @"schema.sql");

    //        sessionFactory = Fluently.Configure()
    //            .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(x => x.FromConnectionStringWithKey("ConnectionString")))
    //            .ExposeConfiguration(cfg => new SchemaExport(cfg).SetOutputFile(path).Create(true, true))
    //            .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
    //            .BuildSessionFactory();

    //        return sessionFactory.OpenSession();
    //    }
    //}

    public class UnitOfWork
    {
        private ITransaction _transaction;

        public ISession Session { get; private set; }

        private static ISessionFactory sessionFactory;

        public UnitOfWork()
        {
            Session = Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(x => x.FromConnectionStringWithKey("ConnectionString")).ShowSql())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory().OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                Session.Close();
            }
        }
    }
}