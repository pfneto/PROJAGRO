using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;

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
        

        public string EnviaEmailDescarte(string Link_Rec)

        {
            try
            {
                string result=" ";

                if (SituacaoEnvio == "SEPARADO")

                {


                    if ( EmailController.Email.Send("pfneto@hotmail.com", $"Descarte de Material {Descricao} {Tipo}", ConvertXmlToHtml(Link_Rec), Email.ToString()))
                    {
                        result= "Sucesso";
                    }



                }
                else
                {
                    result = "Nenhum Descarte Encontrado";

                }
                return result;
            }
            catch (Exception ex)
             {

                return ex + "Erro Envio do Email de descarte";

            }
        }
        public string ConvertXmlToHtml(string Link_Rec)
        {

//            HtmlDocument doc = new HtmlDocument();

            //     HtmlWeb doc = new HtmlWeb();
            //doc.Load("D:\\Pessoal\\Pos_puc_minas\\ProjAgroDDD\\ProjAgroDDD\\ProjAgroDDD.Produto.Domain\\Entidade\\TemplateEmail.html");

            string htmltemp = @"<!DOCTYPE html>
<html>
	<head>
		<meta name='viewport' content='width=device-width'>
			<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>
				<title>Atenção Produtos para Descarte</title>
			</head>
			<body class='' style='background-color:#f6f6f6;font-family:sans-serif;-webkit-font-smoothing:antialiased;font-size:14px;line-height:1.4;margin:0;padding:0;-ms-text-size-adjust:100%;-webkit-text-size-adjust:100%;'>
				<table border='0' cellpadding='0' cellspacing='0' class='body' style='border-collapse:separate;mso-table-lspace:0pt;mso-table-rspace:0pt;background-color:#f6f6f6;width:100%;'>
					<tr>
						<td style='font-family:sans-serif;font-size:14px;vertical-align:top;'>&nbsp;</td>
						<td class='container' style='font-family:sans-serif;font-size:14px;vertical-align:top;display:block;max-width:900px;padding:10px;width:900px;Margin:0 auto !important;'>
							<div class='content' style='box-sizing:border-box;display:block;Margin:0 auto;max-width:900px;padding:10px;'>
								<!-- START CENTERED WHITE CONTAINER -->
								<span class='preheader' style='color:transparent;display:none;height:0;max-height:0;max-width:0;opacity:0;overflow:hidden;mso-hide:all;visibility:hidden;width:0;'>Atenção Produtos para Descarte.</span>
								<table class='main' style='border-collapse:separate;mso-table-lspace:0pt;mso-table-rspace:0pt;background:#fff;border-radius:3px;width:100%;'>
									<!-- START MAIN CONTENT AREA -->
									<tr>
										<td class='wrapper' style='font-family:sans-serif;font-size:14px;vertical-align:top;box-sizing:border-box;padding:20px;'>
											<table border='0' cellpadding='0' cellspacing='0' style='border-collapse:separate;mso-table-lspace:0pt;mso-table-rspace:0pt;width:100%;'>
												<tr>
													<td style='font-family:sans-serif;font-size:14px;vertical-align:top;'>
														<p style='font-family:sans-serif;font-size:14px;font-weight:normal;margin:0;Margin-bottom:15px;'>Prezados,</p>
														<p style='font-family:sans-serif;font-size:14px;font-weight:normal;margin:0;Margin-bottom:15px;'>Solicito providenciar a coleta do produto para descarte.</p>
															<tr>
																<td style='background-color:#cccccc; border:0px solid #ffffff;text-align:center; border-width:0px 0px 1px 1px; font-size:14px; font-family:Arial;font-weight:bold; color:#000000; padding:7px'>Produto</td>
																<td style='background-color:#cccccc; border:0px solid #ffffff;text-align:center; border-width:0px 0px 1px 1px; font-size:14px; font-family:Arial;font-weight:bold; color:#000000; padding:7px'>Tipo</td>
																<td style='background-color:#cccccc; border:0px solid #ffffff;text-align:center; border-width:0px 0px 1px 1px; font-size:14px; font-family:Arial;font-weight:bold; color:#000000; padding:7px'>Quantidade</td>
																<td style='background-color:#cccccc; border:0px solid #ffffff;text-align:center; border-width:0px 0px 1px 1px; font-size:14px; font-family:Arial;font-weight:bold; color:#000000; padding:7px'>Unidade de Medida</td> 
																<td style='background-color:#cccccc; border:0px solid #ffffff;text-align:center; border-width:0px 0px 1px 1px; font-size:14px; font-family:Arial;font-weight:bold; color:#000000; padding:7px'>Volume</td>
																<td style='background-color:#cccccc; border:0px solid #ffffff;text-align:center; border-width:0px 0px 1px 1px; font-size:14px; font-family:Arial;font-weight:bold; color:#000000; padding:7px'>Vencimento</td>
															</tr>
														
												@CORPO
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<!-- END MAIN CONTENT AREA -->
								</table>
						
<form method='POST' action='@linkrec'>
  <button class='btn btn-lg btn-primary btn-block' type='submit'>Confirmar Recebimento																</button>
</form>
               
                                  <br/>
								<div class='footer' style='clear:both;text-align:center;width:100%;'>
									<table border='0' cellpadding='0' cellspacing='0' style='border-collapse:separate;mso-table-lspace:0pt;mso-table-rspace:0pt;width:100%;'>
										<tr>
											<td class='content-block' style='font-family:sans-serif;font-size:14px;vertical-align:top;color:#999999;font-size:12px;text-align:center;'>
												<span class='apple-link' style='color:#999999;font-size:12px;text-align:center;'></span>
												<br/>
											
												</td>
											</tr>
											<tr>
												<td class='content-block powered-by' style='font-family:sans-serif;font-size:14px;vertical-align:top;color:#999999;font-size:12px;text-align:center;'>
												
												</td>
											</tr>
										</table>
									</div>
									<!-- END FOOTER -->
									<!-- END CENTERED WHITE CONTAINER -->
								</div>
							</td>
							<td style='font-family:sans-serif;font-size:14px;vertical-align:top;'>&nbsp;</td>
						</tr>
					</table>
				</body>
			</html>";

            //doc.Load(  + "\\TemplateEmail.html");
        //doc.Load(new StringReader(htmltemp));
         

            string Corpo = "<tr><td style= vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>" + this.Descricao.ToString() + "</td>"
+ "<td style=vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>" + this.Tipo.ToString() + "</td>"
+ "<td style=vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>" + this.Quantidade.ToString() + "</td>"
+ "<td style=vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>" + this.UnidadeMedida.ToString() + "</td>"
+ "<td style=vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>" + this.Volumes.ToString() + "</td>"
+ "<td style=vertical-align:middle; border:1px solid #ffffff;border-width:1px; text-align:left; padding:7px;font-size:11px;font-family:Arial;font-weight:normal;color:#000000; background-color:#F5F5F5>" + this.DataValidade.ToString() + "</td></tr>";
//+ $"< form action = "{Link_Rec}" method = "+"post"+" >   < button type = "+"submit"+" >CONFIRMAR RECEBIMENTO</button></form>";
                //+$"<ul><a href ={Link_Rec}> CONFIRMAR RECEBIMENTO </a></ul>";

            
           // string NovoHtml = doc.DocumentNode.InnerHtml;
            string htmlstr = htmltemp.Replace("@CORPO", Corpo.ToString()).Replace("@linkrec",Link_Rec);
         //   doc.Load(new StringReader(CSS));
           // string NovoHtml = doc.DocumentNode.InnerHtml;
            return htmlstr;

        }
    }
}
