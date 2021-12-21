using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Autofac;
using HitExercise.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HitExercise.DataAccess.Core.Interfaces;



namespace HitExercise.MVC.App_Start
{
    public class ConteinerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //---------------------------------------------------------------------------------------------------------------------------
            //Register UnitOfWork
            builder.RegisterType<HitExercise.DataAccess.Persistence.DataAccess>().As<IDataAccess>().InstancePerRequest();

            //Register DbContext
            builder.RegisterType<ApplicationDbContext>().InstancePerLifetimeScope();
            //---------------------------------------------------------------------------------------------------------------------------
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static void RegisterContainerApi()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //---------------------------------------------------------------------------------------------------------------------------

            //Register UnitOfWork
            builder.RegisterType<HitExercise.DataAccess.Persistence.DataAccess>().As<IDataAccess>().InstancePerRequest();

            //Register DbContext
            builder.RegisterType<ApplicationDbContext>().InstancePerLifetimeScope();

            //---------------------------------------------------------------------------------------------------------------------------

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }

}