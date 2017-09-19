using ProjAgroDDD.Venda.Domain;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjAgroDDD.Produto.Domain;
using ProjAgroDDD.Fornecedor.Domain;
using System;

namespace ProjAgroDDD.Venda.Infra.Data.Context
{
    public partial class ProjAgroContext : DbContext
    {
        static ProjAgroContext()
        {
            Database.SetInitializer<ProjAgroContext>(null);
        }

        public ProjAgroContext()
            : base("Name=AgroDB")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Item> Item { get; set; }


        public DbSet<ItemOrc> ItemOrc { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<Orcamento> Orcamento { get; set; }

        public DbSet<ItemF> ItemF { get; set; }

        public DbSet<OrcamentoFornecedor> OrcamentoFornecedor { get; set; }

        public DbSet<ProjAgroDDD.Cliente.Domain.Cliente> Cliente { get; set; }

        public DbSet<ProjAgroDDD.Produto.Domain.ListaDescarte> ListaDescarte { get; set; }
        public DbSet<ProjAgroDDD.Produto.Domain.Movimentacao> Movimentacao { get; set; }
        
        public DbSet<ProjAgroDDD.Fornecedor.Domain.Fornecedor> Fornecedor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          //  modelBuilder.HasDefaultSchema("AgroDB");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ProjAgroDDD.Produto.Domain.Produto> Produtos { get; set; }
    }
    public class ProjAgroContextInitializer : DropCreateDatabaseIfModelChanges<ProjAgroContext>
    {
        protected override void Seed(ProjAgroContext context)
        {
        /*    context.Produtos.Add(new ProjAgroDDD.Produto.Domain.Produto { Descricao = "PRODUTO A", Id = 1, IdFornecedor = 1, PrecoUnitario = 5, Saldo = 10, Tipo = "ADUBO", UnidadeMedida = "PCT" , DataValidade = new DateTime(2018, 1, 18)});
            context.Produtos.Add(new ProjAgroDDD.Produto.Domain.Produto { Descricao = "PRODUTO B", Id = 2, IdFornecedor = 1, PrecoUnitario = 5, Saldo = 10, Tipo = "INSETICIDA", UnidadeMedida = "PCT", DataValidade = new DateTime(2018, 1, 18) });
            context.Produtos.Add(new ProjAgroDDD.Produto.Domain.Produto { Descricao = "PRODUTO C", Id = 3, IdFornecedor = 1, PrecoUnitario = 5, Saldo = 10, Tipo = "PESTICIDA", UnidadeMedida = "PCT", DataValidade = new DateTime(2018, 1, 18) });
            context.Produtos.Add(new ProjAgroDDD.Produto.Domain.Produto { Descricao = "PRODUTO D", Id = 4, IdFornecedor = 3, PrecoUnitario = 5, Saldo = 10, Tipo = "ADUBO", UnidadeMedida = "PCT", DataValidade = new DateTime(2018, 1, 18) });
            context.Produtos.Add(new ProjAgroDDD.Produto.Domain.Produto { Descricao = "PRODUTO E", Id = 5, IdFornecedor = 2, PrecoUnitario = 5, Saldo = 10, Tipo = "ADUBO", UnidadeMedida = "PCT", DataValidade = new DateTime(2018, 1, 18) });
            context.SaveChanges();*/

            base.Seed(context);

        }
    }
}
