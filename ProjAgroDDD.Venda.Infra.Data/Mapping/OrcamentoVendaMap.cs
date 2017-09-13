using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjAgroDDD.Venda.Domain;
using System.Data.Entity.ModelConfiguration;

namespace ProjAgroDDD.Venda.Infra.Data.Mapping
{
    public class OrcamentoVendaMap : EntityTypeConfiguration<Orcamento>
    {
        public OrcamentoVendaMap()
        {
            ToTable("Orcamento");

            HasKey(x => x.Id);


            Property(x => x.IdCliente).IsRequired();
            Property(x => x.DataOrcamento).IsRequired();
        }
    }
}