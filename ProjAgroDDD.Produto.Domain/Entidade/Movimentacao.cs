using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgroDDD.Produto.Domain
{
    public class Movimentacao
    {
        private Movimentacao() { }

        public int Id { get; set; }

        public int IdProduto { get; set; }


        
        public string Tipo { get; set; }

        public int Quantidade { get; set; }

        public decimal CustoUnitario { get; set; }

        public string UnidadeMedida { get; set; }
    }
}
