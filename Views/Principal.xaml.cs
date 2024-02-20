using Maui_PagoJa.Controls;

namespace Maui_PagoJa.Views;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();

		NavigationPage.SetTitleView(this, CustomComponents.GetCustomTitle("Principal"));
		//NavigationPage.SetTitleIconImageSource(this, "settings.svg");
		//NavigationPage.SetIconColor(this, Color.FromArgb("FF000000"));
    }
}