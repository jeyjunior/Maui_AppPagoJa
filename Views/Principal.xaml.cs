using CommunityToolkit.Maui.Views;
using Maui_PagoJa.Controls;
using Maui_PagoJa.Interfaces;
using Maui_PagoJa.Models;
using Maui_PagoJa.Views.Popups;

namespace Maui_PagoJa.Views;

public partial class Principal : ContentPage
{
    #region Interfaces
    private readonly IMiniaturaBoletoControl miniaturaBoletoControl;
    private readonly IBoletoRepository boletoRepository;
    #endregion

    #region Propriedades
    private IEnumerable<MiniaturaBoletoView> poolMiniaturaBoletosView;
    private bool atualizando = false;
    #endregion

    #region Construtor
    public Principal()
	{
		InitializeComponent();

        miniaturaBoletoControl = App.Container.GetInstance<IMiniaturaBoletoControl>();
        boletoRepository = App.Container.GetInstance<IBoletoRepository>();

        CarregarPoolMiniaturas();
        AddMiniaturas();
    }
    #endregion
    private void CarregarPoolMiniaturas()
    {
        // Qtd ser� definida nas configs?
        poolMiniaturaBoletosView = miniaturaBoletoControl.CriarPool(30);
    }
    private void AddMiniaturas()
    {
        if (poolMiniaturaBoletosView.Count() > 0)
        {
            foreach (var miniatura in poolMiniaturaBoletosView)
            {
                vStackMain.Children.Add(miniatura);
            }
        }
    }

	public void CarregarBoletos()
	{
        foreach (var item in poolMiniaturaBoletosView)
        {
            item.IsVisible = false;
        }


        var resultado = boletoRepository.GetBoletosAsync().Result;

        if (resultado != null && resultado.Count() > 0)
        {
            var boletosCollection = resultado.ToArray();

            for (int i = 0; i < boletosCollection.Count(); i++)
            {
                if (vStackMain.Children != null)
                {
                    var boleto = boletosCollection[i];
                    ((MiniaturaBoletoView)vStackMain.Children[i]).DefinirInformacoes(boleto);
                    ((MiniaturaBoletoView)vStackMain.Children[i]).IsVisible = true;
                }
            }
        }
    }
    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        CarregarBoletos();
    }

    private void btnOptions_Clicked(object sender, EventArgs e)
    {
        var popup = new PopupOpcoesPrincipal();
        this.ShowPopup(popup);
    }
}


