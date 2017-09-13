using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjAgroDDD.Fornecedor.Domain;
using System.Data.Entity.ModelConfiguration;

namespace ProjAgroDDD.Venda.Infra.Data.Mapping
{
    public class OrcamentoCompraMap : EntityTypeConfiguration<OrcamentoFornecedor>
    {
        public OrcamentoCompraMap()
        {
            ToTable("OrcamentoFornecedor");

            HasKey(x => x.Id);


            Property(x => x.IdFornecedor).IsRequired();
            Property(x => x.DataOrcamento).IsRequired();
        }
    }
}