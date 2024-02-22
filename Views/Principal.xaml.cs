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
    private async void AddMiniaturas()
    {
        atualizando = true;

        await Dispatcher.DispatchAsync(() =>
        {
            if (poolMiniaturaBoletosView.Count() > 0)
            {
                foreach (var miniatura in poolMiniaturaBoletosView)
                {
                    MainStackLayout.Children.Add(miniatura);
                }
            }
        });

        atualizando = false;
    }

	public async void AtualizarMiniaturas()
	{
        atualizando = true;

        //await Dispatcher.DispatchAsync(() =>
        //{
        //    var boletoCollection = boletoRepository.GetBoletosAsync();

        //    //if (boletoCollection != null && boletoCollection.Count() > 0)
        //    //{
        //    //    for (int i = 0; i < boletoCollection.Count(); i++)
        //    //    {
        //    //        var boleto = boletoCollection[i];
        //    //        ((MiniaturaBoletoView)MainStackLayout.Children[i]).DefinirInformacoes(boleto);
        //    //    }
        //    //}
        //});

        atualizando = false;
    }
    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        AtualizarMiniaturas();
    }
}


