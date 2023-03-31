using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using apiToDo.Services;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly Tarefas _tarefas;

        public TarefasController(Tarefas tarefas)
        {
            _tarefas = tarefas;
        }



        //[Authorize]
        [HttpGet("lstTarefas")]
        public ActionResult lstTarefas()
        {
            try
            {
                IList<TarefaDTO> listaTarefas = _tarefas.listTarefas();
                return StatusCode(200, listaTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = ex.Message});
            }
        }



        [HttpGet("Tarefa")]
        public ActionResult SingleTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                TarefaDTO listTarefas = _tarefas.ProcurarTarefa(ID_TAREFA);
                return StatusCode(200,  listTarefas );
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = ex.Message });
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {                
                _tarefas.InserirTarefa(Request);
                IList<TarefaDTO> listTarefas = _tarefas.listTarefas();
                return StatusCode(200,listTarefas);

            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = ex.Message });
            }
        }

        [HttpDelete("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                _tarefas.DeletarTarefa(ID_TAREFA);
                IList<TarefaDTO> listTarefas = _tarefas.listTarefas();
                return StatusCode(200,listTarefas );
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = ex.Message });
            }
        }


        [HttpPatch("AtualizarTarefa")]
        public ActionResult UpdateTask([FromQuery] int ID_TAREFA, [FromBody] string DS_TAREFA)
        {

            try
            {
                _tarefas.AtualizarTarefa(ID_TAREFA, DS_TAREFA);
                IList<TarefaDTO> listTarefas = _tarefas.listTarefas();
                return StatusCode(200, listTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = ex.Message});
            }
        }
    }
}
