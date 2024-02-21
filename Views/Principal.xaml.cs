using Maui_PagoJa.Controls;

namespace Maui_PagoJa.Views;

public partial class Principal : ContentPage
{
    private bool atualizando = false;
	public Principal()
	{
		InitializeComponent();
    }
	public void AtualizarMiniaturas()
	{
        if (!atualizando)
        {
            AddMiniaturas();
        }
    }
    private async void AddMiniaturas()
    {
        atualizando = true;

        await Dispatcher.DispatchAsync(() =>
        {
            MainStackLayout.Children.Clear();

            MainStackLayout.Children.Add(new MiniaturaBoletos("Boleto de Aluguel", "10/02/2024", "850,00", MiniaturaBoletos.StatusBoleto.Pago));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Conta de Internet", "15/02/2024", "89,90", MiniaturaBoletos.StatusBoleto.EmAberto));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Condomínio", "20/02/2024", "350,00", MiniaturaBoletos.StatusBoleto.EmAberto));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Financiamento do Carro", "25/02/2024", "1250,00", MiniaturaBoletos.StatusBoleto.Vencido));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Fatura de Cartão de Crédito ", "28/02/2024", "950,00", MiniaturaBoletos.StatusBoleto.Pago));

            MainStackLayout.Children.Add(new MiniaturaBoletos("Conta de Luz", "05/03/2024", "180,00", MiniaturaBoletos.StatusBoleto.EmAberto));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Conta de Água", "10/03/2024", "60,00", MiniaturaBoletos.StatusBoleto.Pago));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Mensalidade de Academia", "15/03/2024", "200,00", MiniaturaBoletos.StatusBoleto.EmAberto));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Seguro Residencial", "20/03/2024", "300,00", MiniaturaBoletos.StatusBoleto.Vencido));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Assinatura de Streaming", "25/03/2024", "29,90", MiniaturaBoletos.StatusBoleto.Pago));

            MainStackLayout.Children.Add(new MiniaturaBoletos("Parcela do Empréstimo", "02/04/2024", "500,00", MiniaturaBoletos.StatusBoleto.EmAberto));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Imposto de Renda", "05/04/2024", "450,00", MiniaturaBoletos.StatusBoleto.Pago));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Taxa de Condomínio", "10/04/2024", "250,00", MiniaturaBoletos.StatusBoleto.EmAberto));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Mensalidade Escolar", "15/04/2024", "800,00", MiniaturaBoletos.StatusBoleto.Vencido));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Pagamento de Empréstimo", "20/04/2024", "600,00", MiniaturaBoletos.StatusBoleto.Pago));

            MainStackLayout.Children.Add(new MiniaturaBoletos("Aluguel de Carro", "25/04/2024", "300,00", MiniaturaBoletos.StatusBoleto.EmAberto));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Compra de Supermercado", "30/04/2024", "150,00", MiniaturaBoletos.StatusBoleto.Pago));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Compra Online", "05/05/2024", "100,00", MiniaturaBoletos.StatusBoleto.EmAberto));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Assinatura de Revista", "10/05/2024", "20,00", MiniaturaBoletos.StatusBoleto.Vencido));
            MainStackLayout.Children.Add(new MiniaturaBoletos("Recarga de Celular", "15/05/2024", "50,00", MiniaturaBoletos.StatusBoleto.Pago));
        });

        atualizando = false;
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        AtualizarMiniaturas();
    }

    
}