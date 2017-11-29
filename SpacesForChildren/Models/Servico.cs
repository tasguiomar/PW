using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public enum TipoServ { Creche, Transporte, Natação, Música, Infantário, Berçário, CTL, Dança, Teatro, Outro };

    public class Servico
    {
        public int ServicosID { get; set; }
        public string ServicosDescricao { get; set; }
        public float ServicosPreco { get; set; }
        public TipoServ ServicosTipo { get; set; }
        public int InstituicaoID { get; set; }

        public virtual Instituicao Instituicao { get; set; }
    }
}

