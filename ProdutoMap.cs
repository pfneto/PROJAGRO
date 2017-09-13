using ProjAgroDDD.Produto.Domain;
using System.Data.Entity.ModelConfiguration;

namespace ProjAgroDDD.Infra.Mapping
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");

            HasKey(x => x.Id);

            Property(x => x.Descricao).HasMaxLength(160).IsRequired();
            Property(x => x.Preco).IsRequired();
           

            HasRequired(x => x.IdFornecedor);
        }
    }
}