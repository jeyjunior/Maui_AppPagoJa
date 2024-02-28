using Maui_PagoJa.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_PagoJa.Interfaces
{
    public interface IOrdenacaoBoletoRepository
    {
        Task<IEnumerable<Ordenacao>> GetOrdenacao();
        Task UpdateOrdenacao(int PK_Ordenacao1, int PK_Ordenacao2, int PK_Ordenacao3);
    }
}
