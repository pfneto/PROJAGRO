using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgroDDD.Produto.Domain
{
    public class Produto
    {
       
        public Produto() { }

        public int Id { get; set; }

        public int IdFornecedor { get; set; }

        public string Descricao { get; set; }

        public string Tipo { get; set; }

        public int Saldo { get; set; }

        public DateTime DataValidade { get; set; }

        public string UnidadeMedida { get; set; }

        public decimal PrecoUnitario { get; set; }

        public string Status { get; set; }


    }
}
