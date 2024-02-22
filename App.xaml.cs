using Maui_PagoJa.Controls;
using Maui_PagoJa.Interfaces;
using Maui_PagoJa.Models;
using SimpleInjector;
using SQLite;

namespace Maui_PagoJa
{
    public partial class App : Application
    {
        public static Container Container { get; private set; }
        public static SQLiteAsyncConnection asyncConnection;
        public App()
        {
            InitializeComponent();

            Container = new Container();
            RegisterDependencies();

            CreateDataBase();

            MainPage = new TabbedPageMenu();
        }

        private void RegisterDependencies()
        {
            Container.Register<IMiniaturaBoletoControl, MiniaturaBoletoControl>(Lifestyle.Singleton);
            Container.Register<IBoletoRepository, BoletoRepository>(Lifestyle.Singleton);
        }

        public async Task CreateDataBase()
        {
            if (asyncConnection is not null)
                return;

            asyncConnection = new SQLiteAsyncConnection(Data.DBase.DataBasePath, Data.DBase.Flags);
            await asyncConnection.CreateTableAsync<Boleto>();
        }

        public async Task ClearDataBase()
        {
            if (asyncConnection is not null)
                return;

            asyncConnection = new SQLiteAsyncConnection(Data.DBase.DataBasePath, Data.DBase.Flags);

            await asyncConnection.DropTableAsync<Boleto>();
        }
    }
}
