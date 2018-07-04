using Autofac;
using Autofac.Integration.WebApi;
using CreditCardValidationAPI.Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace CreaditCardValidationAPI.App_Start
{
    public class AutoFacConfig
    {
        public static void Register()
        {
            var builder = new Autofac.ContainerBuilder();

            var config = GlobalConfiguration.Configuration;
    
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();


            builder.RegisterModule(new EFModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new RepositoryModule());

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private class EFModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType(typeof(CreditDBEntities)).As(typeof(CreditDBEntities)).InstancePerLifetimeScope();
            }
        }

        private class ServiceModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
              
                builder.RegisterAssemblyTypes(Assembly.Load("CreditCardValidationAPI.Services"))
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces();
             
            }
        }

        private class RepositoryModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterAssemblyTypes(Assembly.Load("CreditCardValidationAPI.Repositories"))
                       .Where(t => t.Name.EndsWith("Repository"))
                       .AsImplementedInterfaces();
            }
        }
    }
}