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
        public int PaiID { get; set; }
        public int ServicoID { get; set; }

        public virtual Servico Servico { get; set; }
        public virtual Pai Pai { get; set; }
    }
}