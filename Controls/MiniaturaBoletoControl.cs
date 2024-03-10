using Maui_PagoJa.Interfaces;
using Maui_PagoJa.Models;
using Maui_PagoJa.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_PagoJa.Controls
{
    public class MiniaturaBoletoControl : IMiniaturaBoletoControl
    {
        public MiniaturaBoletoView Criar(Boleto boleto)
        {
            if (!boleto.IsValid)
                return null;

            var miniaturaBoleto = new MiniaturaBoletoView();
            miniaturaBoleto.DefinirInformacoes(boleto);
            miniaturaBoleto.IsVisible = true;

            return miniaturaBoleto;
        }

        public IEnumerable<MiniaturaBoletoView> CriarPool(int quantidade)
        {
            var miniaturaBoletos = new List<MiniaturaBoletoView>();

            for (int i = 0; i < quantidade; i++)
            {
                var miniatura = Criar(new Boleto { Nome = "Boleto", DiaVencimento = 10, DataLimite = DateTime.Today.AddMonths(i), Ativo = true, DataRegistro = DateTime.Today, PgtoContinuo = false, Valor = 999, Status = StatusBoleto.EmAberto });

                if(miniatura != null)
                    miniaturaBoletos.Add(miniatura);
            }

            return miniaturaBoletos;
        }
    }
}
