using Maui_PagoJa.Controls;
using Maui_PagoJa.Controls.Interfaces;
using Maui_PagoJa.Controls.Repository;
using Maui_PagoJa.Models;
using Maui_PagoJa.Models.Entidades;
using SimpleInjector;
using SQLite;

namespace Maui_PagoJa
{
    public partial class App : Application
    {
        public static Container Container { get; private set; }
        public static SQLiteAsyncConnection asyncConnection;
        public App()
        {
            InitializeComponent();

            Container = new Container();
            RegisterDependencies();

            CreateDataBase();
            SetOrdenacaoValues();

            MainPage = new TabbedPageMenu();
        }


        private void RegisterDependencies()
        {
            Container.Register<IMiniaturaBoletoControl, MiniaturaBoletoControl>(Lifestyle.Singleton);
            Container.Register<IBoletoRepository, BoletoRepository>(Lifestyle.Singleton); 
            Container.Register<IOrdenacaoBoletoRepository, OrdenacaoBoletoRepository>(Lifestyle.Singleton);
        }

        public async Task CreateDataBase()
        {
            if (asyncConnection is not null)
                return;


/* Alteração não mesclada do projeto 'Maui_PagoJa (net7.0-android)'
Antes:
            asyncConnection = new SQLiteAsyncConnection(Data.DBase.DataBasePath, Data.DBase.Flags);
Após:
            asyncConnection = new SQLiteAsyncConnection(DBase.DataBasePath, DBase.Flags);
*/
            asyncConnection = new SQLiteAsyncConnection(Controls.Data.DBase.DataBasePath, Controls.Data.DBase.Flags);
            await asyncConnection.CreateTableAsync<Boleto>();
            await asyncConnection.CreateTableAsync<Ordenacao>();
            await asyncConnection.CreateTableAsync<LancamentoBoleto>();
        }


        private async Task SetOrdenacaoValues()
        {
            if (asyncConnection is null)
            {

/* Alteração não mesclada do projeto 'Maui_PagoJa (net7.0-android)'
Antes:
                asyncConnection = new SQLiteAsyncConnection(Data.DBase.DataBasePath, Data.DBase.Flags);
Após:
                asyncConnection = new SQLiteAsyncConnection(DBase.DataBasePath, DBase.Flags);
*/
                asyncConnection = new SQLiteAsyncConnection(Controls.Data.DBase.DataBasePath, Controls.Data.DBase.Flags);
            }

            var resultado = asyncConnection.QueryAsync<Ordenacao>("SELECT * FROM Ordenacao").Result;

            if (resultado != null && resultado.Count() > 0)
                return;

            var ordenacaoCollection = new List<Ordenacao>()
            {
                new Ordenacao { Descricao = "Em Aberto", Sequencia = 3, Ativo = true },
                new Ordenacao { Descricao = "Pago", Sequencia = 0, Ativo = true },
                new Ordenacao { Descricao = "Vencido", Sequencia = 2, Ativo = false },
                new Ordenacao { Descricao = "Nome A - Z", Sequencia = 1, Ativo = true },
                new Ordenacao { Descricao = "Nome Z - A", Sequencia = 0, Ativo = false },
                new Ordenacao { Descricao = "Data Crescente", Sequencia = 0, Ativo = false },
                new Ordenacao { Descricao = "Data Decrescente", Sequencia = 0, Ativo = false },
                new Ordenacao { Descricao = "Menor Valor", Sequencia = 0, Ativo = false },
                new Ordenacao { Descricao = "Maior Valor", Sequencia = 0, Ativo = false }
            };

            await asyncConnection.InsertAllAsync(ordenacaoCollection);
        }
    }
}
