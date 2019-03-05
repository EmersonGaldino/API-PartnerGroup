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
    
    public class MarcaController : ApiController
    {
        IRepositorio<Marca> repositorioMarca = new RepositorioMarca();
        // GET api/<controller>
        public IEnumerable<Marca> Get()
        {
            return repositorioMarca.SelecionarTodos();
        }

        // GET api/<controller>/5
        public Marca Get(int id)
        {
            Marca marca = repositorioMarca.Selecionar(id);

            
            return marca;
        }

        [HttpGet]
        [Route("api/Marca/{idMarca}/patrimonios")]
        public IHttpActionResult GetPatrimonios(int idMarca)
        {
            Marca marca = repositorioMarca.SelecionarDados(idMarca);
            return Ok(marca);
        }

        // POST api/<controller>
        public void Post([FromBody]Marca marca)
        {
            
            repositorioMarca.Inserir(marca);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Marca marca)
        {

            repositorioMarca.Alterar(id,marca);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            repositorioMarca.Excluir(id);
        }
    }
}