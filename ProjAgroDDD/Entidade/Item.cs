using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgroDDD.Venda.Domain
{
    public class Item
    {

        private Item() { }

        public int Id { get; set; }

        public int IdProduto { get; set; }

        public int IdOperacao{ get; set; }

        public string TipoOperacao { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        public string UnidadeMedida { get; set; }
    }
}
