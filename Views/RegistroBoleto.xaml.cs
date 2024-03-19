namespace Maui_PagoJa.Views;

public partial class RegistroBoleto : ContentPage
{
	public RegistroBoleto()
	{
		InitializeComponent();
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        CarregarDropDowns();
        HabilitarComponentesVencimento();
        Limpar();
    }

    #region Metodos
    private void Limpar()
    {
        this.txtNomeBoleto.Text = "";
        this.txtValorParcela.Text = "";
        this.pckDias.SelectedIndex = DateTime.Today.Day - 1; 
        this.pckAno.SelectedIndex = 0;
        this.pckMes.SelectedIndex = DateTime.Today.Month - 1;
        this.chkPgtoContinuo.IsChecked = true;
    }
    private void CarregarDropDowns()
    {
        BindDiasVencimento();
        BindMesVencimento();
        BindAnoVencimento();
    }

    private void BindDiasVencimento()
    {
        int[] dias = new int[31];

        for (int i = 0; i < dias.Length; i++)
        {
            dias[i] = i + 1;
        }

        this.pckDias.ItemsSource = dias;
    }

    private void BindMesVencimento()
    {
        int[] mes = new int[12];

        for (int i = 0; i < mes.Length; i++)
        {
            mes[i] = i + 1;
        }

        this.pckMes.ItemsSource = mes;
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

    }

    private void HabilitarComponentesVencimento()
    {
        this.lblMes.IsEnabled = !this.chkPgtoContinuo.IsChecked;
        this.pckMes.IsEnabled = !this.chkPgtoContinuo.IsChecked;

        this.lblAno.IsEnabled = !this.chkPgtoContinuo.IsChecked;
        this.pckAno.IsEnabled = !this.chkPgtoContinuo.IsChecked;
    }

    #endregion

    #region Eventos
    private void chkPgtoContinuo_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        HabilitarComponentesVencimento();
    }
    private void txtValorParcela_TextChanged(object sender, TextChangedEventArgs e)
    {

        if (((Entry)sender).Text != "")
            return;
    }
    private void btnErase_Clicked(object sender, EventArgs e)
    {
        Limpar();
    }
    #endregion

}