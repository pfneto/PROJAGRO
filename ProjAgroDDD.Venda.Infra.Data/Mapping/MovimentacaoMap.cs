using System.Data.Entity.ModelConfiguration;


namespace ProjAgroDDD.Venda.Infra.Data.Mapping
{
    public class MovimentacaoMap : EntityTypeConfiguration<ProjAgroDDD.Produto.Domain.Movimentacao>
    {
        public MovimentacaoMap()
        {
            ToTable("Movimentacao");

            HasKey(x => x.Id);


            Property(x => x.IdProduto).IsRequired();


        }
    }
}