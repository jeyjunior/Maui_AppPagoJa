using Maui_PagoJa.Interfaces;
using Maui_PagoJa.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_PagoJa.Controls.Repository
{
    public class OrdenacaoBoletoRepository : IOrdenacaoBoletoRepository
    {
        public async Task<IEnumerable<Ordenacao>> GetOrdenacao()
        {
            string sql = $"SELECT * FROM Ordenacao";

            var resultado = App.asyncConnection.QueryAsync<Ordenacao>(sql);

            if(resultado.Result != null)
            {
                return resultado.Result.ToList();
            }

            return null;
        }

        public async Task UpdateOrdenacao(int PK_Ordenacao1, int PK_Ordenacao2, int PK_Ordenacao3)
        {
            if (PK_Ordenacao1 <= 0 || PK_Ordenacao2 <= 0 || PK_Ordenacao3 <= 0)
                return;

            string sqlUpdate = $"UPDATE Ordenacao " +
                               $"SET Sequencia = " +
                               $"    CASE " +
                               $"        WHEN PK_Ordenacao = {PK_Ordenacao1} THEN 1 " +
                               $"        WHEN PK_Ordenacao = {PK_Ordenacao2} THEN 2 " +
                               $"        WHEN PK_Ordenacao = {PK_Ordenacao3} THEN 3 " +
                               $"        ELSE 0 " +
                               $"    END, " +
                               $"    Ativo = " +
                               $"    CASE " +
                               $"        WHEN PK_Ordenacao IN ({PK_Ordenacao1}, {PK_Ordenacao2}, {PK_Ordenacao3}) THEN 1 " +
                               $"        ELSE 0 " +
                               $"    END;";

            var resultado = await App.asyncConnection.ExecuteAsync(sqlUpdate);

            if (resultado != null)
            {
                // Código de tratamento do resultado...
            }
        }

    }
}
