namespace Maui_PagoJa.Views;

public partial class MiniaturaBoletos : ContentView
{
	public MiniaturaBoletos(string nome, string data, string preco, StatusBoleto status)
	{
		InitializeComponent();

		lblNome.Text = nome;
		lblData.Text = data;
		lblPreco.Text = $"R$ {preco}";

		if (status == StatusBoleto.EmAberto)
		{
			bxvStatus.Color = Color.FromArgb("BFC200");
		}
		else if(status == StatusBoleto.Pago)
		{
            bxvStatus.Color = Color.FromArgb("33C200");
        }
		else if(status == StatusBoleto.Vencido)
		{
            bxvStatus.Color = Color.FromArgb("C20000");
        }
    }

	public enum StatusBoleto
	{
		EmAberto = 0,
		Pago = 1,
		Vencido = 2
	}
}