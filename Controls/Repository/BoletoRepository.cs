using Maui_PagoJa.Interfaces;
using Maui_PagoJa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_PagoJa.Controls
{
    public class BoletoRepository : IBoletoRepository
    {
        public int SaveBoletoAsync(Boleto boleto)
        {
            var resultado = App.asyncConnection.InsertAsync(boleto);

            if(resultado.Result != null)
            {
                return resultado.Result;
            }

            return -1;
        }

        public async Task<IEnumerable<Boleto>> GetBoletosAsync()
        {
            string sql = $"SELECT * FROM Boleto LIMIT 30";

            var resultado = App.asyncConnection.QueryAsync<Boleto>(sql);

            if(resultado.Result != null)
            {
                return resultado.Result.ToList();
            }

            return null;
        }

        public void AddBoletosParaTeste()
        {
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Aluguel", DataVencimento = Convert.ToDateTime("01/05/2026"), Valor = 850.00, Status = StatusBoleto.EmAberto });
            SaveBoletoAsync(new Boleto() { Nome = "Conta de Internet", DataVencimento = Convert.ToDateTime("02/05/2026"), Valor = 79.90, Status = StatusBoleto.Nenhum });
            SaveBoletoAsync(new Boleto() { Nome = "Conta de Luz", DataVencimento = Convert.ToDateTime("03/05/2026"), Valor = 150.00, Status = StatusBoleto.Pago });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Condomínio", DataVencimento = Convert.ToDateTime("04/05/2026"), Valor = 300.00, Status = StatusBoleto.Vencido });
            SaveBoletoAsync(new Boleto() { Nome = "Parcela do Empréstimo", DataVencimento = Convert.ToDateTime("05/05/2026"), Valor = 500.00, Status = StatusBoleto.EmAberto });
            SaveBoletoAsync(new Boleto() { Nome = "Fatura de Cartão de Crédito", DataVencimento = Convert.ToDateTime("06/05/2026"), Valor = 1200.00, Status = StatusBoleto.Pago });
            SaveBoletoAsync(new Boleto() { Nome = "Mensalidade de Academia", DataVencimento = Convert.ToDateTime("08/05/2026"), Valor = 200.00, Status = StatusBoleto.Vencido });
            SaveBoletoAsync(new Boleto() { Nome = "Aluguel de Carro", DataVencimento = Convert.ToDateTime("09/05/2026"), Valor = 300.00, Status = StatusBoleto.Nenhum });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Água", DataVencimento = Convert.ToDateTime("07/05/2026"), Valor = 90.00, Status = StatusBoleto.EmAberto });
            SaveBoletoAsync(new Boleto() { Nome = "Compra de Supermercado", DataVencimento = Convert.ToDateTime("10/05/2026"), Valor = 250.00, Status = StatusBoleto.Pago });
            SaveBoletoAsync(new Boleto() { Nome = "Assinatura de Streaming", DataVencimento = Convert.ToDateTime("11/05/2026"), Valor = 29.90, Status = StatusBoleto.EmAberto });
            SaveBoletoAsync(new Boleto() { Nome = "Compra Online", DataVencimento = Convert.ToDateTime("12/05/2026"), Valor = 120.00, Status = StatusBoleto.Vencido });
            SaveBoletoAsync(new Boleto() { Nome = "Compra Online", DataVencimento = Convert.ToDateTime("12/05/2026"), Valor = 120.00, Status = StatusBoleto.Vencido });
            SaveBoletoAsync(new Boleto() { Nome = "Imposto de Renda", DataVencimento = Convert.ToDateTime("13/05/2026"), Valor = 450.00, Status = StatusBoleto.EmAberto });
            SaveBoletoAsync(new Boleto() { Nome = "Mensalidade Escolar", DataVencimento = Convert.ToDateTime("14/05/2026"), Valor = 800.00, Status = StatusBoleto.Pago });
            SaveBoletoAsync(new Boleto() { Nome = "Seguro Residencial", DataVencimento = Convert.ToDateTime("15/05/2026"), Valor = 300.00, Status = StatusBoleto.EmAberto });
            SaveBoletoAsync(new Boleto() { Nome = "Taxa de Condomínio", DataVencimento = Convert.ToDateTime("16/05/2026"), Valor = 250.00, Status = StatusBoleto.Vencido });
            SaveBoletoAsync(new Boleto() { Nome = "Pagamento de Empréstimo", DataVencimento = Convert.ToDateTime("17/05/2026"), Valor = 600.00, Status = StatusBoleto.Pago });
            SaveBoletoAsync(new Boleto() { Nome = "Assinatura de Revista", DataVencimento = Convert.ToDateTime("18/05/2026"), Valor = 20.00, Status = StatusBoleto.EmAberto });
            SaveBoletoAsync(new Boleto() { Nome = "Recarga de Celular", DataVencimento = Convert.ToDateTime("19/05/2026"), Valor = 50.00, Status = StatusBoleto.Nenhum });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de IPTU", DataVencimento = Convert.ToDateTime("20/05/2026"), Valor = 380.00, Status = StatusBoleto.Pago });
            SaveBoletoAsync(new Boleto() { Nome = "Taxa de Licenciamento", DataVencimento = Convert.ToDateTime("21/05/2026"), Valor = 150.00, Status = StatusBoleto.EmAberto });
            SaveBoletoAsync(new Boleto() { Nome = "Compra de Presente", DataVencimento = Convert.ToDateTime("22/05/2026"), Valor = 100.00, Status = StatusBoleto.Vencido });
            SaveBoletoAsync(new Boleto() { Nome = "Conserto do Carro", DataVencimento = Convert.ToDateTime("23/05/2026"), Valor = 400.00, Status = StatusBoleto.Pago });
            SaveBoletoAsync(new Boleto() { Nome = "Seguro do Carro", DataVencimento = Convert.ToDateTime("24/05/2026"), Valor = 200.00, Status = StatusBoleto.EmAberto });
            SaveBoletoAsync(new Boleto() { Nome = "Aluguel da Garagem", DataVencimento = Convert.ToDateTime("25/05/2026"), Valor = 100.00, Status = StatusBoleto.Nenhum });
            SaveBoletoAsync(new Boleto() { Nome = "Consulta Médica", DataVencimento = Convert.ToDateTime("26/05/2026"), Valor = 150.00, Status = StatusBoleto.Pago });
            SaveBoletoAsync(new Boleto() { Nome = "Exame Laboratorial", DataVencimento = Convert.ToDateTime("27/05/2026"), Valor = 80.00, Status = StatusBoleto.EmAberto });
            SaveBoletoAsync(new Boleto() { Nome = "Medicamentos", DataVencimento = Convert.ToDateTime("28/05/2026"), Valor = 120.00, Status = StatusBoleto.Vencido });
            SaveBoletoAsync(new Boleto() { Nome = "Compra de Livros", DataVencimento = Convert.ToDateTime("29/05/2026"), Valor = 70.00, Status = StatusBoleto.Pago });
            SaveBoletoAsync(new Boleto() { Nome = "Assinatura de Jornal", DataVencimento = Convert.ToDateTime("30/05/2026"), Valor = 25.00, Status = StatusBoleto.EmAberto });
        }
    }
}
