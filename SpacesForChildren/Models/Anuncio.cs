using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public class Anuncio 
    {
        public int AnuncioID { get; set; }
        public string AnuncioTitulo { get; set; }
        public string AnuncioDescricao { get; set; }
        public DateTime? AnuncioData { get; set; }
        public Instituicao Instituicao { get; set; }
        public Servico Servico { get; set; }
        public IList<Pedido> Pedido { get; set; }
    }
}