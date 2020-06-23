using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;


namespace QuickBuy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            this.produtoRepositorio = produtoRepositorio;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.produtoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

         //GET api/<ProdutoController>/5
        [HttpGet("{id}")]
         public string Get(int id)
         {
           return "";
         }

        // POST api/<ProdutoController>
        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            try
            {
                this.produtoRepositorio.Adicionar(produto);
                return Created("api/produto", produto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
