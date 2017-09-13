using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgroDDD.Fornecedor.Domain
{
    public class ItemF
    {

        private ItemF() { }

        public int Id { get; set; }

        public int IdProduto { get; set; }

        public int IdOperacao{ get; set; }

        public string TipoOperacao { get; set; }

        public int Quantidade { get; set; }

        public decimal CustoUnitario { get; set; }

        public string UnidadeMedida { get; set; }
    }
}
