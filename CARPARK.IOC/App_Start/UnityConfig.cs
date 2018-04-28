using CARPARK.Data.Model;
using CARPARK.Data.Repository;
using CARPARK.Data.UnitofWork;
using CARPARK.Service.Interfaces;
using CARPARK.Service.Services;
using System;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace CARPARK.IOC
{
    //Unity.MVC5 Dosyas� Nuget'den kurulumu yap�ld�.
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            RegisterTypes(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void RegisterTypes(UnityContainer container)
        {
            //Bu k�s�mda olu�turulan nesneler tan�mlanarak birden fazla kez nesne �retmenin �n�ne ge�i�mektedir.Burada her nesne tan�mlamas� yap�lmak zorundad�r.
            container.BindInRequestScope<IUnitofWork, UnitofWork>();
            container.BindInRequestScope<ILoginService, LoginService>();
            container.BindInRequestScope<IRepository<Uye>, Repository<Uye>>();

        }
        public static void BindInRequestScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new HierarchicalLifetimeManager());
        }
    }
}