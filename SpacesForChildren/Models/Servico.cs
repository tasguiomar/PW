using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public enum TipoServ { Creche=1, Transporte=2, Natação=3, Música=4, Infantário=5, Berçário=6, CTL=7, Dança=8, Teatro=9, Outro=10 };

    public class Servico
    {
        public int ServicosID { get; set; }
        public string ServicosDescricao { get; set; }
        public float ServicosPreco { get; set; }
        public TipoServ ServicosTipo { get; set; }
        public Instituicao Instituicao { get; set; }
        public IList<Avaliacao> Avaliacoes { get; set; }
    }
}

