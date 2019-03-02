using APIPartnerGroup.Models;
using APIPartnerGroup.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIPartnerGroup.Controllers
{
    public class PatrimonioController : ApiController
    {
        IRepositorio<Patrimonio> patrimonioRepositorio = new RepositorioPatrimonio();
        // GET: api/Patrimonio
        public IEnumerable<Patrimonio> Get()
        {
            return patrimonioRepositorio.SelecionarTodos();
        }

        // GET: api/Patrimonio/5
        public Patrimonio Get(int id)
        {
            return patrimonioRepositorio.Selecionar(id);
        }

        // POST: api/Patrimonio
        public void Post([FromBody]Patrimonio patrimonio)
        {
            patrimonioRepositorio.Inserir(patrimonio);
        }

        // PUT: api/Patrimonio/5
        public void Put(int id, [FromBody]Patrimonio patrimonio)
        {
            patrimonioRepositorio.Alterar(id, patrimonio);
        }

        // DELETE: api/Patrimonio/5
        public void Delete(int id)
        {
            patrimonioRepositorio.Excluir(id);
        }
    }
}
