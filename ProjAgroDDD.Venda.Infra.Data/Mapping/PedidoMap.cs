using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjAgroDDD.Venda.Domain;

namespace ProjAgroDDD.Venda.Infra.Data.Mapping
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            ToTable("Pedido");

            HasKey(x => x.Id);

            
            Property(x => x.IdCliente).IsRequired();
            Property(x => x.DataPedido).IsRequired();


        }
    }
}
