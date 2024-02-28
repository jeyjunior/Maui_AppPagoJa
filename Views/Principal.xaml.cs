using CommunityToolkit.Maui.Core;
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
    private readonly IOrdenacaoBoletoRepository ordenacaoBoletoRepository;
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
        ordenacaoBoletoRepository = App.Container.GetInstance<IOrdenacaoBoletoRepository>();

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

        // APENAS PARA TESTE, REMOVER QUANDO COMEÇAR A IMPLEMENTAR BOLETOS MANUALMENTE
        if(resultado == null || resultado.Count() <= 0)
        {
            boletoRepository.AddBoletosParaTeste();

            resultado = boletoRepository.GetBoletosAsync().Result;
        }

        // SEMPRE QUE FOR ADD BOLETOS A STACK vStackMain, LIMPAR A COLEÇÃO CHILDREN
        //if (vStackMain.Children.Count() > 0)
        //    vStackMain.Children.Clear();

        if (resultado != null && resultado.Count() > 0)
        {
            var boletosCollection = resultado
                //.OrderByDescending(i => i.Status == StatusBoleto.Vencido)
                //.ThenByDescending(i => i.Status == StatusBoleto.EmAberto)
                .ToArray();

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

    private IEnumerable<Boleto> Ordenar()
    {
        return null;
    }


    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        CarregarBoletos();
    }

    private void btnOptions_Clicked(object sender, EventArgs e)
    {
        var popup = new PopupOpcoesPrincipal();
        popup.Closed += PopupOpcoesPrincipal_Closed;

        this.ShowPopup(popup);
    }

    private void PopupOpcoesPrincipal_Closed(object sender, PopupClosedEventArgs e)
    {
        // ATUALIZAR GRID
        var resultado = ordenacaoBoletoRepository.GetOrdenacao().Result;

        if(resultado != null)
        {

        }
    }
}


