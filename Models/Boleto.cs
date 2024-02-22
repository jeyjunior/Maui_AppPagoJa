using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_PagoJa.Models
{
    public class Boleto
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public StatusBoleto Status { get; set; }

        // ADD VALIDATION
    }

    public enum StatusBoleto
    {
        Nenhum = 0,
        EmAberto = 1,
        Pago = 2,
        Vencido = 3,
    }
}
