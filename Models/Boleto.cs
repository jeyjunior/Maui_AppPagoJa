using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_PagoJa.Models
{
    public class Boleto
    {
        [PrimaryKey, AutoIncrement]
        public int PK_Boleto { get; set; }
        [NotNull]
        public string Nome { get; set; }
        [NotNull]
        public DateTime DataVencimento { get; set; }
        [NotNull]
        public double Valor { get; set; }
        [NotNull]
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
