using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgroDDD.Venda.Domain
{
    public class Orcamento
    {
        private Orcamento() { }

        public int Id { get; set; }

        public int IdCliente { get; set; }

        public DateTime DataOrcamento { get; set; }

        public string Status { get; set; }

        public ICollection<ItemOrc> Itens { get; set; }
    }
}
