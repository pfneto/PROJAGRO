using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProjAgroDDD.Fornecedor.Domain;
using ProjAgroDDD.Venda.Infra.Data.Context;
using Newtonsoft.Json;
using RestSharp;

namespace WebApiAgro.Controllers
{
    public class OrcamentoFornecedoresController : ApiController
    {
        private ProjAgroContext db = new ProjAgroContext();

        // GET: api/OrcamentoFornecedores
        /*  public IQueryable<OrcamentoFornecedor> GetOrcamentoFornecedor()
          {
              return db.OrcamentoFornecedor;
          }*/
        //public List<OrcamentoFornecedor> GetEnviaOrcamento()
        public IQueryable<OrcamentoFornecedor> GetEnviaOrcamento()
        {

            // List<OrcamentoFornecedor> Lista = new List<OrcamentoFornecedor>();
           // OrcamentoFornecedor Lista = db.OrcamentoFornecedor;//.ToList<OrcamentoFornecedor>();

            foreach (OrcamentoFornecedor reg in db.OrcamentoFornecedor)
            {
                string jsonString = JsonConvert.SerializeObject( reg,   Formatting.None,     new JsonSerializerSettings()
                            {         ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                             });
                var client = new RestClient("http://localhost:8081");
                

                var request = new RestRequest("/OrcamentoFornecedor", Method.POST);
                request.AddHeader("Content-type", "application/json");
                request.AddParameter("application/json; charset=utf-8", jsonString);

                IRestResponse response = client.Execute(request);
           

            }
            return db.OrcamentoFornecedor;
           


        }

        // GET: api/OrcamentoFornecedores/5
        [ResponseType(typeof(OrcamentoFornecedor))]
        public async Task<IHttpActionResult> GetOrcamentoFornecedor(int id)
        {
            OrcamentoFornecedor orcamentoFornecedor = await db.OrcamentoFornecedor.FindAsync(id);
            if (orcamentoFornecedor == null)
            {
                return NotFound();
            }

            return Ok(orcamentoFornecedor);
        }

        // PUT: api/OrcamentoFornecedores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrcamentoFornecedor(int id, OrcamentoFornecedor orcamentoFornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orcamentoFornecedor.Id)
            {
                return BadRequest();
            }

            db.Entry(orcamentoFornecedor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrcamentoFornecedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrcamentoFornecedores
        [ResponseType(typeof(OrcamentoFornecedor))]
        public async Task<IHttpActionResult> PostOrcamentoFornecedor(OrcamentoFornecedor orcamentoFornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrcamentoFornecedor.Add(orcamentoFornecedor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = orcamentoFornecedor.Id }, orcamentoFornecedor);
        }

        // DELETE: api/OrcamentoFornecedores/5
        [ResponseType(typeof(OrcamentoFornecedor))]
        public async Task<IHttpActionResult> DeleteOrcamentoFornecedor(int id)
        {
            OrcamentoFornecedor orcamentoFornecedor = await db.OrcamentoFornecedor.FindAsync(id);
            if (orcamentoFornecedor == null)
            {
                return NotFound();
            }

            db.OrcamentoFornecedor.Remove(orcamentoFornecedor);
            await db.SaveChangesAsync();

            return Ok(orcamentoFornecedor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrcamentoFornecedorExists(int id)
        {
            return db.OrcamentoFornecedor.Count(e => e.Id == id) > 0;
        }
    }
}