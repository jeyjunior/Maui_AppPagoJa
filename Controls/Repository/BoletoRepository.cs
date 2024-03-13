using Maui_PagoJa.Controls.Interfaces;
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
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Condomínio The Spot", DataLimite = null, Valor = 850, Status = StatusBoleto.EmAberto, DiaVencimento = 5 , DataRegistro = DateTime.Today, PgtoContinuo = true, Ativo = true });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Condomínio The Spot", DataLimite = null, Valor = 850, Status = StatusBoleto.EmAberto, DiaVencimento = 4 , DataRegistro = DateTime.Today, PgtoContinuo = true, Ativo = true });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Condomínio The Spot", DataLimite = null, Valor = 850, Status = StatusBoleto.EmAberto, DiaVencimento = 10 , DataRegistro = DateTime.Today, PgtoContinuo = true, Ativo = true });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Condomínio The Sp", DataLimite = Convert.ToDateTime("02/05/2026"), Valor = 79, Status = StatusBoleto.Vencido, DiaVencimento = 2, DataRegistro = DateTime.Today, PgtoContinuo = false, Ativo = true });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Condomínio The Sp", DataLimite = Convert.ToDateTime("02/05/2026"), Valor = 79, Status = StatusBoleto.Vencido, DiaVencimento = 12, DataRegistro = DateTime.Today, PgtoContinuo = false, Ativo = true });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Condomínio The Sp", DataLimite = Convert.ToDateTime("02/05/2026"), Valor = 79, Status = StatusBoleto.Vencido, DiaVencimento = 22, DataRegistro = DateTime.Today, PgtoContinuo = false, Ativo = true });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Condomínio The Spot.", DataLimite = Convert.ToDateTime("03/05/2026"), Valor = 150, Status = StatusBoleto.Pago, DiaVencimento = 19, DataRegistro = DateTime.Today, PgtoContinuo = false, Ativo = true });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Condomínio The Spot.", DataLimite = Convert.ToDateTime("03/05/2026"), Valor = 150, Status = StatusBoleto.Pago, DiaVencimento = 25, DataRegistro = DateTime.Today, PgtoContinuo = false, Ativo = true });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Condomínio The Spot.", DataLimite = Convert.ToDateTime("03/05/2026"), Valor = 150, Status = StatusBoleto.Pago, DiaVencimento = 3, DataRegistro = DateTime.Today, PgtoContinuo = false, Ativo = true });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto de Condomínio The Spot.", DataLimite = Convert.ToDateTime("04/05/2026"), Valor = 300, Status = StatusBoleto.Nenhum, DiaVencimento = 6, DataRegistro = DateTime.Today, PgtoContinuo = false, Ativo = true });
            SaveBoletoAsync(new Boleto() { Nome = "Boleto Inativo", DataLimite = Convert.ToDateTime("01/01/2024"), Valor = 999.99M, Status = StatusBoleto.Nenhum, DiaVencimento = 10, DataRegistro = DateTime.Today, PgtoContinuo = false, Ativo = false });
        }
    }
}
