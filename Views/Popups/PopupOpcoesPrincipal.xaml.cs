using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace Maui_PagoJa.Views.Popups;
public partial class PopupOpcoesPrincipal  : Popup
{
	public PopupOpcoesPrincipal()
	{
		InitializeComponent();
	}

    private void Popup_Opened(object sender, CommunityToolkit.Maui.Core.PopupOpenedEventArgs e)
    {
		this.pckOrdenacao.ItemsSource = new List<string>()
		{
			"Em Aberto", "Pago", "Vencido", "Nome A - Z", "Nome Z - A", "Data Crescente", "Data Decrescente", "Menor Valor", "Maior Valor"
        };

		this.pckOrdenacao.SelectedIndex = 0;
    }
}