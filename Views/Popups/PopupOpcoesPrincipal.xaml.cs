using CommunityToolkit.Maui.Views;
using Maui_PagoJa.Interfaces;
using Maui_PagoJa.Models.Entidades;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace Maui_PagoJa.Views.Popups;
public partial class PopupOpcoesPrincipal  : Popup
{
    #region Interfaces
    private readonly IOrdenacaoBoletoRepository ordenacaoBoletoRepository;
	#endregion
	#region Propriedades
	private IEnumerable<Ordenacao> ordenacaoCollection;
    #endregion


    public PopupOpcoesPrincipal()
	{
		InitializeComponent();

		ordenacaoBoletoRepository = App.Container.GetInstance<IOrdenacaoBoletoRepository>();

		CarregarInformacoesOrdenacao();
    }

	private void CarregarInformacoesOrdenacao()
	{
        ordenacaoCollection = ordenacaoBoletoRepository.GetOrdenacao().Result;

		if(ordenacaoCollection != null && ordenacaoCollection.Count() > 0)
		{
			this.pckOrdenacao.ItemsSource = ordenacaoCollection.Select(i => i.Descricao).ToList();

			string descricao = "Nome A - Z";
			var ordenacaoSelecionado = ordenacaoCollection.FirstOrDefault(i => i.Sequencia == 1 && i.Ativo);

			if (ordenacaoSelecionado != null && ordenacaoSelecionado.Sequencia > 0)
				descricao = ordenacaoSelecionado.Descricao;

            this.pckOrdenacao.SelectedItem = descricao;
		}
	}

    private void Popup_Opened(object sender, CommunityToolkit.Maui.Core.PopupOpenedEventArgs e)
    {

    }

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
		var ordenacao = ordenacaoCollection
			.FirstOrDefault(i => i.Descricao == this.pckOrdenacao.SelectedItem.ToString());
			
		if(ordenacao != null)
		{
			ordenacao.Ativo = true;
			ordenacao.Sequencia = 1;

			ordenacaoBoletoRepository.UpdateOrdenacao(6, 5, 2);
		}

		var teste = ordenacaoBoletoRepository.GetOrdenacao();

		if(teste.Result != null)
		{

		}

		this.Close();
	}
}