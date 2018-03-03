using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.AcessoADados.ModelView;
using Eventos.RegrasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.App.Controllers
{
    [Route("api/Serie")]
    public class EventoController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] EventoModelView eventoModelView)
        {
            try
            {
                var eventoBll = new EventosBll();
                eventoBll.Inserir(eventoModelView);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
        //api/Serie/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EventoModelView eventoModelView)
        {
            try
            {
                var eventoBll = new EventosBll();
                eventoBll.Atualizar(id, eventoModelView);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetComId(int id)
        {
            try
            {
                var eventoBll = new EventosBll();
                var evento = eventoBll.ObterPorId(id);
                return Json(evento);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var eventoBll = new EventosBll();
                var listaDeEventos = eventoBll.ObterTodos();
                return listaDeEventos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }

        }
    }

}