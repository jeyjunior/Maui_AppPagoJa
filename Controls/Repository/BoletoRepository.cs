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
            string sql = $"SELECT * FROM Boleto WHERE Ativo = 1 LIMIT 30";

            var resultado = App.asyncConnection.QueryAsync<Boleto>(sql);

            if(resultado.Result != null)
            {
                return resultado.Result.ToList();
            }

            return null;
        }

        public void AddBoletosParaTeste()
        {
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Aluguel", DataVencimento = Convert.ToDateTime("01/05/2026"), Valor = 850.00, Status = StatusBoleto.EmAberto, RepetirMeses = 5 ,Ativo = true });
            SaveBoletoAsync(new Boleto() { Nome = "Conta de Internet", DataVencimento = Convert.ToDateTime("02/05/2026"), Valor = 79.90, Status = StatusBoleto.Nenhum, RepetirMeses = 2, Ativo = true });
            SaveBoletoAsync(new Boleto() { Nome = "Conta de Luz", DataVencimento = Convert.ToDateTime("03/05/2026"), Valor = 150.00, Status = StatusBoleto.Pago, RepetirMeses = 9, Ativo = true });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Condomínio", DataVencimento = Convert.ToDateTime("04/05/2026"), Valor = 300.00, Status = StatusBoleto.Vencido, RepetirMeses = 6, Ativo = false });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto Inativo", DataVencimento = Convert.ToDateTime("01/01/2024"), Valor = 999.99, Status = StatusBoleto.Vencido, RepetirMeses = 10, Ativo = false });
        }
    }
}
