using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceImplementList.Implemetations;
using System;

using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace AbstractSweetShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
			var container = BuildUnityContainer();

			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IBuyerService, BuyerServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMaterialService, MaterialServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICandyService, CandyServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceList>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
