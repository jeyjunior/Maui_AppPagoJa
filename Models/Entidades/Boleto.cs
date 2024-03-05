using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
        [NotNull]
        public int RepetirMeses { get; set; }
        [NotNull]
        public bool Ativo { get; set; }
        public bool IsValid => Validate() == null;
        public ValidationResult Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                return new ValidationResult("É necessário inserir um nome para o Boleto.");

            if (DataVencimento == DateTime.MinValue)
                return new ValidationResult("A data de vencimento é inválida.");

            if (Valor < 0)
                return new ValidationResult("O valor do Boleto deve ser maior que zero.");

            return ValidationResult.Success;
        }
    }

    public enum StatusBoleto
    {
        Nenhum = 0,
        EmAberto = 1,
        Pago = 2,
        Vencido = 3,
    }
}
