using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_PagoJa.Models.Entidades
{
    public class LancamentoBoleto
    {
        [PrimaryKey, AutoIncrement]
        public int PK_LancamentoBoleto { get; set; }
        [NotNull]
        public int FK_Boleto { get; set; }
        [NotNull]
        public DateTime DataLancamento { get; set; }
        [NotNull]
        public DateTime DataVencimento { get; set; }
        [NotNull]
        public StatusBoleto StatusBoleto { get; set; }
        [NotNull]
        public double ValorBoleto { get; set; }
        public string Informacoes { get; set; }

        // Relacionamentos
        public IEnumerable<Boleto> Boleto { get; set; }
    }
}
