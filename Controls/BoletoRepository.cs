using Maui_PagoJa.Interfaces;
using Maui_PagoJa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_PagoJa.Controls
{
    public class BoletoRepository : IBoletoControl
    {
        public IEnumerable<Boleto> ObterLista()
        {
            // Obter Coleção da base de dados
            var boletoCollection = new List<Boleto>()
            {
                new Boleto(){ Nome = "Boleto de Aluguel", Data = Convert.ToDateTime("01/05/2026"), Valor = 850.00, Status = StatusBoleto.EmAberto },
                new Boleto(){ Nome = "Conta de Internet", Data = Convert.ToDateTime("02/05/2026"), Valor = 79.90, Status = StatusBoleto.Nenhum },
                new Boleto(){ Nome = "Conta de Luz", Data = Convert.ToDateTime("03/05/2026"), Valor = 150.00, Status = StatusBoleto.Pago },
                new Boleto(){ Nome = "Boleto de Condomínio", Data = Convert.ToDateTime("04/05/2026"), Valor = 300.00, Status = StatusBoleto.Vencido },
                new Boleto(){ Nome = "Parcela do Empréstimo", Data = Convert.ToDateTime("05/05/2026"), Valor = 500.00, Status = StatusBoleto.EmAberto },
                new Boleto(){ Nome = "Fatura de Cartão de Crédito", Data = Convert.ToDateTime("06/05/2026"), Valor = 1200.00, Status = StatusBoleto.Pago },
                new Boleto(){ Nome = "Boleto de Água", Data = Convert.ToDateTime("07/05/2026"), Valor = 90.00, Status = StatusBoleto.EmAberto },
                new Boleto(){ Nome = "Mensalidade de Academia", Data = Convert.ToDateTime("08/05/2026"), Valor = 200.00, Status = StatusBoleto.Vencido },
                new Boleto(){ Nome = "Aluguel de Carro", Data = Convert.ToDateTime("09/05/2026"), Valor = 300.00, Status = StatusBoleto.Nenhum },
                new Boleto(){ Nome = "Compra de Supermercado", Data = Convert.ToDateTime("10/05/2026"), Valor = 250.00, Status = StatusBoleto.Pago },
                new Boleto(){ Nome = "Assinatura de Streaming", Data = Convert.ToDateTime("11/05/2026"), Valor = 29.90, Status = StatusBoleto.EmAberto },
                new Boleto(){ Nome = "Compra Online", Data = Convert.ToDateTime("12/05/2026"), Valor = 120.00, Status = StatusBoleto.Vencido },
                new Boleto(){ Nome = "Imposto de Renda", Data = Convert.ToDateTime("13/05/2026"), Valor = 450.00, Status = StatusBoleto.EmAberto },
                new Boleto(){ Nome = "Mensalidade Escolar", Data = Convert.ToDateTime("14/05/2026"), Valor = 800.00, Status = StatusBoleto.Pago },
                new Boleto(){ Nome = "Seguro Residencial", Data = Convert.ToDateTime("15/05/2026"), Valor = 300.00, Status = StatusBoleto.EmAberto },
                new Boleto(){ Nome = "Taxa de Condomínio", Data = Convert.ToDateTime("16/05/2026"), Valor = 250.00, Status = StatusBoleto.Vencido },
                new Boleto(){ Nome = "Pagamento de Empréstimo", Data = Convert.ToDateTime("17/05/2026"), Valor = 600.00, Status = StatusBoleto.Pago },
                new Boleto(){ Nome = "Assinatura de Revista", Data = Convert.ToDateTime("18/05/2026"), Valor = 20.00, Status = StatusBoleto.EmAberto },
                new Boleto(){ Nome = "Recarga de Celular", Data = Convert.ToDateTime("19/05/2026"), Valor = 50.00, Status = StatusBoleto.Nenhum },
                new Boleto(){ Nome = "Boleto de IPTU", Data = Convert.ToDateTime("20/05/2026"), Valor = 380.00, Status = StatusBoleto.Pago },
                new Boleto(){ Nome = "Taxa de Licenciamento", Data = Convert.ToDateTime("21/05/2026"), Valor = 150.00, Status = StatusBoleto.EmAberto },
                new Boleto(){ Nome = "Compra de Presente", Data = Convert.ToDateTime("22/05/2026"), Valor = 100.00, Status = StatusBoleto.Vencido },
                new Boleto(){ Nome = "Conserto do Carro", Data = Convert.ToDateTime("23/05/2026"), Valor = 400.00, Status = StatusBoleto.Pago },
                new Boleto(){ Nome = "Seguro do Carro", Data = Convert.ToDateTime("24/05/2026"), Valor = 200.00, Status = StatusBoleto.EmAberto },
                new Boleto(){ Nome = "Aluguel da Garagem", Data = Convert.ToDateTime("25/05/2026"), Valor = 100.00, Status = StatusBoleto.Nenhum },
                new Boleto(){ Nome = "Consulta Médica", Data = Convert.ToDateTime("26/05/2026"), Valor = 150.00, Status = StatusBoleto.Pago },
                new Boleto(){ Nome = "Exame Laboratorial", Data = Convert.ToDateTime("27/05/2026"), Valor = 80.00, Status = StatusBoleto.EmAberto },
                new Boleto(){ Nome = "Medicamentos", Data = Convert.ToDateTime("28/05/2026"), Valor = 120.00, Status = StatusBoleto.Vencido },
                new Boleto(){ Nome = "Compra de Livros", Data = Convert.ToDateTime("29/05/2026"), Valor = 70.00, Status = StatusBoleto.Pago },
                new Boleto(){ Nome = "Assinatura de Jornal", Data = Convert.ToDateTime("30/05/2026"), Valor = 25.00, Status = StatusBoleto.EmAberto },
            };

            return boletoCollection;
        }       
    }
}
