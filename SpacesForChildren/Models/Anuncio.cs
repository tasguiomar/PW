using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public class Anuncio
    {
        public int AnuncioID { get; set; }
        public int AnuncioTitulo { get; set; }
        public string AnuncioDescricao { get; set; }
        public DateTime? AnuncioData { get; set; }
        public int Instituicao { get; set; }
        public int Servico { get; set; }
    }
}