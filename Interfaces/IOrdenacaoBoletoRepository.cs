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
        Task UpdateOrdenacao(Ordenacao ordenacao);
    }
}
