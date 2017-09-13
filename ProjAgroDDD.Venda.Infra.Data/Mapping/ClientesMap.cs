using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgroDDD.Infra.Data.Mapping
{
    class ClientesMap : EntityTypeConfiguration<ProjAgroDDD.Cliente.Domain.Cliente>
    {
        public ClientesMap()
        {
            ToTable("Cliente");

            HasKey(x => x.Id);

            Property(x => x.RazaoSocial).HasMaxLength(160).IsRequired();
            Property(x => x.CNPJ).IsRequired();


        }

    }
}
