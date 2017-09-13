using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgroDDD.Fornecedor.Domain
{
    public class Fornecedor
    {
        private Fornecedor() { }

        public int Id { get; set; }

        
        public string RazaoSocial { get; set; }
       
        public string Tipo { get; set; }

        public decimal CNPJ { get; set; }

        public string Endereco { get; set; }

        public string Email { get; set; }
    }
}
