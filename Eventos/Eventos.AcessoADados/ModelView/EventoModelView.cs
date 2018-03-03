using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventos.AcessoADados.ModelView
{
    public class EventoModelView
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public String Local { get; set; }
        [Required]
        public int HoraInicio { get; set; }
        [Required]
        public int HoraFim { get; set; }
        [Required]
        public bool OpenBar { get; set; }
        [Required]
        public int QuantidadeDeAmbientes { get; set; }
        public String FaixaEtaria { get; set; }
    }
}
