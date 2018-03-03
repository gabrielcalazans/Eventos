using Eventos.AcessoADados;
using Eventos.AcessoADados.Modelos;
using Eventos.AcessoADados.ModelView;
using Eventos.AcessoADados.ObjetosDeAcesso;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.RegrasDeNegocio
{
    public class EventosBll
    {
        public void Inserir(EventoModelView eventoModelView)
        {
            var evento = new Evento();

            evento = PrepararEvento(eventoModelView, evento);

            var eventoDao = new EventoDAO();
            eventoDao.Inserir(evento);

        }

        public void Atualizar(int id, EventoModelView eventoModelView)
        {
            var eventoDao = new EventoDAO();
            var evento = eventoDao.ObterPorId(id);
            evento = PrepararEvento(eventoModelView, evento);
            eventoDao.Atualizar(evento);
        }
        public Evento ObterPorId(int id)
        {
            using (var bancoDeDados = new BancoDeDados())
            {
                return bancoDeDados.Eventos.Find(id);
            }
        }

        public List<Evento> ObterTodos()
        {
            var Dao = new EventoDAO();
            return Dao.ObterTodos();
        }

        public Evento PrepararEvento(EventoModelView eventoModelView, Evento eventos)
        {
            var evento = new Evento();

            evento.Nome = eventoModelView.Nome;
            evento.Data = eventoModelView.Data;
            evento.Local = eventoModelView.Local;
            evento.HoraInicio = eventoModelView.HoraInicio;
            evento.HoraFim = eventoModelView.HoraFim;
            evento.OpenBar = eventoModelView.OpenBar;
            evento.QuantidadeDeAmbientes = eventoModelView.QuantidadeDeAmbientes;

            if (evento.HoraInicio > 10 && evento.HoraFim < 20 && evento.QuantidadeDeAmbientes > 2)
            {
                evento.FaixaEtaria = "Menos que 16 anos";
            }
            else if (evento.HoraInicio > 20 && evento.HoraFim < 2 && evento.OpenBar == false)
            {
                evento.FaixaEtaria = "Maior que 16 anos";
            }
            else
            {
                evento.FaixaEtaria = "Maior que 18 anos";
            }

            return evento;


        }
    }
}
