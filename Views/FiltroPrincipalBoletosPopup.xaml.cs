namespace Maui_PagoJa.Views;

public partial class FiltroPrincipalBoletosPopup : ContentPage
{
	public FiltroPrincipalBoletosPopup()
	{
		InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {

    }
}