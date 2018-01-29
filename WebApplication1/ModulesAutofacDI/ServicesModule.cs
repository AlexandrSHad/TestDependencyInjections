using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.ModulesAutofacDI
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CharacterRepository>().As<ICharacterRepository>().InstancePerRequest();

            builder.RegisterType<Operation>().As<IOperationTransient>(); // .InstancePerDependency (Transient) by default
            builder.RegisterType<Operation>().As<IOperationScoped>().InstancePerLifetimeScope();
            builder.RegisterType<Operation>().As<IOperationSingleton>().SingleInstance();
            //builder.RegisterType<Operation>().As<IOperationSingletonInstance>().SingleInstance(new Operation(Guid.Empty)); //I don't find how to do this with Autofac
            builder.RegisterType<OperationService>().AsSelf();
        }
    }
}
