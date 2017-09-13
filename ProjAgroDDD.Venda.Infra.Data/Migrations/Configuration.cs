namespace ProjAgroDDD.Venda.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjAgroDDD.Venda.Infra.Data.Context.ProjAgroContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjAgroDDD.Venda.Infra.Data.Context.ProjAgroContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
       /*     context.Produtos.Add(new ProjAgroDDD.Produto.Domain.Produto { Descricao = "PRODUTO A", Id = 1, IdFornecedor = 1, PrecoUnitario = 5, Saldo = 10, Tipo = "ADUBO", UnidadeMedida = "PCT", DataValidade = new DateTime(2018, 1, 18) });
            context.Produtos.Add(new ProjAgroDDD.Produto.Domain.Produto { Descricao = "PRODUTO B", Id = 2, IdFornecedor = 1, PrecoUnitario = 5, Saldo = 10, Tipo = "INSETICIDA", UnidadeMedida = "PCT", DataValidade = new DateTime(2018, 1, 18) });
            context.Produtos.Add(new ProjAgroDDD.Produto.Domain.Produto { Descricao = "PRODUTO C", Id = 3, IdFornecedor = 1, PrecoUnitario = 5, Saldo = 10, Tipo = "PESTICIDA", UnidadeMedida = "PCT", DataValidade = new DateTime(2018, 1, 18) });
            context.Produtos.Add(new ProjAgroDDD.Produto.Domain.Produto { Descricao = "PRODUTO D", Id = 4, IdFornecedor = 3, PrecoUnitario = 5, Saldo = 10, Tipo = "ADUBO", UnidadeMedida = "PCT", DataValidade = new DateTime(2018, 1, 18) });
            context.Produtos.Add(new ProjAgroDDD.Produto.Domain.Produto { Descricao = "PRODUTO E", Id = 5, IdFornecedor = 2, PrecoUnitario = 5, Saldo = 10, Tipo = "ADUBO", UnidadeMedida = "PCT", DataValidade = new DateTime(2018, 1, 18) });
            context.SaveChanges();*/

            /*

                         Id=1,  RazaoSocial="Cliente zzz", Tipo="Normal",  CNPJ="00000000000000",  Endereco="Rua 1234, RJ"
                         Id = 1,  RazaoSocial = "Cliente AAA", Tipo = "Especial",  CNPJ = "00000000000000",  Endereco = "Rua 990022, RJ"
                         Id = 1,  RazaoSocial = "Cliente DDD", Tipo = "Especial",  CNPJ = "00000000000000",  Endereco = "Rua 223344, RJ"

                        Id  IdProduto  IdOperacao TipoOperacao Quantidade  PrecoUnitario  UnidadeMedida */
            base.Seed(context);

        }
    }
}
