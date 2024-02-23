using Maui_PagoJa.Controls;
using Maui_PagoJa.Interfaces;
using Maui_PagoJa.Models;

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
        // Qtd será definida nas configs?
        poolMiniaturaBoletosView = miniaturaBoletoControl.CriarPool(30);
    }
    private void AddMiniaturas()
    {
        if (poolMiniaturaBoletosView.Count() > 0)
        {
            foreach (var miniatura in poolMiniaturaBoletosView)
            {
                MainStackLayout.Children.Add(miniatura);
            }
        }
    }

	public void CarregarBoletos()
	{
        //atualizando = true;

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
                if (MainStackLayout.Children != null)
                {
                    var boleto = boletosCollection[i];
                    ((MiniaturaBoletoView)MainStackLayout.Children[i]).DefinirInformacoes(boleto);
                    ((MiniaturaBoletoView)MainStackLayout.Children[i]).IsVisible = true;
                }
            }
        }

        //atualizando = false;
    }
    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        CarregarBoletos();
    }
}


