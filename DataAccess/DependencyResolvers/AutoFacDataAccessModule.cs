using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB;
using DataAccess.Concrete.DataBases.MongoDB;
using DataAccess.Concrete.DataBases.MongoDB.Utilities.ConnectionResolvers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DependencyResolvers
{
    public class AutoFacDataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoDB_UserDal>().As<IUserDal>();
            builder.RegisterType<MongoDB_RestaurantDal>().As<IRestaurantDal>();
            builder.RegisterType<MongoDB_CustomerDal>().As<ICustomerDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                       .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                       {
                           Selector = new AspectInterceptorSelector()
                       }).SingleInstance();

        }
    }
}
