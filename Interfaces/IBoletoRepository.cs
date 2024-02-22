using Maui_PagoJa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_PagoJa.Interfaces
{
    public interface IBoletoRepository
    {
        int SaveBoletoAsync(Boleto boleto);
        Task<IEnumerable<Boleto>> GetBoletosAsync();
    }
}
