using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public enum Resp { Sim, Não };

    public class Resposta
    {
        public int RespostaID { get; set; }
        public Resp RespostaDecisao { get; set; }
        public Pedido Pedido { get; set; }
        public Instituicao Instituicao { get; set; }
    }
}