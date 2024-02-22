using Maui_PagoJa.Controls;
using Maui_PagoJa.Interfaces;
using SimpleInjector;

namespace Maui_PagoJa
{
    public partial class App : Application
    {
        public static Container Container { get; private set; }
        public App()
        {
            InitializeComponent();

            Container = new Container();
            RegisterDependencies();

            MainPage = new TabbedPageMenu();
        }

        private void RegisterDependencies()
        {
            Container.Register<IMiniaturaBoletoControl, MiniaturaBoletoControl>(Lifestyle.Singleton);
            Container.Register<IBoletoControl, BoletoRepository>(Lifestyle.Singleton);
        }
    }
}
