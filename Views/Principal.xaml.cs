using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Maui_PagoJa.Controls;
using Maui_PagoJa.Controls.Interfaces;
using Maui_PagoJa.Models;
using Maui_PagoJa.Models.Entidades;
using Maui_PagoJa.Views.Popups;
using System.Globalization;

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
    private IEnumerable<Boleto> boletosCollection;
    //private IEnumerable<Ordenacao> ordenacaoCollection;
    #endregion

    #region Construtor
    public Principal()
	{
		InitializeComponent();

        miniaturaBoletoControl = App.Container.GetInstance<IMiniaturaBoletoControl>();
        boletoRepository = App.Container.GetInstance<IBoletoRepository>();
        //ordenacaoBoletoRepository = App.Container.GetInstance<IOrdenacaoBoletoRepository>();

        CarregarPoolMiniaturas();
        AddMiniaturas();
    }
    #endregion
    private void CarregarPoolMiniaturas()
    {
        poolMiniaturaBoletosView = miniaturaBoletoControl.CriarPool(30);
    }

    private void CarregarInitialSetup()
    {
        //var resultado = ordenacaoBoletoRepository.GetOrdenacao();

        //if (resultado.Result != null)
        //    ordenacaoCollection = resultado.Result;
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
    // Teste Repositório
	public void CarregarBoletos()
	{
        foreach (var item in poolMiniaturaBoletosView)
        {
            item.IsVisible = false;
        }

        boletosCollection = boletoRepository.GetBoletosAsync().Result;

        // APENAS PARA TESTE, REMOVER QUANDO COMEÇAR A IMPLEMENTAR BOLETOS MANUALMENTE
        if(boletosCollection == null || boletosCollection.Count() <= 0)
        {
            boletoRepository.AddBoletosParaTeste();

            boletosCollection = boletoRepository.GetBoletosAsync().Result;
        }

        if (boletosCollection != null && boletosCollection.Count() > 0)
        {
            var boletosOrdenados = boletosCollection
                .OrderByDescending(i => i.Status == StatusBoleto.Vencido)
                .ThenByDescending(i => i.Status == StatusBoleto.EmAberto)
                .ThenByDescending(i => i.Status == StatusBoleto.Pago)
                .ThenBy(i => i.DiaVencimento)
                .ToArray();

            for (int i = 0; i < boletosOrdenados.Count(); i++)
            {
                if (vStackMain.Children != null)
                {
                    var boleto = boletosOrdenados[i];
                    ((MiniaturaBoletoView)vStackMain.Children[i]).DefinirInformacoes(boleto);
                    ((MiniaturaBoletoView)vStackMain.Children[i]).IsVisible = true;
                }
            }
        }

        AtualizarLabelsQuantidades();
    }

    private void AtualizarLabelsQuantidades() 
    {
        lblBoletosTotal.Text = $"Nenhum boleto";
        lblValorTotal.Text = $"R$ 00,00";

        if (boletosCollection != null && boletosCollection.Count() > 0)
        {
            var valorTotal = boletosCollection.Sum(s => s.Valor).ToString("C", new CultureInfo("pt-BR"));
            var boletosTotal = boletosCollection.Count() == 1 ? boletosCollection.Count() + " Boleto" : boletosCollection.Count() + " Boletos";

            lblValorTotal.Text = valorTotal;
            lblBoletosTotal.Text = boletosTotal;
        }
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        CarregarInitialSetup();
        CarregarBoletos();
    }

    private void btnOptions_Clicked(object sender, EventArgs e)
    {
        return;

        var popup = new PopupOpcoesPrincipal();
        popup.Closed += PopupOpcoesPrincipal_Closed;

        this.ShowPopup(popup);
    }

    private void PopupOpcoesPrincipal_Closed(object sender, PopupClosedEventArgs e)
    {
        CarregarInitialSetup();
        CarregarBoletos();
    }
}


