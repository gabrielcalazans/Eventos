using Eventos.AcessoADados.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventos.AcessoADados.ObjetosDeAcesso
{
    public class EventoDAO
    {
        private BancoDeDados BancoDeDados { get; set; }

        public EventoDAO() { }
        public EventoDAO(BancoDeDados bancoDeDados)
        {
            BancoDeDados = bancoDeDados;
        }

        //Adicionar
        public void Inserir(Evento evento)
        {
            using (var bancoDeDados = new BancoDeDados())
            {
                bancoDeDados.Eventos.Add(evento);
                bancoDeDados.SaveChanges();
            }

        }

        //Busca
        public Evento ObterPorId(int id)
        {
            using (var bancoDeDados = new BancoDeDados())
            {
                return bancoDeDados.Eventos.Find(id);
            }
        }

        //Deletar
        public void Deletar(int id)
        {
            using (var bancoDeDados = new BancoDeDados())
            {
                var serie = ObterPorId(id);
                bancoDeDados.Eventos.Remove(serie);
                bancoDeDados.SaveChanges();
            }
        }

        //Alterar
        public void Atualizar(Evento evento)
        {
            using (var bancoDeDados = new BancoDeDados())
            {
                bancoDeDados.Eventos.Update(evento);
                bancoDeDados.SaveChanges();
            }
        }

        //Listar
        public List<Evento> ObterTodos()
        {
            using (var bancoDeDados = new BancoDeDados())
            {
                return bancoDeDados.Eventos.ToList();
            }


        }
    }
}

