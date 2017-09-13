using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgroDDD.Venda.Infra.Data.Mapping
{
    public class FornecedorMap : EntityTypeConfiguration<ProjAgroDDD.Fornecedor.Domain.Fornecedor>
      
        {
            public FornecedorMap()
            {
                ToTable("Fornecedor");

                HasKey(x => x.Id);

                Property(x => x.RazaoSocial).HasMaxLength(160).IsRequired();
                Property(x => x.CNPJ).IsRequired();


            }
        }

    
}
