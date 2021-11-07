using System.Globalization;
using System.Threading.Tasks;
using Api_Produto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Api_Produto.Models;

namespace Api_Produto.Controllers
{
    [ApiController]
    [Route("v1/filmes")]

    public class FilmesController : ControllerBase
    {

        private readonly DataContext _context;

        public FilmesController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("")]  //listando todos os filmes
        public async Task<ActionResult> GetFilmes()
        {
            var filmes = await _context.Filmes.ToListAsync();
            return Ok(filmes);
        }

        [HttpGet]
        [Route("{id:int}")]  //listando um filme específico 
        public async Task<ActionResult<Filme>> GetById([FromServices] DataContext context, int id)
        {
            try
            {
                var filme = await context.Filmes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);
                return filme;
            }
            catch
            {
                return BadRequest("filme não encontrado");
            }

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Filme>> Post(
              [FromServices] DataContext context, // recebendo o serviço o BD
              [FromBody] Filme model // recebendo do corpo da requisição a categoria
        )
        {
            if (ModelState.IsValid) //verificando se as requisições do model foram cumpridas ( MaxLength, MinLength....)
            {
                context.Filmes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }

            else
            {
                return BadRequest(ModelState);
            }
        }


    }
}