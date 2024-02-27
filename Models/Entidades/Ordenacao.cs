using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Maui_PagoJa.Models.Entidades
{
    public class Ordenacao
    {
        [PrimaryKey, AutoIncrement]
        public int PK_Ordenacao { get; set; }
        [NotNull]
        public string Descricao { get; set; }
        [NotNull]
        public int Sequencia { get; set; }
        [NotNull]
        public bool Ativo { get; set; }

        public bool IsValid => Validate() == null;
        public ValidationResult Validate()
        {
            if (string.IsNullOrEmpty(Descricao))
                return new ValidationResult("É necessário inserir um nome para a descrição.");

            if (Sequencia < 0)
                return new ValidationResult("A sequencia é inválida.");

            return ValidationResult.Success;
        }
    }
}
