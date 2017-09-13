
using System.Data.Entity.ModelConfiguration;

namespace ProjAgroDDD.Infra.Mapping
{
    public class ProdutoMap : EntityTypeConfiguration<ProjAgroDDD.Produto.Domain.Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");

            HasKey(x => x.Id);
            HasKey(x => x.DataValidade);
            Property(x => x.Descricao).HasMaxLength(160).IsRequired();
            Property(x => x.PrecoUnitario).IsRequired();
           
            
        }
    }
}