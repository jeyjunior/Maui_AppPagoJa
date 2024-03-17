namespace Maui_PagoJa.Views;

public partial class RegistroBoleto : ContentPage
{
	public RegistroBoleto()
	{
		InitializeComponent();
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
		BindDiasVencimento();
        BindMesVencimento();
        BindAnoVencimento();
        HabilitarComponentesVencimento();
    }

    private void BindDiasVencimento()
    {
        int[] dias = new int[31];

        for (int i = 0; i < dias.Length; i++)
        {
            dias[i] = i + 1;
        }

        this.pckDias.ItemsSource = dias;
        this.pckDias.SelectedIndex = 19;
    }

    private void BindMesVencimento()
    {
        int[] mes = new int[12];

        for (int i = 0; i < mes.Length; i++)
        {
            mes[i] = i + 1;
        }

        this.pckMes.ItemsSource = mes;
        this.pckMes.SelectedIndex = DateTime.Today.Month - 1;
    }

    private void BindAnoVencimento()
    {
        int anoAtual = DateTime.Today.Year;

        int[] ano = new int[30];

        for (int i = 0; i < ano.Length; i++)
        {
            ano[i] = anoAtual + i;
        }

        this.pckAno.ItemsSource = ano;
        this.pckAno.SelectedIndex = 0;
    }

    private void chkPgtoContinuo_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        HabilitarComponentesVencimento();
    }

    private void HabilitarComponentesVencimento()
    {
        this.lblMes.IsEnabled = !this.chkPgtoContinuo.IsChecked;
        this.pckMes.IsEnabled = !this.chkPgtoContinuo.IsChecked;

        this.lblAno.IsEnabled = !this.chkPgtoContinuo.IsChecked;
        this.pckAno.IsEnabled = !this.chkPgtoContinuo.IsChecked;
    }
}