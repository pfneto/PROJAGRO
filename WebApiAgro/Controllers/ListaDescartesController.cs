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
using ProjAgroDDD.Produto.Domain;
using ProjAgroDDD.Venda.Infra.Data.Context;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace WebApiAgro.Controllers
{
    public class ListaDescartesController : ApiController
    {
        private ProjAgroContext db = new ProjAgroContext();

        // GET: api/ListaDescartes
        /*public IQueryable<ListaDescarte> GetListaDescarte()
        {
            return db.ListaDescarte;
        }*/


        // GET: api/ListaDescartes/Separados
        public bool GetEnviaEmail(string SituacaoEnvio)
        {
            bool sucesso = false;
            List<ListaDescarte> Lista = new List<ListaDescarte>();
            Lista = db.ListaDescarte.ToList<ListaDescarte>();
            
            foreach  (ListaDescarte reg in Lista)
            {
               // var ListaXml = GetXMLFromObject(reg);
                sucesso = reg.EnviaEmailDescarte();
                
            }

            return sucesso;


        }
        
        // GET: api/ListaDescartes/5
        [ResponseType(typeof(ListaDescarte))]
        public async Task<IHttpActionResult> GetListaDescarte(int id)
        {
            ListaDescarte listaDescarte = await db.ListaDescarte.FindAsync(id);
            if (listaDescarte == null)
            {
                return NotFound();
            }

            return Ok(listaDescarte);
        }

        // PUT: api/ListaDescartes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutListaDescarte(int id, ListaDescarte listaDescarte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listaDescarte.Id)
            {
                return BadRequest();
            }

            db.Entry(listaDescarte).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaDescarteExists(id))
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

        // POST: api/ListaDescartes
        [ResponseType(typeof(ListaDescarte))]
        public async Task<IHttpActionResult> PostListaDescarte(ListaDescarte listaDescarte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListaDescarte.Add(listaDescarte);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = listaDescarte.Id }, listaDescarte);
        }

        // DELETE: api/ListaDescartes/5
        [ResponseType(typeof(ListaDescarte))]
        public async Task<IHttpActionResult> DeleteListaDescarte(int id)
        {
            ListaDescarte listaDescarte = await db.ListaDescarte.FindAsync(id);
            if (listaDescarte == null)
            {
                return NotFound();
            }

            db.ListaDescarte.Remove(listaDescarte);
            await db.SaveChangesAsync();

            return Ok(listaDescarte);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListaDescarteExists(int id)
        {
            return db.ListaDescarte.Count(e => e.Id == id) > 0;
        }
    }
}