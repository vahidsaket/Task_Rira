using Autofac;
using TaskRira.DataAccess.Repositories;
using TaskRira.DataAccess.Repositories.Impl;

namespace TaskRira.DataAccess
{
    public static class AutofacConfigurationExtensions
    {
        public static void AddServices(this ContainerBuilder containerBuilder)
        {
            //RegisterType > As > Liftetime
            containerBuilder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerLifetimeScope();
        }
    }
}
