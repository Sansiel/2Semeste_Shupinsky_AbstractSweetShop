using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceImplementDataBase;
using AbstractSweetShopServiceImplementDataBase.Implementations;
using System;

using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using System.Data.Entity;

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
            currentContainer.RegisterType<DbContext, AbstractDbContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBuyerService, BuyerServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMaterialService, MaterialServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICandyService, CandyServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStoreService, StoreServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportService, ReportServiceDB>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
