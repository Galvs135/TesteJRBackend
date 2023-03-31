using apiToDo.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
        {


        public static List<TarefaDTO> lstTarefas = new()
        {
         
        };
    

        public List<TarefaDTO> listTarefas()
        {
            if (lstTarefas.Count == 0 )
            {
                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 1,
                    DS_TAREFA = "Fazer Compras"
                });

                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 2,
                    DS_TAREFA = "Fazer Atividad Faculdade"
                });

                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 3,
                    DS_TAREFA = "Subir Projeto de Teste no GitHub"
                });

            }
            try
            {

                return lstTarefas;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao retornar a lista");
            }
        }


        public void InserirTarefa(TarefaDTO Request)
        {
            try
            {
                var lastObject = lstTarefas.LastOrDefault();
              
                Request.ID_TAREFA = lastObject == null? 1: lastObject.ID_TAREFA + 1; 
                lstTarefas.Add(Request);
            }
            catch(Exception)
            {
                throw new Exception("Tarefa não cadastrada");
            }
        }
        public void DeletarTarefa(int ID_TAREFA)
        {
            try                                                                                                     //inicializado o tryCatch para fazer o levantamento de erro caso necessário
            {
                var Tarefa = lstTarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);                              //realizada verificação se o Id recebido existe dentro da lista atual
                if (Tarefa == null)                                                                                 //Criado um If para levantar erro caso a busca acima não encontre o item
                {
                    throw new Exception();                                                                          //chamada a exceção caso a condição do If seja verdadeira
                }
                TarefaDTO Tarefa2 = lstTarefas.Where(x=> x.ID_TAREFA == Tarefa.ID_TAREFA).FirstOrDefault();         //realizada busca da tarefa baseado no Id recebido por parametro
                lstTarefas.Remove(Tarefa2);                                                                         //feito a remoção da tarefa da lista
            }
            catch (Exception)                                                                                       //captura alguma exceção que tenha sido levantada durante a execução do try
            {       
                throw new Exception("Id invalido");                                                                 //faz o levantamento do erro com a respectiva mensagem
            }
        }


        public TarefaDTO ProcurarTarefa(int ID_TAREFA)
        {
            try
            {
                var Tarefa = lstTarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                if (Tarefa == null)
                {
                    throw new Exception();
                }
                TarefaDTO Tarefa2 = lstTarefas.Where(x => x.ID_TAREFA == Tarefa.ID_TAREFA).FirstOrDefault();
                return Tarefa2;
            }
            catch (Exception)
            {
                throw new Exception("Tarefa não encontrada");
            }
        }


        public void AtualizarTarefa(int ID_TAREFA, string DS_TAREFA)
        {
            try
            {
                var Tarefa = lstTarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                if (Tarefa == null)
                {
                    throw new Exception();
                }
                TarefaDTO Tarefa2 = lstTarefas.Where(x => x.ID_TAREFA == Tarefa.ID_TAREFA).FirstOrDefault();
                Tarefa2.DS_TAREFA = DS_TAREFA;
              
            }
            catch (Exception)
            {
                throw new Exception("Tarefa não encontrada");
            }
        }
    }
}
