using SQLite;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Maui_PagoJa.Models
{
    public class Boleto
    {
        [PrimaryKey, AutoIncrement]
        public int PK_Boleto { get; set; }

        [NotNull]
        public string Nome { get; set; }

        [NotNull]
        public DateTime DataRegistro { get; set; }

        public int DiaVencimento { get; set; }

        public DateTime? DataLimite { get; set; } // Data limite para boletos sem vencimento

        [NotNull]
        public bool PgtoContinuo { get; set; }

        [NotNull]
        public StatusBoleto Status { get; set; }

        [NotNull]
        public bool Ativo { get; set; }

        [NotNull]
        public decimal Valor { get; set; }

        public bool IsValid => Validate() == null;

        // Método de validação aprimorado
        public ValidationResult Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                return new ValidationResult("É necessário inserir um nome para o Boleto.");
            else if (DiaVencimento < 1 || DiaVencimento > 31)
                return new ValidationResult("O dia de vencimento deve estar entre 1 e 31.");
            else if (!PgtoContinuo && DataLimite == null)
                return new ValidationResult("Se o pagamento não for contínuo, é necessário definir uma data limite.");
            else if(Valor <= 0)
                return new ValidationResult("É necessário inserir um valor para o Boleto.");

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
