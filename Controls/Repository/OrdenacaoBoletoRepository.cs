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

        public async Task UpdateOrdenacao(Ordenacao ordenacao)
        {
            if (ordenacao == null)
                return;

            string sqlLimpar = " UPDATE Ordenacao " +
                                " SET" +
                                "       Sequencia = CASE" +
                               $"                       WHEN PK_Ordenacao = {ordenacao.PK_Ordenacao} THEN 1" +
                                "                       ELSE 0" +
                                "                   END," +
                                "       Ativo = CASE" +
                               $"                       WHEN PK_Ordenacao = {ordenacao.PK_Ordenacao} THEN 1" +
                                "                       ELSE 0" +
                                "               END;";

            var resultado = App.asyncConnection.ExecuteAsync(sqlLimpar);

            if(resultado.Result != null)
            {

            }
        }
    }
}
