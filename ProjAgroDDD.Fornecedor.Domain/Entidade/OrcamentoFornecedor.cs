using System;
using System.Collections.Generic;

namespace ProjAgroDDD.Fornecedor.Domain
{
    public class OrcamentoFornecedor
    {
        private OrcamentoFornecedor() { }

        public int Id { get; set; }

        public int IdFornecedor { get; set; }

        public DateTime DataOrcamento { get; set; }

        public string Status { get; set; }

        public ICollection<ItemF> Itens { get; set; }
    }
}
