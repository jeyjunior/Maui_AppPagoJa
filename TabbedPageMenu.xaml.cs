using Maui_PagoJa.Controls;
using Maui_PagoJa.Views;

namespace Maui_PagoJa;
public partial class TabbedPageMenu : TabbedPage
{
	public TabbedPageMenu()
	{
		InitializeComponent();
    }

    private void TabbedPage_CurrentPageChanged(object sender, EventArgs e)
    {
        if(CurrentPage is Principal principal)
        {
            principal.CarregarBoletos();
        }
    }
}