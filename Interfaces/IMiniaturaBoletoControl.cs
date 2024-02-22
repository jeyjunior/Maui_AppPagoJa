using Maui_PagoJa.Models;
using Maui_PagoJa.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_PagoJa.Interfaces
{
    public interface IMiniaturaBoletoControl
    {
        MiniaturaBoletoView Criar(Boleto boleto);
        IEnumerable<MiniaturaBoletoView> CriarPool(int quantidade);
    }
}
