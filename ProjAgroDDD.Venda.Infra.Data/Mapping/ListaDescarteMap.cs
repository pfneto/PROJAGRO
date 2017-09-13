using System.Data.Entity.ModelConfiguration;

namespace ProjAgroDDD.Venda.Infra.Data.Mapping
{
    public class ListaDescarteMap : EntityTypeConfiguration<ProjAgroDDD.Produto.Domain.ListaDescarte>
    {
        public ListaDescarteMap()
        {
            ToTable("ListaDescarte");

            HasKey(x => x.Id);
            HasKey(x => x.IdProduto);
            HasKey(x => x.IdFornecedor);

            Property(x => x.DataValidade).IsRequired();
            Property(x => x.SituacaoEnvio).IsRequired();
            Property(x => x.Volumes).IsRequired();


        }
    }
}
