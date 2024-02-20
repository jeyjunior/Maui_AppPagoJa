namespace Maui_PagoJa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FlyoutPageMenu();
        }
    }
}
