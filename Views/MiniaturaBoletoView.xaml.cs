using Maui_PagoJa.Models;
using Microsoft.Maui.Controls;

namespace Maui_PagoJa.Views;

public partial class MiniaturaBoletoView : ContentView
{
	public MiniaturaBoletoView()
	{
		InitializeComponent();
    }

	public void DefinirInformacoes(Boleto boleto)
	{
		lblNome.Text = boleto.Nome;
		lblData.Text = boleto.DataVencimento.ToShortDateString();
		lblPreco.Text = boleto.Valor.ToString("C");

        if (boleto.Status == StatusBoleto.EmAberto)
        {
            bxvStatus.Color = Color.FromArgb("FAFF00");
        }
        else if (boleto.Status == StatusBoleto.Pago)
        {
            bxvStatus.Color = Color.FromArgb("14FF00");
        }
        else if (boleto.Status == StatusBoleto.Vencido)
        {
            bxvStatus.Color =  Color.FromArgb("FF0000");
        }
        else
        {
            bxvStatus.Color = Color.FromArgb("5B5B5B");
        }
    }
}