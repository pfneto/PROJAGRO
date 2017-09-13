using HtmlAgilityPack;
using System;



namespace ProjAgroDDD.Produto.Domain
{
    public class ListaDescarte
    {

        public ListaDescarte() { }

        public int Id { get; set; }

        public int IdProduto { get; set; }

        public int IdFornecedor { get; set; }

        public string Descricao { get; set; }

        public string Tipo { get; set; }

        public decimal Quantidade { get; set; }

        public string UnidadeMedida { get; set; }
        public DateTime DataValidade { get; set; }

        public decimal Volumes { get; set; }

        public string SituacaoEnvio { get; set; }
        public string Email { get; set; }
        

        public bool EnviaEmailDescarte()
        {
            if (SituacaoEnvio== "SEPARADO")

            {

                
                return EmailController.Email.Send("pfneto@gmail.com", $"Descarte de Material {Descricao} {Tipo}", ConvertXmlToHtml(), Email.ToString());

            } 
            else
            {
                return false;
         
            } 
        }
        public string ConvertXmlToHtml()
        {

            HtmlDocument doc = new HtmlDocument();

            //     HtmlWeb doc = new HtmlWeb();
            //doc.Load("D:\\Pessoal\\Pos_puc_minas\\ProjAgroDDD\\ProjAgroDDD\\ProjAgroDDD.Produto.Domain\\Entidade\\TemplateEmail.html");

            doc.Load(".\\ProjAgroDDD.Produto.Domain\\Template\\TemplateEmail.html");

                    string Corpo = "<tr><td style= vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>"+this.Descricao.ToString()+"</td>"
+ "<td style=vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>" + this.Tipo.ToString() + "</td>"
+ "<td style=vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>"+ this.Quantidade.ToString() + "</td>"
+ "<td style=vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>"+ this.UnidadeMedida.ToString() + "</td>"
+ "<td style=vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>"+ this.Volumes.ToString() + "</td>"
+ "<td style=vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>"+ this.DataValidade.ToString() + "</td></tr>";
/*+ "<td style=vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5></td>"
+ "<td style=vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>R$ </td>"
+ "<td style=vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>R$ </td></tr>";*/

            string NovoHtml = doc.DocumentNode.InnerHtml;
            string CSS = NovoHtml.Replace("@CORPO", Corpo.ToString());
            return CSS;

        }
    }
}
