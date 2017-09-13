using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgroDDD.Venda.Domain
{
    public class Pedido
    {
        private Pedido() { }

        public int Id { get; set; }

        public int IdCliente { get; set; }

        public DateTime DataPedido { get; set; }

        public string Status { get; set; }

        public ICollection<Item> Itens{ get; set; }
    }

}
