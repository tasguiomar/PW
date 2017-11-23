using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public class Avaliacao
    {
        public int AvaliacaoID { get; set; }
        public int AvaliacaoPreco { get; set; }
        public int AvaliacaoLocalizacao { get; set; }
        public int AvaliacaoAmbiente { get; set; }
        public int AvaliacaoGeral { get; set; }
        public int Pai { get; set; }
        public int Servico { get; set; }
    }
}